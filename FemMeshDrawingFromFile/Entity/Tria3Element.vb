Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Graphics

Public Class Tria3Element
    Inherits Tria3
    Implements IFemElement

    Dim _center As Point3D
    Public Sub New(nodeIndices As IList(Of Integer), mat As Material)
        MyBase.New(nodeIndices, mat)
    End Sub

    Public Sub New(nodeIndex1 As Integer, nodeIndex2 As Integer, nodeIndex3 As Integer, mat As Material, vertices As List(Of Point3D))
        MyBase.New(nodeIndex1, nodeIndex2, nodeIndex3, mat)
        _center = New Point3D
        _center = (vertices(nodeIndex1) + vertices(nodeIndex2) + vertices(nodeIndex3)) / 3
    End Sub

    Protected Sub New(another As Tria3)
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
