Imports devDept.Geometry

Public Class QuadWrapper
    Inherits ElementWrapper

    Public Sub New(i1 As Integer, i2 As Integer, i3 As Integer, i4 As Integer, vertices As List(Of Point3D))
        Me.I1 = i1
        Me.I2 = i2
        Me.I3 = i3
        Me.I4 = i4

        Dim p1 = vertices(Me.I1)
        Dim p2 = vertices(Me.I2)
        Dim p3 = vertices(Me.I3)
        Dim p4 = vertices(Me.I4)

        Center = (p1 + p2 + p3 + p4) / 4
    End Sub

    Public I1 As Integer

    Public I2 As Integer

    Public I3 As Integer

    Public I4 As Integer
End Class
