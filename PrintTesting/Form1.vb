Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Graphics
        Dim f As Font = New Font("MS Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)
        Dim y As Integer
        g = pb.CreateGraphics
        y = 0
        g.DrawString(String.Format("{0}", y), f, Brushes.Black, 0, y)
        y += g.MeasureString("Hello, World", f).Height
        g.DrawString(String.Format("{0}", y), f, Brushes.Black, 0, y)
    End Sub
End Class
