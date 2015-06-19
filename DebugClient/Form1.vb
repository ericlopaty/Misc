Imports DebugLibrary

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim o As DebugLibrary.DebugClass = New DebugLibrary.DebugClass
        TextBox2.Text = o.Version

    End Sub
End Class
