VERSION 5.00
Object = "{009541A3-3B81-101C-92F3-040224009C02}#3.2#0"; "Imgadmin.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   7605
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7785
   LinkTopic       =   "Form1"
   ScaleHeight     =   7605
   ScaleWidth      =   7785
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Command2"
      Height          =   495
      Left            =   1440
      TabIndex        =   3
      Top             =   180
      Width           =   1215
   End
   Begin VB.PictureBox Picture1 
      Height          =   2895
      Left            =   240
      ScaleHeight     =   2835
      ScaleWidth      =   5115
      TabIndex        =   2
      Top             =   3600
      Width           =   5175
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   180
      Width           =   1215
   End
   Begin VB.PictureBox picDocument 
      Height          =   2235
      Left            =   120
      ScaleHeight     =   2175
      ScaleWidth      =   4275
      TabIndex        =   0
      Top             =   780
      Width           =   4335
   End
   Begin AdminLibCtl.ImgAdmin ImgAdmin1 
      Left            =   5460
      Top             =   1680
      _Version        =   196610
      _ExtentX        =   656
      _ExtentY        =   444
      _StockProps     =   0
      PrintStartPage  =   0
      PrintEndPage    =   0
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Command1_Click()

    picDocument.AutoRedraw = True
    picDocument.AutoSize = True
    picDocument.BackColor = vbWhite
    picDocument.FontName = "MS Sans Serif"
    picDocument.FontBold = False
    picDocument.FontSize = 10
    picDocument.Width = 8200 '9732
    picDocument.Height = 10500 '13000
    
    Dim i As Integer
    For i = 1 To 10
        picDocument.Print "Hello" & i
        Picture1.Print "Hello" & i
    Next
    SavePicture picDocument.Image, "c:\temp\document.bmp"
    SavePicture Picture1.Image, "c:\temp\picture1.bmp"
            
End Sub

Private Sub Command2_Click()

    Dim strCoverPageName As String
    strCoverPageName = "C:\Documents and Settings\x155224\Local Settings\Temp\CoverPage13-01-31-943.BMP"

    ImgAdmin1.Image = strCoverPageName
    
End Sub
