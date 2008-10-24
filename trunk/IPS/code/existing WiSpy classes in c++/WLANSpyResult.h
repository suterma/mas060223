// WLANSpyResult.h: interface for the CWLANSpyResult class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WLANSPYRESULT_H__EFE21B52_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
#define AFX_WLANSPYRESULT_H__EFE21B52_ECE4_11D6_8EC5_000102124DFC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// add by ZAR 2005.19.1
#ifndef ULONG_PTR
#define ULONG_PTR unsigned long*
#endif
//it may be  solved by include basetsd.h

#include <afxtempl.h>
#include "Result.h"

#include "APInfo.h"

#include "ntddndis.h"
#include "nuiouser.h"

#define WLANSPY_RESULT_TYPE_NONE		0
#define WLANSPY_RESULT_TYPE_APINFO		1

#define BSSID_TYPE_AP					1
#define BSSID_TYPE_P2P					2

// see 802.11-1999, section 7.3.1.4
#define CAPABILITY_INFO_FIELD_ESS_MASK	1		// if set to 1: AP
#define CAPABILITY_INFO_FIELD_IBSS_MASK	2		// is set to 1: P2P


class CWLANSpyResult : public CResult  
{
public:
	CWLANSpyResult();
	virtual ~CWLANSpyResult();

public:
	int		Save(CMeasFile* pFile);
	int		Load(CMeasFile* pFile);
	void	Init();

	void	CopyFrom(CWLANSpyResult* result);

	void	ExtractAPInfo(); 

public:
	BYTE	dataType;
	int		bufferSize;
	BYTE	dataBuffer[8192];

	CArray <CAPInfo, CAPInfo>	apInfoArray;
	
};

#endif // !defined(AFX_WLANSPYRESULT_H__EFE21B52_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
