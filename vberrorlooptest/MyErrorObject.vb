Public Class MyErrorObject

    Private n As Integer
    Private d As String

    Public Property Number() As Integer
        Get
            Return n
        End Get
        Set(ByVal value As Integer)
            n = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return d
        End Get
        Set(ByVal value As String)
            d = value
        End Set
    End Property

End Class
