﻿Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports System.Windows.Forms
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Eyeshot.FontStyleCharData
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Public Class Translate



    Sub SumVertices(vertices As List(Of Point3D), item As String)
        Dim tArray() As String
        tArray = Split(item, " ")
        Dim p(3) As Double
        For i = 0 To UBound(tArray)
            Double.TryParse(tArray(i), p(i))
        Next i
        Dim v As Node = New Node(p(0), p(1), p(2))
        vertices.Add(v)
    End Sub

    Sub SumTriangles(Mat As Material, item As String, triangles As List(Of Element), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim temp As Integer
        Dim tArray() As String
        tArray = Split(item, " ")
        For k = 0 To UBound(tArray)
            Double.TryParse(tArray(k), temp)
            element.Add(temp)
        Next k
        If (element.Count) = 4 Then
            SumOfQuads(triangles, element, vertices, xMin, xMax)
        ElseIf (element.Count) = 3 Then
            SumOfTrias(triangles, element, vertices, xMin, xMax)
        End If

    End Sub

    Sub SumOfQuads(triangles As List(Of Element), Element As List(Of Integer), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim p1 As Point3D = New Point3D()
        Dim p2 As Point3D = New Point3D()
        Dim p3 As Point3D = New Point3D()
        Dim p4 As Point3D = New Point3D()
        p1 = vertices(Element(0))
        p2 = vertices(Element(1))
        p3 = vertices(Element(2))
        p4 = vertices(Element(3))
        Dim center As Point3D = New Point3D()
        center = (p1 + p2 + p3 + p4) / 40
        Dim mat As Material = New Material(FindMaterialColor(Element, vertices, xMin, xMax))
        Dim Quad = New Quad4(Element(0), Element(1), Element(2), Element(3), mat)
        triangles.Add(Quad)
    End Sub

    Sub SumOfTrias(triangles As List(Of Element), Element As List(Of Integer), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim material As Material = New Material(FindMaterialColor(Element, vertices, xMin, xMax))
        Dim tri1 As Tria3 = New Tria3(Element(0), Element(1), Element(2), material)
        triangles.Add(tri1)
    End Sub


    Function FindMaterialColor(Elements As List(Of Integer), vertices As List(Of Point3D), Xmin As Double, Xmax As Double) As System.Drawing.Color
        Dim ElementTotal As Point3D = New Point3D
        For Each element In Elements
            ElementTotal = vertices(element) + ElementTotal
        Next
        Dim center As Point3D = New Point3D()
        center = ElementTotal / Elements.Count
        Dim color As System.Drawing.Color = New System.Drawing.Color()
        Dim colorTemp = CreateColorTable(((center.X - Xmin) / (Xmax - Xmin)) * 1024)
        color = System.Drawing.Color.FromArgb(colorTemp.A, colorTemp.R, colorTemp.G, colorTemp.B)
        Return color
    End Function

    Private Shared Function CreateColorTable()
        Dim colortable = New List(Of System.Windows.Media.Color)
        Dim alpha = 255
        For i = 0 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 0, i, 255))
        Next

        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 0, 255, 255 - i))
        Next

        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, i, 255, 0))
        Next

        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 255, 255 - i, 0))
        Next
        Return colortable
    End Function





End Class






