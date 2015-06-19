Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO
Imports System.IO.Pipes

Public Class PipeReceive

    Private Shared pipe As NamedPipeClientStream
    Private Shared evtDataReady As New EventWaitHandle(False, EventResetMode.AutoReset, "DataReady")
    Private Shared evtDataReceived As EventWaitHandle

    Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub btnStartReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartReceive.Click

        Dim newThread As New Thread(New ThreadStart(AddressOf WaitForData))
        newThread.Start()

    End Sub

    Public Sub WaitForData()

        evtDataReady.WaitOne()
        pipe = New NamedPipeClientStream(".", "mypipe", PipeDirection.In)
        pipe.Connect()
        Using sr As StreamReader = New StreamReader(pipe)
            Dim pipeData As String = sr.ReadLine()
            While pipeData IsNot Nothing
                SetText(pipeData)
                pipeData = sr.ReadLine()
            End While
        End Using
        Try
            evtDataReceived = EventWaitHandle.OpenExisting("DataReceived")
        Catch ex As Exception
            evtDataReceived = New EventWaitHandle(False, EventResetMode.AutoReset, "DataReceived")
        End Try
        evtDataReceived.Set()

    End Sub

    Private Sub SetText(ByVal text As String)

        If Me.tbData.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.tbData.Text = [text]
        End If
    End Sub

End Class

