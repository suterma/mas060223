// WLANSpyHelpers.h: interface for the CWLANSpyHelpers class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WLANSPYHELPERS_H__798983F2_ECA6_11D6_8EC3_000102124DFC__INCLUDED_)
#define AFX_WLANSPYHELPERS_H__798983F2_ECA6_11D6_8EC3_000102124DFC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "WRAPI.h"

class CWLANSpyHelpers  
{
public:
	CWLANSpyHelpers();
	virtual ~CWLANSpyHelpers();

public:
	int		LookupDevice(WCHAR* lpwsWantedDevDescript, WCHAR* lpwsDevDescript, WCHAR* lpwsDevName);
	int		OpenDevice(CString szDeviceDescription);
	
	int		GetBSSIDList(BYTE* buffer, int* bufsize);
	int		GetSSID(CString* ssid);
	int		GetRTSThreshold();
	int		GetAssociatedAP(char* address);
	int		GetInterfaceStats();

public:
	CString	deviceDescription;
	CString	deviceName;

private:
	CWRAPI	m_device;

};

#endif // !defined(AFX_WLANSPYHELPERS_H__798983F2_ECA6_11D6_8EC3_000102124DFC__INCLUDED_)
