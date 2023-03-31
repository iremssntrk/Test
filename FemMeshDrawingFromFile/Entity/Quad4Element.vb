Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Triangulation
Imports devDept.Graphics

Public Class Quad4Element
    Inherits Quad4
    Implements IFemElement

    Dim _center As Point3D
    Public Sub New(nodeIndices As IEnumerable(Of Integer), mat As Material)
        MyBase.New(nodeIndices, mat)
    End Sub

    Public Sub New(nodeIndex1 As Integer, nodeIndex2 As Integer, nodeIndex3 As Integer, nodeIndex4 As Integer, mat As Material, vertices As List(Of Point3D))
        MyBase.New(nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, mat)
        _center = New Point3D
        _center = (vertices(nodeIndex1) + vertices(nodeIndex2) + vertices(nodeIndex3) + vertices(nodeIndex4)) / 4
    End Sub

    Protected Sub New(another As Quad4)
        MyBase.New(another)
    End Sub

    Public Property Center As Point3D Implements IFemElement.Center
        Get
            Return _center
        End Get
        Set(value As Point3D)
            value = _center
        End Set
    End Property
End Class
