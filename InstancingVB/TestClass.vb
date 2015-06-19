Option Infer Off
Option Strict On
Option Compare Text

<ComVisible(True)> _
<GuidAttribute("E529ECF8-59D3-4DF5-8E6B-511D9D565350")> _
<ClassInterface(ClassInterfaceType.AutoDual)> _
Public Class TestClass

    Private Shared ReadOnly logFile As String = "c:\temp\Instancing.log"
    Private Shared instanceCount As Integer
    Private thisInstance As Integer
    Private msg As String

    Private Shared Sub ShowError(ByVal x As Exception)
        MessageBox.Show(String.Format("ERROR: {0}", x.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Shared Sub WriteLog(ByVal message As String)
        Try
            Using writer As StreamWriter = File.AppendText(logFile)
                writer.WriteLine(message)
                writer.Flush()
                writer.Close()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Shared Sub New()
        instanceCount = 0
        WriteLog("Creating Global TestClass: There are no individual instances.")
    End Sub

    Public Sub New()
        instanceCount = instanceCount + 1
        msg = ""
        WriteLog(String.Format("Createing a TestClass instance, the count is {0}", instanceCount))
        thisInstance = instanceCount
    End Sub

    <ComVisibleAttribute(True)> _
    Public Sub WriteMessage(ByVal s As String)
        msg = msg + "; " + s
        WriteLog(msg)
    End Sub

    Protected Overrides Sub Finalize()
        WriteLog(String.Format("Destroying TestClass instance {0}", thisInstance))
        MyBase.Finalize()
    End Sub

End Class
