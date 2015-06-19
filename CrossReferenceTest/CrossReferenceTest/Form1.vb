Public Class Form1

    Dim o As ClassLibrary1.Class1
    Dim j As ClassLibrary2.Class1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        o = New ClassLibrary1.Class1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = String.Format("{0}", o.GetInstanceCount())
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = String.Format("{0}", o.GetOtherInstanceCount())
    End Sub
End Class
