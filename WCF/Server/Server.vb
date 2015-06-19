Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Threading
Imports System.ServiceModel
Imports System.ServiceModel.Description

'svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/Prudential/TestWCF

Public Class Server
    Implements ITransfer

    Private Shared sharedInstance As Server = Nothing
    Private baseAddress As New Uri("http://localhost:8000/Prudential/TestWCF")
    Private selfHost As New ServiceHost(GetType(Server), baseAddress)
    Private Delegate Sub SetTextDelegate(ByVal s As String)
    Private demoThread As Thread = Nothing
    Private wcfThread As Thread = Nothing
    Private Shared f As String = ""

    'Private Sub SetText(ByVal s As String)
    'If tbData.InvokeRequired Then
    's = "[invoke]" & s
    'Dim d As New SetTextDelegate(AddressOf SetText)
    'Me.Invoke(d, New Object() {s})
    'Else
    'tbData.Text = "[no invoke]" & s
    'End If
    'MessageBox.Show(tbData.Text)
    'End Sub

    Private Sub btnSetText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetText.Click
        'demoThread = New Thread(New ThreadStart(AddressOf Me.ThreadProc))
        'demoThread.Start()
    End Sub

    Private Sub btnDirect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirect.Click
        MessageBox.Show(tbData.Handle.ToString())
        tbData.Text = "TEST " & tbData.Text
    End Sub

    'Private Sub ThreadProc()
    'Me.SetText("Thread/Invoke setting text")
    'End Sub

    Public Sub Transfer(ByVal s As String, ByRef t As String) Implements ITransfer.Transfer
        'If tbData.InvokeRequired Then
        'Dim d As New SetTextDelegate(AddressOf SetText)
        'Me.Invoke(d, New Object() {s})
        'Else
        'SetText(s)
        'End If
        sharedInstance.tbData.Text = s.ToUpper()
        f = f & ";" & s.ToUpper()
        t = sharedInstance.tbData.Text
        Application.DoEvents()
    End Sub

    Private Sub InitService()
        Try
            selfHost.AddServiceEndpoint(GetType(ITransfer), New WSHttpBinding(), "TransferService")
            Dim smb As New ServiceMetadataBehavior()
            smb.HttpGetEnabled = True
            selfHost.Description.Behaviors.Add(smb)
            selfHost.Open()
        Catch ce As CommunicationException
            MessageBox.Show(String.Format("An exception occurred: {0}", ce.Message))
            selfHost.Abort()
        End Try
    End Sub

    Private Sub Server_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'wcfThread = New Thread(New ThreadStart(AddressOf InitService))
        'wcfThread.Start()
        InitService()
        If sharedInstance Is Nothing Then sharedInstance = Me
    End Sub

    Private Sub Server_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Application.DoEvents()
            selfHost.Close()
            Application.DoEvents()
        Catch ce As CommunicationException
            MessageBox.Show(String.Format("An exception occurred: {0}", ce.Message))
            selfHost.Abort()
        End Try
    End Sub

    Private Sub btnShowText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowText.Click
        MessageBox.Show(tbData.Text)
    End Sub

End Class

<ServiceContract(Namespace:="http://Prudential.TestWCF")> _
Public Interface ITransfer
    <OperationContract()> _
    Sub Transfer(ByVal s As String, ByRef t As String)
End Interface
