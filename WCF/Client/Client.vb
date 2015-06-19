Imports System.Threading
Imports System.ServiceModel

Public Class Client

    Private Sub btnCallMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCallMethod.Click
        Try
            Dim epAddress As EndpointAddress = New EndpointAddress("http://localhost:8000/Prudential/TestWCF/TransferService")
            Dim Client As TransferClient = New TransferClient(New WSHttpBinding(), epAddress)
            Dim t As String = ""
            Client.Transfer(TextBox1.Text, t)
            TextBox2.Text = t
            Client.Close()
        Catch ce As CommunicationException
            MessageBox.Show("An error occurred: " & ce.Message)
        End Try
    End Sub

    Private Sub Client_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = DateTime.Now.ToLongDateString()
    End Sub

End Class
