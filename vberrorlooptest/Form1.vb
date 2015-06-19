Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        On Error GoTo Button1_Click_Error
        Dim eo As MyErrorObject = New MyErrorObject()
        eo.Number = 0
        eo.Description = ""

        Err.Raise(999, , "A Phony Error")

Button1_Click_Exit:
        If eo.Number <> 0 Then Err.Raise(eo.Number, , eo.Description)
        Exit Sub

Button1_Click_Error:

        eo.Number = Err.Number
        eo.Description = Err.Description
        On Error GoTo 0
        Resume Button1_Click_Exit

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim eo As MyErrorObject = New MyErrorObject()
        eo.Number = 0
        eo.Description = ""

        Try

            Err.Raise(999, , "A Phony Error")

        Catch ex As Exception

            eo.Number = Err.Number
            eo.Description = Err.Description

        Finally

            If eo.Number <> 0 Then Err.Raise(eo.Number, , eo.Description)

        End Try

    End Sub
End Class
