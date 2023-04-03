Imports devDept.Geometry

Public Class PanelWrapper
    Public Sub New()
        'Name As String
        Me.Name = Name
        Vertices = New List(Of Point3D)
        Elements = New List(Of ElementWrapper)
    End Sub

    Public Name As String

    Public Vertices As List(Of Point3D)

    Public Elements As List(Of ElementWrapper)

    Public NumberOfElement As Integer

    Public NumberOfVertices As Integer

    Public Normal As Vector3D

    Public Min As Double = Double.MaxValue

    Public Max As Double = Double.MinValue
End Class
