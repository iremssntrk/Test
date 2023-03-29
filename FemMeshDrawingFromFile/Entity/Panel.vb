Public Class Panel


    Private Name_x As String
    Public Property Name() As String
        Get
            Return Name_x
        End Get
        Set(ByVal value As String)
            Name_x = value
        End Set
    End Property

    Private Vertices_x As Integer
    Public Property Vertices() As Integer
        Get
            Return Vertices_x
        End Get
        Set(ByVal value As Integer)
            Vertices_x = value
        End Set
    End Property


    Private Elements_x As Integer
    Public Property Elements() As Integer
        Get
            Return Elements_x
        End Get
        Set(ByVal value As Integer)
            Elements_x = value
        End Set
    End Property

End Class
