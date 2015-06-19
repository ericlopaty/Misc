
// TestAppView.cpp : implementation of the CTestAppView class
//

#include "stdafx.h"
#include "TestApp.h"

#include "TestAppDoc.h"
#include "TestAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTestAppView

IMPLEMENT_DYNCREATE(CTestAppView, CView)

BEGIN_MESSAGE_MAP(CTestAppView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CTestAppView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CTestAppView construction/destruction

CTestAppView::CTestAppView()
{
	// TODO: add construction code here

}

CTestAppView::~CTestAppView()
{
}

BOOL CTestAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CTestAppView drawing

void CTestAppView::OnDraw(CDC* /*pDC*/)
{
	CTestAppDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CTestAppView printing


void CTestAppView::OnFilePrintPreview()
{
	AFXPrintPreview(this);
}

BOOL CTestAppView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTestAppView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTestAppView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CTestAppView::OnRButtonUp(UINT nFlags, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CTestAppView::OnContextMenu(CWnd* pWnd, CPoint point)
{
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
}


// CTestAppView diagnostics

#ifdef _DEBUG
void CTestAppView::AssertValid() const
{
	CView::AssertValid();
}

void CTestAppView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CTestAppDoc* CTestAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTestAppDoc)));
	return (CTestAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CTestAppView message handlers
