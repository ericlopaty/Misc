Imports System.Data.SqlClient

Module Module1

    Sub Main()

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cb As New SqlConnectionStringBuilder

        cb.InitialCatalog = "PruProfile"
        cb.DataSource = "PAERSCBVA0105"
        cb.IntegratedSecurity = True
        cn.ConnectionString = cb.ConnectionString
        cn.Open()
        cmd.CommandText = "usp_GetAppInfo"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        SqlCommandBuilder.DeriveParameters(cmd)
        For Each param As SqlParameter In cmd.Parameters
            Console.WriteLine(param.ParameterName)
        Next
        cn.Close()
        Console.ReadLine()

    End Sub

End Module
