
// TestAppDoc.cpp : implementation of the CTestAppDoc class
//

#include "stdafx.h"
#include "TestApp.h"

#include "TestAppDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTestAppDoc

IMPLEMENT_DYNCREATE(CTestAppDoc, CDocument)

BEGIN_MESSAGE_MAP(CTestAppDoc, CDocument)
END_MESSAGE_MAP()


// CTestAppDoc construction/destruction

CTestAppDoc::CTestAppDoc()
{
	// TODO: add one-time construction code here

}

CTestAppDoc::~CTestAppDoc()
{
}

BOOL CTestAppDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CTestAppDoc serialization

void CTestAppDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}


// CTestAppDoc diagnostics

#ifdef _DEBUG
void CTestAppDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTestAppDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CTestAppDoc commands
