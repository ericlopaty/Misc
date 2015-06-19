Public Class Class1
    Implements ClassLibrary3.IClass1

    Public Function GetInstanceCount() As Integer Implements ClassLibrary3.IClass1.GetInstanceCount
        Return Module1.instanceCount
    End Function

    Public Function GetOtherInstanceCount() As Integer Implements ClassLibrary3.IClass1.GetOtherInstanceCount
        Dim o2 As New ClassLibrary2.Class1
        Return o2.GetInstanceCount()
    End Function

    Public Sub New()
        Module1.instanceCount = Module1.instanceCount + 1
    End Sub

End Class
