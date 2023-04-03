Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports System.Windows.Forms
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Eyeshot.FontStyleCharData
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics
Imports Xceed.Wpf.Toolkit
Imports System.Collections.Generic

Public Class Translate
    Public Sub New()
        materialsDictionary = New Dictionary(Of System.Drawing.Color, Material)
    End Sub

    Dim materialsDictionary As Dictionary(Of System.Drawing.Color, Material)

    Sub SumVertices(vertices As List(Of Point3D), item As String)
        Dim tArray() As String
        tArray = Split(item, " ")
        Dim p(3) As Double
        For i = 0 To UBound(tArray)
            Double.TryParse(tArray(i), p(i))
        Next i
        Dim v As Node = New Node(p(0), p(1), p(2))
        v.VonMises = 4.5
        vertices.Add(v)
    End Sub

    Sub SumTriangles(item As String, triangles As List(Of Element), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim temp As Integer
        Dim tArray() As String
        tArray = Split(item, " ")
        For k = 0 To UBound(tArray)
            Double.TryParse(tArray(k), temp)
            element.Add(temp)
        Next k
        If (element.Count) = 4 Then
            SumOfQuad(triangles, element, vertices, xMin, xMax)
        ElseIf (element.Count) = 3 Then
            SumOfTrias(triangles, element, vertices, xMin, xMax)
        End If

    End Sub

    Sub SumOfQuad(triangles As List(Of Element), Elements As List(Of Integer), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim mat As Material
        Dim materialColor = FindMaterialColor(Elements, vertices, xMin, xMax)
        If materialsDictionary.ContainsKey(materialColor) Then
            mat = materialsDictionary(materialColor)
        Else
            mat = New Material("Steel", materialColor)
            materialsDictionary.Add(materialColor, mat)
        End If
        Dim quad4Element As Quad4Element = New Quad4Element(Elements(0), Elements(1), Elements(2), Elements(3), mat, vertices)
        Dim center2 = quad4Element.Center
        triangles.Add(quad4Element)
    End Sub

    Sub SumOfQuadsNew(triangles As List(Of Element), Elements As List(Of Integer), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim mat As Material
        Dim materialColor = GetColorRange(3, 5, xMin, xMax)

        Dim colorTemp = GetColorRange(3, 5, xMin, xMax)

        Dim color = System.Drawing.Color.FromArgb(colorTemp(0).A, colorTemp(0).R, colorTemp(0).G, colorTemp(0).B)

        mat = New Material("Steel", color)
        materialsDictionary.Add(color, mat)




        'If materialsDictionary.ContainsKey(materialColor) Then
        '    mat = materialsDictionary(materialColor)
        'Else
        '    mat = New Material("Steel", materialColor)
        '    materialsDictionary.Add(materialColor, mat)
        'End If
        Dim quad4Element As Quad4Element = New Quad4Element(Elements(0), Elements(1), Elements(2), Elements(3), mat, vertices)
        Dim center2 = quad4Element.Center
        triangles.Add(quad4Element)

    End Sub



    Private Shared Function GetColorRange(localmin As Double, localmax As Double, globalmin As Double, globalmax As Double) As List(Of Color)
        Dim localcolortable = New List(Of Color)
        Dim limitedcolortable = New List(Of Color)
        Dim colorstep = (CreateColorTable.Count - 1) / (CreateColorTable() - 1)
        Dim cumindex = 0.0

        Dim tol = cumindex - (CreateColorTable.Count - 1)

        While Math.Abs(tol) > Math.Pow(10, -6)
            Dim rndinx = CType(Math.Round(cumindex, 0), Integer)
            limitedcolortable.Add(CreateColorTable(rndinx))
            cumindex += colorstep
            tol = cumindex - (CreateColorTable.Count - 1)
        End While

        If Not limitedcolortable.Contains(CreateColorTable.Last()) Then
            limitedcolortable.Add(CreateColorTable.Last())
        End If

        Dim maxcolortableindex = limitedcolortable.Count - 1
        If localmin = 0 And localmax = 0 Then
            If globalmin = globalmax Then
                localcolortable.Add(limitedcolortable.First())
            Else
                Dim index = (0 - globalmin) / (globalmax - globalmin) * (maxcolortableindex - 0)
                Dim rndindex = CType(Math.Round(index, 0), Integer)
                localcolortable.Add(limitedcolortable(rndindex))
            End If
        ElseIf globalmax = globalmin Then
            If globalmax > 0 Then
                localcolortable.Add(limitedcolortable.Last())
            Else
                localcolortable.Add(limitedcolortable(0))
            End If
        Else
            Dim minindexval = maxcolortableindex - (globalmax - localmin) / (globalmax - globalmin) * (maxcolortableindex - 0)
            Dim minindex = CType(Math.Round(minindexval, 0), Integer)
            Dim maxindexval = maxcolortableindex - (globalmax - localmax) / (globalmax - globalmin) * (maxcolortableindex - 0)
            Dim maxindex = CType(Math.Round(maxindexval, 0), Integer)

            For i As Integer = minindex To maxindex
                localcolortable.Add(limitedcolortable(i))
            Next
        End If
        Return localcolortable
    End Function






    Sub SumOfTrias(triangles As List(Of Element), Element As List(Of Integer), vertices As List(Of Point3D), xMin As Double, xMax As Double)
        Dim mat As Material
        Dim materialColor = FindMaterialColor(Element, vertices, xMin, xMax)
        If materialsDictionary.ContainsKey(materialColor) Then
            mat = materialsDictionary(materialColor)
        Else
            mat = New Material("Steel", materialColor)
            materialsDictionary.Add(materialColor, mat)
        End If
        Dim tria3Element As Tria3Element = New Tria3Element(Element(0), Element(1), Element(2), mat, vertices)
        Dim center2 = tria3Element.Center
        triangles.Add(tria3Element)
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


    '1024 renk
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






