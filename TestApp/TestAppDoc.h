
// TestAppDoc.h : interface of the CTestAppDoc class
//


#pragma once


class CTestAppDoc : public CDocument
{
protected: // create from serialization only
	CTestAppDoc();
	DECLARE_DYNCREATE(CTestAppDoc)

// Attributes
public:

// Operations
public:

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CTestAppDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


