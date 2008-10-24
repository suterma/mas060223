// WLANSpyHelpers.cpp: implementation of the CWLANSpyHelpers class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "WLANSpyHelpers.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWLANSpyHelpers::CWLANSpyHelpers()
{
	deviceDescription.Empty();
	deviceName.Empty();
}

CWLANSpyHelpers::~CWLANSpyHelpers()
{
	
}

/////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////
// Initialization functions
//

int CWLANSpyHelpers::LookupDevice(WCHAR* lpwsWantedDevDescript, WCHAR* lpwsDevDescript, WCHAR* lpwsDevName)
{
	int					i;
	BOOL				devFoundFlag;
	long				nbNdisDev = 0;
	HRESULT				hRes;
	WRAPI_NDIS_DEVICE*	pDeviceList[16];

	// Memory allocation
	for(i=0; i<16; i++)
		pDeviceList[i] = new WRAPI_NDIS_DEVICE;

	// Get the list of Devices in the System
	hRes = m_device.EnumerateDevices(pDeviceList, &nbNdisDev);
	if (hRes != 0)
		return -1;

	/* Print the list of devices obtained */
	devFoundFlag = FALSE;
	for (i = 0; i < nbNdisDev; i++) {
		TRACE ("%ws - %ws\r\n", pDeviceList[i]->deviceDescription, pDeviceList[i]->deviceName);
		if (wcsstr(pDeviceList[i]->deviceDescription, lpwsWantedDevDescript) != NULL) {
			wcscpy(lpwsDevDescript, pDeviceList[i]->deviceDescription);
			wcscpy(lpwsDevName, pDeviceList[i]->deviceName);
			devFoundFlag = TRUE;
			break;
		}
	}

	// Clean up
	for(i=0; i<16; i++)
		delete pDeviceList[i];

	if (!devFoundFlag)
		return -1;

	return 0;
}

int CWLANSpyHelpers::OpenDevice(CString szDeviceDescription)
{
	BOOL			ok;
	HRESULT			hRes;
	int				retCode;
	int				i;

	LPWSTR	lpwsWantedDevDescript = new WCHAR[255];
	LPWSTR	lpwsDevDescript	= new WCHAR[255];
	LPWSTR	lpwsDevName	= new WCHAR[255];
	LPTSTR	lpszWantedDevDescript = NULL;
	int		nLen = 0;

	// Init device
	ok = m_device.InitInstance();
	if (!ok) {
		delete[] lpwsWantedDevDescript;
		delete[] lpwsDevDescript;
		delete[] lpwsDevName;
		return -1;
	}

	// Convert CString to WCHAR*
	lpszWantedDevDescript	= szDeviceDescription.GetBuffer(szDeviceDescription.GetLength());
	nLen					= MultiByteToWideChar(CP_ACP, 0,lpszWantedDevDescript, -1, NULL, NULL);
	MultiByteToWideChar(CP_ACP, 0, 	lpszWantedDevDescript, -1, lpwsWantedDevDescript, nLen);

	// Check if a device corresponds to the given description
	retCode = LookupDevice(lpwsWantedDevDescript, lpwsDevDescript, lpwsDevName);
	if (retCode != 0) {
		delete[] lpwsWantedDevDescript;
		delete[] lpwsDevDescript;
		delete[] lpwsDevName;
		return -1;
	}

	// Copy results to strings
	deviceDescription.Empty();
	deviceName.Empty();
	for (i=0; i<int(wcslen(lpwsDevDescript)); i++)
		deviceDescription += (char)lpwsDevDescript[i];
	for (i=0; i<int(wcslen(lpwsDevName)); i++)
		deviceName += (char)lpwsDevName[i];

	// Open the device
	hRes = m_device.OpenNdisDevice(lpwsDevName);

	delete[] lpwsWantedDevDescript;
	delete[] lpwsDevDescript;
	delete[] lpwsDevName;

	return hRes;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
// read functions


int CWLANSpyHelpers::GetSSID(CString* ssid) {

	int				i;
	HRESULT			hRes;
	UCHAR			m_ssid[32] = {0};
	CString			m_szSsid;

	/* Get the SSID Of the Network */
	hRes = m_device.GetSSId(m_ssid);

	if (hRes != 0)
		return -1;

	// Copy SSID of current associated AP
	m_szSsid.Empty();
	for (i=0; i<(int)strlen((char*)m_ssid); i++) {
		m_szSsid += (char)m_ssid[i];
	}
	*ssid = m_szSsid;

	return 0;
}

int CWLANSpyHelpers::GetRTSThreshold() {

	HRESULT			hRes;
	ULONG			lRTSThresh = 0;

	/* Get the value of RTS Threshold */
	hRes = m_device.GetRTSThreshold(&lRTSThresh);

	return hRes;
}

int CWLANSpyHelpers::GetAssociatedAP(char* address) {

	HRESULT			hRes;
	MAC_ADDR		m_addr = {0};

	/* Get the MAC address of the AP to which this station is associated */
	hRes = m_device.GetAssociatedAP(m_addr);

	if (hRes != 0)
		return -1;

	// copy MAC Address
	for (int i=0; i<6; i++) {
		address[i] = (char)m_addr[i];
	}

	return 0;
}

int CWLANSpyHelpers::GetInterfaceStats() {

	HRESULT			hRes;
	DOT_11_STATS	DOT11Stats;

	/* Get Packet-level statistics from the 802.11 interface */
	hRes = m_device.GetPacketStats(&DOT11Stats);

	return hRes;
}

int CWLANSpyHelpers::GetBSSIDList(BYTE* buffer, int* bufsize) {

	HRESULT			hRes;
	int				m_bufsize = 0;

	/* Get a list of all BSSIDs within range of this station in a list of BSSID_DATA
	 * structures */
	hRes = m_device.GetBSSIDList(buffer, &m_bufsize);
	if (hRes != 0)
		return -1;

	*bufsize = int(m_bufsize);

	return 0;
}

