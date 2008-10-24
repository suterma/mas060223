// WLANSpyResult.cpp: implementation of the CWLANSpyResult class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "WLANSpyResult.h"
#include <math.h>

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWLANSpyResult::CWLANSpyResult()
{
	Init();
}

CWLANSpyResult::~CWLANSpyResult()
{

}

void CWLANSpyResult::Init()
{
	dataType = WLANSPY_RESULT_TYPE_NONE;

	bufferSize = 0;
	memset(dataBuffer, NULL, 8192);

	apInfoArray.RemoveAll();
}

void CWLANSpyResult::CopyFrom(CWLANSpyResult* result)
{
	Init();	

	dataType	= result->dataType;
	bufferSize	= result->bufferSize;

	// Copy result buffer
	memcpy(dataBuffer, result->dataBuffer, sizeof(dataBuffer));
}

void CWLANSpyResult::ExtractAPInfo()
{
	DWORD			dd1;
	DWORD			dd2;
	int				nnn;
	int				x, y;
	int				i, j;

	int				nbOfItems;
	int				offset;
	long			invalidDatCnt;
	WORD			capabilities;

	CAPInfo			m_apInfo, m_apInfo1, m_apInfo2;

	BYTE						m_dataBuffer[8192];
	PNDIS_802_11_BSSID_LIST_EX	pBssid_List;
	PNDIS_WLAN_BSSID_EX 		m_pBssid;
	PNDIS_802_11_FIXED_IEs		m_FIXED_IEs;

	// Init
	apInfoArray.RemoveAll();

	if (dataType != WLANSPY_RESULT_TYPE_APINFO)
		return;

	// Get BSSId Results
	pBssid_List = (PNDIS_802_11_BSSID_LIST_EX)dataBuffer;

	// Get number of BSSId results
	nbOfItems = (int)pBssid_List->NumberOfItems;

	// BSSId result begins after the 4th byte: 1st to 4th represents "nbOfItems"
	memcpy(m_dataBuffer, &dataBuffer[4], 8192);

	// Assign results to BSSID_DATA structures
	offset = 0;
	invalidDatCnt = 0;
	for (i=0; i<nbOfItems; i++)
	{
		m_apInfo.Init();

		// Get next BSSId result contained in DataBuffer
		m_pBssid = (PNDIS_WLAN_BSSID_EX) &m_dataBuffer[offset];

		// copy length
		m_apInfo.length				= m_pBssid->Length;

		// verify validity data
		if (m_pBssid->Length < 1) {
			invalidDatCnt++;
			continue;
		}

		// MAC Address
		memcpy(m_apInfo.macAddress, m_pBssid->MacAddress, 6);

		// SSID
		m_apInfo.ssidLength			= m_pBssid->Ssid.SsidLength;
		for (j=m_pBssid->Ssid.SsidLength - 1; j>=0; j--) {
			if (m_pBssid->Ssid.Ssid[j] == 0)
				m_apInfo.ssidLength--;
		}
		memcpy(m_apInfo.ssid, m_pBssid->Ssid.Ssid, m_pBssid->Ssid.SsidLength);

		// Privacy
		m_apInfo.privacy			= m_pBssid->Privacy;

		// RSSI
		m_apInfo.rssi				= m_pBssid->Rssi;

		// Network type in use
		m_apInfo.networkTypeInUse	= m_pBssid->NetworkTypeInUse;

		// Configuration
		m_apInfo.configLength		= (DWORD)m_pBssid->Configuration.Length;
		m_apInfo.configBeaconPeriod	= (DWORD)m_pBssid->Configuration.BeaconPeriod;
		m_apInfo.configATIMWindow	= (DWORD)m_pBssid->Configuration.ATIMWindow;
		m_apInfo.configDSConfig		= (DWORD)m_pBssid->Configuration.DSConfig;	// given in KHz

		// Calculate channel number
		m_apInfo.channelNumber		= (((int)m_apInfo.configDSConfig - 2412000)/5000) + 1;

		// FH Configuration
		m_apInfo.configFHLength		= (DWORD)m_pBssid->Configuration.FHConfig.Length;
		m_apInfo.configFHHopPattern	= (DWORD)m_pBssid->Configuration.FHConfig.HopPattern;
		m_apInfo.configFHHopSet		= (DWORD)m_pBssid->Configuration.FHConfig.HopSet;
		m_apInfo.configFHDwellTime	= (DWORD)m_pBssid->Configuration.FHConfig.DwellTime;

		// InfrastructureMode
		m_apInfo.infrastructureMode	= m_pBssid->InfrastructureMode;

		// SupportedRates
		memcpy(m_apInfo.supportedRates, m_pBssid->SupportedRates, NDIS_802_11_LENGTH_RATES_EX);

		// Get last result timstamp
		m_FIXED_IEs = (PNDIS_802_11_FIXED_IEs)m_pBssid->IEs;
		dd1 = *(DWORD*)&m_FIXED_IEs->Timestamp[0];
		dd2 = *(DWORD*)&m_FIXED_IEs->Timestamp[4];
		
		// Get capabilities and determine BSSID type: AP or P2P?
		capabilities = (WORD)m_FIXED_IEs->Capabilities;
		capabilities &= 31;		// take only the 5 first bits
		if (capabilities & CAPABILITY_INFO_FIELD_ESS_MASK)
			m_apInfo.apType = BSSID_TYPE_AP;
		if (capabilities & CAPABILITY_INFO_FIELD_IBSS_MASK)
			m_apInfo.apType = BSSID_TYPE_P2P;

		// Convert timestamp to double
	//	m_apInfo.timestamp = pow(2, 32)*dd2 + dd1;
		m_apInfo.timestamp = 65536.0 * 65536.0 * dd2 + dd1;

		// Add info to APInfo array
		apInfoArray.Add(m_apInfo);

		// set offset for next BSSId result
		offset += m_pBssid->Length;
	}

	// Order AP info by channel
	nnn = apInfoArray.GetSize();

	for (i=0; i<nnn; i++) {
		for (j=i; j<nnn; j++) {
			m_apInfo1.Init();
			m_apInfo1 = apInfoArray.GetAt(i);
			x = (int)m_apInfo1.configDSConfig;
			m_apInfo2.Init();
			m_apInfo2 = apInfoArray.GetAt(j);
			y = (int)m_apInfo2.configDSConfig;
			if (y < x) {
				apInfoArray.SetAt(i, m_apInfo2);
				apInfoArray.SetAt(j, m_apInfo1);
			}
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
// Load/Save handler

int	CWLANSpyResult::Load(CMeasFile* pFile)
{
	DWORD	tempDword;
	WORD	tempWord;
	BYTE	tempByte;
	DWORD	nbBytesRead;
	DWORD	nnn;

	WORD	messageSize = 0;
	BYTE	messageType;

	messageType		= 0x6E;

	// read standard parameters

	// messageSize
	nnn = pFile->Read(&tempWord, sizeof(WORD));
	if (nnn != sizeof(WORD))
		return -1;
	messageSize = tempWord;

	// timestamp
	nnn = pFile->Read(&tempDword, sizeof(DWORD));
	if (nnn != sizeof(DWORD))
		return -1;
	timestamp = tempDword;

	// messageType
	nnn = pFile->Read(&tempByte, sizeof(BYTE));
	if (nnn != sizeof(BYTE))
		return -1;
	if (messageType != tempByte)
		return -1;

	///////////////////////////////////////////////
	///////////////////////////////////////////////
	// specific part

	nbBytesRead = 0;
	
	// read dataType
	nnn = pFile->Read(&tempByte, sizeof(BYTE));
	if (nnn != sizeof(BYTE))
		return -1;
	nbBytesRead += nnn;
	dataType = tempByte;

	// read bufferSize
	nnn = pFile->Read(&tempDword, sizeof(DWORD));
	if (nnn != sizeof(DWORD))
		return -1;
	nbBytesRead += nnn;
	bufferSize = tempDword;

	if (bufferSize > 0) {
		// read dataBuffer
		nnn = pFile->Read(dataBuffer, bufferSize);
		if (nnn != (DWORD)bufferSize)
			return -1;
		nbBytesRead += nnn;
	}

	// final check
	if (nbBytesRead != messageSize)
		return -1;

	return 0;


}

int	CWLANSpyResult::Save(CMeasFile* pFile)
{
	BOOL	ok;
	WORD	messageSize;
	BYTE	messageType;
	WORD	nbBytesSaved;

	BYTE	tempByte;
	DWORD	tempDword;

	messageSize		= 5 + bufferSize;
	messageType		= 0x6E;
	nbBytesSaved	= 0;

	// save standard parameters

	// write length
	pFile->csFile.Lock();
	ok = pFile->Write(&messageSize, sizeof(WORD));
	if (!ok) 
		return -1;

	// write timestamp
	ok = pFile->Write(&timestamp, sizeof(DWORD));
	if (!ok)
		return -1;

	// write data type
	ok = pFile->Write(&messageType, sizeof(BYTE));
	if (!ok)
		return -1;

	///////////////////////////////////////////////
	///////////////////////////////////////////////
	// specific part

	// write dataType
	tempByte = (BYTE)dataType;
	ok = pFile->Write(&tempByte, sizeof(BYTE));
	if (!ok)
		return -1;
	nbBytesSaved += sizeof(BYTE);
	
	// write bufferSize
	tempDword = (DWORD)bufferSize;
	ok = pFile->Write(&tempDword, sizeof(DWORD));
	if (!ok)
		return -1;
	nbBytesSaved += sizeof(DWORD);

	if (bufferSize > 0) {
		// write dataBuffer
		ok = pFile->Write(dataBuffer, bufferSize);
		if (!ok)
			return -1;
		nbBytesSaved += bufferSize;
	}

	pFile->csFile.Unlock();
		
	// final check
	if (nbBytesSaved != messageSize)
		return -1;

	return 0;
}