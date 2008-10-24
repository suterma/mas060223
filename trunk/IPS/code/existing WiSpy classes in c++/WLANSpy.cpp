// WLANSpy.cpp: implementation of the CWLANSpy class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "WLANSpy.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

///////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////
// Measurement thread procedure

UINT WLANSpyThreadProcedure(LPVOID pParam)
{
	CWLANSpy*		pInstrument;
	int				waitTime;
	int				retCode;
	BOOL			finished;

	// get a pointer to the instrument
	pInstrument = (CWLANSpy*) pParam;
	waitTime = pInstrument->mCfg.idleTime;

	// measurement loop
	finished = FALSE;
	do {
		retCode = pInstrument->PerformMeasurementCycle();
		if (retCode != 0) {
			// fatal error occurred
			pInstrument->pMeasThread = NULL;
			return 0;
		}

		// check timeout condition
		pInstrument->CheckAlive();

		// look out for the stop event
		retCode = WaitForSingleObject(pInstrument->stopMeasEvent, waitTime);
		if (retCode == WAIT_OBJECT_0)
			finished = TRUE;
	} while (!finished);

	// signal the thread completion
	pInstrument->measStoppedEvent.SetEvent();

	return 0;
}

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWLANSpy::CWLANSpy()
{
	pMeasThread		= NULL;
	instrumentType	= INSTR_TYPE_WLANSPY;
	wzcStatusAtInit	= WZC_STATUS_NOTDEFINED;
}

CWLANSpy::~CWLANSpy()
{
	// restore WZC service status found at init		
	switch (wzcStatusAtInit) {
	case WZC_STATUS_RUNNING:
		StartWZCSVC();
		break;
	case WZC_STATUS_STOPPED:
		StopWZCSVC();
		break;
	default:
		/* nothing to do */
		break;
	}
}

///////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////
// Measurement handlers

int CWLANSpy::Init(CWLANSpyConfig* pConfig)
{
	// initializes a new measurement
	int		returnCode;

	CString	buffer;

	// reset all parameters
	measStoppedEvent.ResetEvent();
	stopMeasEvent.ResetEvent();

	// if any thread is hanging close it
	if (pMeasThread != NULL)
		TerminateThread(pMeasThread->m_hThread, 0);

	SetInstrumentStatus(INSTR_STATUS_IDLE);
	saveFlag		= FALSE;

	SetErrorMessage("", "");
	SetInfoMessage("", "");

	NotifyStatus();

	// get a local copy of the configuration
	mCfg.CopyFrom(pConfig);

	// check the configuration
	if (!mCfg.isValid) {
		SetErrorMessage(_T("Invalid configuration"), _T("CWLANSpy::Init"));
		NotifyError();
		SetInstrumentStatus(INSTR_STATUS_DISABLED);
		NotifyStatus();
		return -1;
	}

	//localObsPeriod = mCfg.observationPeriod;
	if (mCfg.maxInstrumentDeadTime > 0)
		localTimeout = mCfg.maxInstrumentDeadTime * 1000;
	else
		localTimeout = 0;

	// get actual WZC service status
	wzcStatusAtInit = GetWZCSVCStatus();

	// check if "Wireless Zero Configuration" service is activated, stop it if so
	returnCode = StopWZCSVC();
	if (returnCode != 0) {
		SetErrorMessage(_T("Unable to stop Wireless Zero Configuration service!"), _T("CWLANSpy::Init"));
		NotifyError();
		SetInstrumentStatus(INSTR_STATUS_DISABLED);
		NotifyStatus();
		return -1;
	}

	// prepare helper
	returnCode = helper.OpenDevice(mCfg.deviceDescription);
	if (returnCode != 0) {
		// try to start the service
		returnCode = StartWZCSVC();
		if (returnCode == 0) {
			Sleep (200);
			returnCode = StopWZCSVC();
		}
		if (returnCode == 0) 
			returnCode = helper.OpenDevice(mCfg.deviceDescription);
		
		if (returnCode != 0) {
            SetErrorMessage(_T("WLAN Device not found"), _T("CWLANSpy::Init"));
			NotifyError();
			SetInstrumentStatus(INSTR_STATUS_DISABLED);
			NotifyStatus();
			return -1;
		}
	}

	SetInfoMessage(_T("Init instrument successful"), _T("CWLANSpy::Init"));
	NotifyInfo();
		
	return 0;
}

int CWLANSpy::StartMeas()
{
	// launches the measurement
	
	if (GetInstrumentStatus() == INSTR_STATUS_RUNNING)
		return 0;

	// kill any pending thread
	if (pMeasThread != NULL)
		TerminateThread(pMeasThread->m_hThread, 0);

	// launch the thread
	tsLastMeasurement = INVALIDDWORD;
	pMeasThread = AfxBeginThread(WLANSpyThreadProcedure, this, THREAD_PRIORITY_NORMAL);
	if (pMeasThread == NULL) {
		SetErrorMessage(_T("Error launching the measurement thread"), _T("CWLANSpy::StartMeasurement"));
		NotifyError();
		SetInstrumentStatus(INSTR_STATUS_DISABLED);
		NotifyStatus();
		return -1;
	}

	SetInstrumentStatus(INSTR_STATUS_RUNNING);
	NotifyStatus();

	SetInfoMessage(_T("Start measurement successful"), _T("CWLANSpy::StartMeasurement"));
	NotifyInfo();

	return 0;
}

int	CWLANSpy::StopMeas()
{
	// stops a running measurement
	int		retCode;
	CString	buffer;

	if (GetInstrumentStatus() != INSTR_STATUS_RUNNING)
		return 0;

	// Stop saving if required
	if (IsSaving())
		StopSaving();

	// set the event for the thread to terminate
	stopMeasEvent.SetEvent();

	// wait for the measurement completed event
	retCode = WaitForSingleObject(measStoppedEvent, 8000);
	if (retCode != WAIT_OBJECT_0) {
		// thread hangs has to be killed
		TerminateThread(pMeasThread->m_hThread, 0);
		SetErrorMessage(_T("Thread had to be killed"), _T("CWLANSpy::StopMeasurement"));
		NotifyError();
	}

	// clean up
	pMeasThread = NULL;

	SetInstrumentStatus(INSTR_STATUS_IDLE);
	NotifyStatus();

	SetInfoMessage(_T("Stop measurement successful"), _T("CWLANSpy::StopMeasurement"));
	NotifyInfo();

	return 0;
}

int CWLANSpy::PerformMeasurementCycle()
{
	// performs a single measurement
	int		retCode;

	BYTE		m_buffer[8192];
	int			m_bufsize;

	if (tsLastMeasurement == INVALIDDWORD)
		tsLastMeasurement = GetTickCount();

	// Timestamp
	tempResult.timestamp = GetTickCount();

	// read new measurement
	retCode = helper.GetBSSIDList(m_buffer, &m_bufsize);
	if (retCode != 0)
		return 0;

	// Create result
	tempResult.dataType = WLANSPY_RESULT_TYPE_APINFO;
	memcpy(tempResult.dataBuffer, m_buffer, m_bufsize);
	tempResult.bufferSize = m_bufsize;

	// copy the result to the output buffer
	csResult.Lock();
	mResult.CopyFrom(&tempResult);
	csResult.Unlock();

	// signal new data
	NotifyNewResult();
	tsLastMeasurement = tempResult.timestamp;

	// save the message if required
	if (IsSaving()) {
		retCode = tempResult.Save(pMeasFile);
		if (retCode != 0) {
			SetErrorMessage(_T("Error saving result"), _T("CWLANSpy::PerformMeasurementCycle"));
			NotifyError();
			return 0;
		}
	}

	SetInfoMessage(_T("Measurement loop successful"), _T("CWLANSpy::PerformMeasurementCycle"));
	NotifyInfo();

	return 0;
}

int CWLANSpy::DispatchResult(CWLANSpyResult* pResult)
{
	// copies the last result to the output
	csResult.Lock();
	pResult->CopyFrom(&mResult); 
	csResult.Unlock();

	return 0;
}

/////////////////////////////////////////////////////////////////////////////////////
// Helper functions

int CWLANSpy::GetWZCSVCStatus()
{
	int			retCode;
	CString		servicename;
	DWORD		status;

	servicename = "WZCSVC";

	retCode = svcHelper.GetStatus(servicename, &status);
	if (retCode != 0) {
		SetErrorMessage(_T("Unable to retrieve current status of Wireless Zero Configuration!"), _T("CWLANSpy::StopWZCSVC"));
		NotifyError();
		return WZC_STATUS_NOTDEFINED;
	}
	
	switch (status) {
	case SERVICE_START_PENDING:
	case SERVICE_RUNNING:
		return WZC_STATUS_RUNNING;
		break;
	case SERVICE_STOP_PENDING:
	case SERVICE_STOPPED:
		return WZC_STATUS_STOPPED;
		break;
	default:
		return WZC_STATUS_NOTDEFINED;
		break;
	}
}

int CWLANSpy::StartWZCSVC()
{
	// Stop the Wireless Zero Configuration service if it was activated
	int			retCode;
	CString		servicename;
	DWORD		status;
	DWORD		tsRef;
	DWORD		tsCur;

	CDialog		dlg;
	int			nDlgCreate;


	servicename = "WZCSVC";

	retCode = svcHelper.GetStatus(servicename, &status);
	if (retCode != 0) {
		SetErrorMessage(_T("Unable to retrieve current status of Wireless Zero Configuration!"), _T("CWLANSpy::StopWZCSVC"));
		NotifyError();
		return -1;
	}

	switch (status) {
	case SERVICE_RUNNING:
		// nothing to do
		break;

	case SERVICE_START_PENDING:
		// Show information window
		nDlgCreate = dlg.Create(IDD_STARTWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_RUNNING) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Wireless Zero Configuration service is still pending on start!"), _T("CWLANSpy::StartWZCSVC"));
			NotifyError();
			return -1;
		}

		// nothing else to do

		break;

	case SERVICE_STOP_PENDING:
		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_STOPPED) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to retrieve current status of Wireless Zero Configuration!"), _T("CWLANSpy::StartWZCSVC"));
			NotifyError();
			return -1;
		}

		// Show information window
		nDlgCreate = dlg.Create(IDD_STARTWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// stop the service
		retCode = svcHelper.Start(servicename);
		if (retCode != 0) {
			AfxMessageBox("Unable to start Wireless Zero Configuration service!");
			return -1;
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_RUNNING) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to start Wireless Zero Configuration service!"), _T("CWLANSpy::StartWZCSVC"));
			NotifyError();
			return -1;
		}

		break;

	case SERVICE_STOPPED:
		// Show information window
		nDlgCreate = dlg.Create(IDD_STARTWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// Start the service
		retCode = svcHelper.Start(servicename);
		if (retCode != 0) {
			SetErrorMessage(_T("Unable to start Wireless Zero Configuration service!"), _T("CWLANSpy::StartWZCSVC"));
			NotifyError();
			return -1;
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_RUNNING) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to start Wireless Zero Configuration service!"), _T("CWLANSpy::StartWZCSVC"));
			NotifyError();
			return -1;
		}

		break;
	}
	return 0;
}

int CWLANSpy::StopWZCSVC()
{
	// Stop the Wireless Zero Configuration service if it wax activated
	int			retCode;
	CString		servicename;
	DWORD		status;
	DWORD		tsRef;
	DWORD		tsCur;

	CDialog		dlg;
	int			nDlgCreate;


	servicename = "WZCSVC";

	retCode = svcHelper.GetStatus(servicename, &status);
	if (retCode != 0) {
		SetErrorMessage(_T("Unable to retrieve current status of Wireless Zero Configuration!"), _T("CWLANSpy::StopWZCSVC"));
		NotifyError();
		return -1;
	}

	switch (status) {
	case SERVICE_RUNNING:
		// Show information window
		nDlgCreate = dlg.Create(IDD_STOPWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// Stop the service
		retCode = svcHelper.Stop(servicename);
		if (retCode != 0) {
			SetErrorMessage(_T("Unable to stop Wireless Zero Configuration service!"), _T("CWLANSpy::StopWZCSVC"));
			NotifyError();
			return -1;
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_STOPPED) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to stop Wireless Zero Configuration service!"), _T("CWLANSpy::StopWZCSVC"));
			NotifyError();
			return -1;
		}

		break;
	case SERVICE_START_PENDING:
		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_RUNNING) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to retrieve current status of Wireless Zero Configuration!"), _T("CWLANSpy::StopWZCSVC"));
			NotifyError();
			return -1;
		}

		// Show information window
		nDlgCreate = dlg.Create(IDD_STOPWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// stop the service
		retCode = svcHelper.Stop(servicename);
		if (retCode != 0) {
			AfxMessageBox("Unable to stop Wireless Zero Configuration service!");
			return -1;
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_STOPPED) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Unable to stop Wireless Zero Configuration service!"), _T("CWLANSpy::StopWZCSVC"));
			NotifyError();
			return -1;
		}

		break;
	case SERVICE_STOP_PENDING:
		// Show information window
		nDlgCreate = dlg.Create(IDD_STOPWZCSVC_DLG);
		if (nDlgCreate != 0) {
			dlg.ShowWindow(SW_SHOW);
			dlg.UpdateWindow();
		}

		// get the service status
		tsRef = GetTickCount();
		do {
			// get the service status
			retCode = svcHelper.GetStatus(servicename, &status);
			if (retCode != 0) {
				retCode = -1;
				break;
			}
			if (status == SERVICE_STOPPED) {
				retCode = 0;
				break;
			}
			Sleep(100);

			retCode = -1;
			tsCur = GetTickCount();
		} while (tsCur - tsRef < 8000);

		// Close information window
		if (nDlgCreate != 0)
			dlg.DestroyWindow();

		if (retCode != 0) {
			SetErrorMessage(_T("Wireless Zero Configuration service is still pending on stop!"), _T("CWLANSpy::StopWZCSVC"));
			NotifyError();
			return -1;
		}

		// nothing else to do

		break;
	case SERVICE_STOPPED:
		// nothing to do
		break;
	}
	return 0;
}
