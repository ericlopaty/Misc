Option Explicit On
Option Infer Off

Imports System.Drawing

Public Class FormMain

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim bmp As New System.Drawing.Bitmap(500, 500)
        Dim gr As System.Drawing.Graphics
        Dim br As Brush = Brushes.Black
        Dim fnt As Font = Me.Font

        gr = Graphics.FromImage(bmp)
        gr.FillRegion(Brushes.White, New Region(New Rectangle(0, 0, 500, 500)))
        gr.DrawString("Hello world", fnt, br, 10, 10)
        bmp.Save("c:\temp\image.bmp", System.Drawing.Imaging.ImageFormat.Bmp)

    End Sub
End Class
