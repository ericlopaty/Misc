Public Class Form1

    Private r As New Random

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
        For i As Integer = 1 To 100
            Dim columns(3) As String
            columns(0) = RandomString(5)
            columns(1) = RandomString(10)
            columns(2) = RandomString(15)
            Dim item As New ListViewItem(columns)
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Function RandomString(ByVal length As Integer) As String
        Dim s As String = ""
        For i As Integer = 1 To length
            s = s & "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz".Substring(r.Next(0, 52), 1)
        Next
        RandomString = s
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Columns.Clear()
        ListView1.Columns.Add("A", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("B", 125, HorizontalAlignment.Left)
        ListView1.Columns.Add("C", 150, HorizontalAlignment.Left)
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

End Class

Class ListViewItemComparer
    Implements System.Collections.IComparer

    Private Shared lastColumn As Integer = -1
    Private Shared ascending As Boolean = True
    Private col As Integer

    Public Sub New(ByVal col As Integer)
        Me.col = col
        If (col = lastColumn) Then
            ascending = Not ascending
        Else
            ascending = True
            lastColumn = col
        End If
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim left As ListViewItem = CType(x, ListViewItem)
        Dim right As ListViewItem = CType(y, ListViewItem)
        If ascending Then
            Return String.Compare(left.SubItems(col).Text, right.SubItems(col).Text)
        Else
            Return String.Compare(right.SubItems(col).Text, left.SubItems(col).Text)
        End If

    End Function
End Class