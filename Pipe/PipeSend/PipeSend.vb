Imports System.Threading
Imports System.IO
Imports System.IO.Pipes

Public Class PipeSend

    Public Shared pipe As NamedPipeServerStream
    Public Shared evtDataReady As EventWaitHandle = Nothing
    Public Shared evtDataReceived As New EventWaitHandle(False, EventResetMode.AutoReset, "DataReceived")

    Private Sub btnSendData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendData.Click

        If evtDataReady IsNot Nothing Then
            pipe = New NamedPipeServerStream("mypipe", PipeDirection.Out)
            If evtDataReady.Set() Then
                Dim msg As String = String.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Now)
                pipe.WaitForConnection()
                Using sw As StreamWriter = New StreamWriter(pipe)
                    sw.AutoFlush = True
                    sw.WriteLine(msg)
                End Using
            End If
        End If

    End Sub

    Private Sub btnStartThread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartThread.Click

        Dim eventName As String = "DataReady"
        Try
            evtDataReady = EventWaitHandle.OpenExisting(eventName)
        Catch ex As Exception
            evtDataReady = New EventWaitHandle(False, EventResetMode.AutoReset, eventName)
        End Try
        Dim newThread As New Thread(New ThreadStart(AddressOf AckDataReceived))
        newThread.Start()

    End Sub

    Public Sub AckDataReceived()

        evtDataReceived.WaitOne()

    End Sub

End Class
