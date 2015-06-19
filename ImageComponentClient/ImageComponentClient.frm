VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3090
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3090
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CheckBox Check1 
      Caption         =   "Show Viewer"
      Height          =   495
      Left            =   180
      TabIndex        =   5
      Top             =   2400
      Width           =   1815
   End
   Begin VB.CommandButton Command5 
      Caption         =   "Zoom Out"
      Height          =   495
      Left            =   1560
      TabIndex        =   4
      Top             =   900
      Width           =   1215
   End
   Begin VB.CommandButton Command4 
      Caption         =   "Zoom In"
      Height          =   495
      Left            =   1560
      TabIndex        =   3
      Top             =   300
      Width           =   1215
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Prev Page"
      Height          =   495
      Left            =   240
      TabIndex        =   2
      Top             =   1500
      Width           =   1215
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Next Page"
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   900
      Width           =   1215
   End
   Begin MSComDlg.CommonDialog commonDialog 
      Left            =   3720
      Top             =   2280
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Load File"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   300
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'Dim server As ImageDisplayServer.ViewController
Dim server As Object


Private Sub Check1_Click()

    If Check1.Value = vbChecked Then
        server.showviewer
    Else
        server.hideviewer
    End If
    
End Sub

Private Sub Command1_Click()

commonDialog.Filter = "Tif Files (*.tif)|*.tif"
commonDialog.InitDir = "r:\eric\tif_files"
commonDialog.CancelError = True
On Error Resume Next
commonDialog.ShowOpen
If Err.Number = 0 Then
    server.loadfile commonDialog.FileName
End If

End Sub

Private Sub Command2_Click()

server.nextpage

End Sub

Private Sub Command3_Click()

server.prevpage

End Sub

Private Sub Command4_Click()

server.zoomin

End Sub

Private Sub Command5_Click()

server.zoomout

End Sub

Private Sub Form_Load()
'Set server = New ImageDisplayServer.ViewController
Set server = CreateObject("ImageDisplayServer.ViewController")
End Sub
