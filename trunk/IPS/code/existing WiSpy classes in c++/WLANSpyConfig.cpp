// WLANSpyConfig.cpp: implementation of the CWLANSpyConfig class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "WLANSpyConfig.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWLANSpyConfig::CWLANSpyConfig()
{
	Init();
}

CWLANSpyConfig::~CWLANSpyConfig()
{

}

void CWLANSpyConfig::Init()
{
	// sets all parameters to a defined state

	idleTime				= 10;
	isValid					= FALSE;
	maxInstrumentDeadTime	= 0;

	deviceDescription.Empty();
	
	ResetErrorMessage();
	ResetInfoMessage();
}

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////
// Copy/Check function
int CWLANSpyConfig::CheckValid()
{
	// checks whether the configuration makes sense
	// sets the isValid flag
	// returns 0 in any case

	isValid = TRUE;

	// check general parameters
	idleTime = __max(10, idleTime);

	// check deviceDescription
	if (deviceDescription.IsEmpty())
		isValid = FALSE;

	return 0;
}

int CWLANSpyConfig::CopyFrom(CWLANSpyConfig* pConf)
{
	Init();

	idleTime				= pConf->idleTime;
	maxInstrumentDeadTime	= pConf->maxInstrumentDeadTime;

	deviceDescription				= pConf->deviceDescription;

	CheckValid();

	return 0;
}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
// Load/Save handlers

int CWLANSpyConfig::Load(CConfigFile* pFile, int taskIndex)
{
	// loads the entire configuration from the file and checks the validity
	CString		section;
	DWORD		retCode;

	int			localInt;
	CString		localStr;

	Init();

	if (taskIndex == -1) 
		section = "WLANSPY";
	else
		section.Format("WLANSPY%d", taskIndex);

	// load idleTime
	retCode = pFile->ReadConfig(section, "idleTime", &localInt);
	if (retCode != 0) {
		SetErrorMessage(_T("Error reading idleTime"), _T("CWLANSpyConfig::Load"));
		return -1;
	}
	idleTime = localInt;
	
	// load maxInstrumentDeadTime
	retCode = pFile->ReadConfig(section, "maxInstrumentDeadTime", &localInt);
	if (retCode != 0) {
		SetErrorMessage(_T("Error reading maxInstrumentDeadTime"), _T("CWLANSpyConfig::Load"));
		return -1;
	}
	maxInstrumentDeadTime = localInt;

	// load deviceDescription
	retCode = pFile->ReadConfig(section, "deviceDescription", &localStr);
	if (retCode != 0) {
		SetErrorMessage(_T("Error reading deviceDescription"), _T("CWLANSpyConfig::Load"));
		return -1;
	}
	deviceDescription = localStr;
	
	CheckValid();
	return 0;
}

int CWLANSpyConfig::Save(CConfigFile* pFile, int taskIndex)
{
	// saves the entire configuration to the file
	CString		section;
	DWORD		retCode;

	if (taskIndex == -1) 
		section = "WLANSPY";
	else
		section.Format("WLANSPY%d", taskIndex);

	// save idleTime
	retCode = pFile->WriteConfig(section, "idleTime", int(idleTime));
	if (retCode != 0) {
		SetErrorMessage(_T("Error writing idleTime"), _T("CWLANSpyConfig::Save"));
		return -1;
	}

	
	// save maxInstrumentDeadTime
	retCode = pFile->WriteConfig(section, "maxInstrumentDeadTime", maxInstrumentDeadTime);
	if (retCode != 0) {
		SetErrorMessage(_T("Error writing maxInstrumentDeadTime"), _T("CWLANSpyConfig::Save"));
		return -1;
	}

	// save deviceDescription
	retCode = pFile->WriteConfig(section, "deviceDescription", deviceDescription);
	if (retCode != 0) {
		SetErrorMessage(_T("Error writing deviceDescription"), _T("CWLANSpyConfig::Save"));
		return -1;
	}

	return 0;
}