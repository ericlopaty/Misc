Imports System.Data.SqlClient

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cb As New SqlConnectionStringBuilder

        cb.DataSource = tbServer.Text
        cb.InitialCatalog = tbDatabase.Text
        cb.IntegratedSecurity = True
        cn.ConnectionString = cb.ConnectionString
        cn.Open()
        cmd.CommandText = tbProc.Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        SqlCommandBuilder.DeriveParameters(cmd)
        tbParams.Text = ""
        For Each param As SqlParameter In cmd.Parameters
            tbParams.Text = tbParams.Text + param.ParameterName + vbCrLf
        Next
        cn.Close()
    End Sub

End Class





