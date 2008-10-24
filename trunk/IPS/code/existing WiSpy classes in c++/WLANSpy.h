// WLANSpy.h: interface for the CWLANSpy class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WLANSPY_H__EFE21B53_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
#define AFX_WLANSPY_H__EFE21B53_ECE4_11D6_8EC5_000102124DFC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "Resource.h"	// in order to acces to dialog windows (WZCSVC)

#include "Instrument.h"
#include "WLANSpyConfig.h"
#include "WLANSpyResult.h"
#include "WLANSpyHelpers.h"
#include "ServiceHelper.h"


class CWLANSpy : public CInstrument  
{
public:
	CWLANSpy();
	virtual ~CWLANSpy();

public:
	int	Init(CWLANSpyConfig* pConfig);			// initializes a new measurement
	int	StartMeas();								// starts the measurement process
	int	StopMeas();									// stops the measurement process
	int	PerformMeasurementCycle();					// performs a single measurement
	int	DispatchResult(CWLANSpyResult* pResult);

public:
	CWLANSpyConfig	mCfg;

private:
	int	GetWZCSVCStatus();
	int	StartWZCSVC();
	int	StopWZCSVC();

private:
	int			wzcStatusAtInit;

	enum {WZC_STATUS_NOTDEFINED, WZC_STATUS_STOPPED, WZC_STATUS_RUNNING};

	CWLANSpyResult		mResult;			// used for the transfer to the outside world
	CWLANSpyResult		tempResult;			// used only within MeasurementLoop

	CWLANSpyHelpers		helper;
	CServiceHelper		svcHelper;

};

#endif // !defined(AFX_WLANSPY_H__EFE21B53_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
