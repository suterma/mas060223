// WLANSpyConfig.h: interface for the CWLANSpyConfig class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WLANSPYCONFIG_H__EFE21B50_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
#define AFX_WLANSPYCONFIG_H__EFE21B50_ECE4_11D6_8EC5_000102124DFC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "Config.h"

class CWLANSpyConfig : public CConfig  
{
public:
	CWLANSpyConfig();
	virtual ~CWLANSpyConfig();

	void	Init();
	int		Load(CConfigFile* pFile, int taskIndex);		// taskIndex = -1 for global instruments
	int		Save(CConfigFile* pFile, int taskIndex);		// taskIndex = -1 for global instruments

	int		CopyFrom(CWLANSpyConfig* pConf);
	int		CheckValid();

public:
	CString	deviceDescription;

};

#endif // !defined(AFX_WLANSPYCONFIG_H__EFE21B50_ECE4_11D6_8EC5_000102124DFC__INCLUDED_)
