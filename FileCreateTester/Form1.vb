Imports System.IO

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            Dim s As String = My.Application.Info.DirectoryPath

            Dim w As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("FileCreateTester.txt", False)

            w.WriteLine(Now.ToString())

            w.Flush()
            w.Close()
            w.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try



    End Sub
End Class
