Public Class Class1
    Implements ClassLibrary3.IClass1

    Public Function GetInstanceCount() As Integer Implements ClassLibrary3.IClass1.GetInstanceCount
        Return Module1.instanceCount
    End Function

    Public Function GetOtherInstanceCount() As Integer Implements ClassLibrary3.IClass1.GetOtherInstanceCount
        Dim o2 As ClassLibrary3.IClass1
        Dim o2 As New cl
        Return o2.GetInstanceCount()
    End Function

    Public Sub New()
        Module1.instanceCount = Module1.instanceCount + 1
    End Sub

    Public Function GetInstanceCount1() As Integer Implements ClassLibrary3.IClass1.GetInstanceCount

    End Function

    Public Function GetOtherInstanceCount1() As Integer Implements ClassLibrary3.IClass1.GetOtherInstanceCount

    End Function
End Class
