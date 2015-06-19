Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text

Public Class Form1

    Dim c As AnObject

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        c = New AnObject()
        c.Params.Add("KEY_STRING", "Hello")
        c.Params.Add("KEY_NUM", 2)
        c.Params.Add("KEY_THREE", True)
        TextBox5.Text = c.ToXML()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        c = New AnObject()
        c.FromXML(TextBox5.Text)
    End Sub

End Class
