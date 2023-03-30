Imports devDept.Eyeshot.MultiTouch.Manipulation
Imports devDept.Geometry

Public Class FindPoint
    Function PointXMax(vertices As List(Of Point3D)) As Double
        Dim xMax = vertices(0).X
        For Each item In vertices
            If (item.X > xMax) Then
                xMax = item.X
            End If
        Next
        Return xMax
    End Function

    Function PointYMax(vertices As List(Of Point3D)) As Double
        Dim yMax As Double
        For Each item In vertices
            If (item.Y > yMax) Then
                yMax = item.Y
            End If
        Next
        Return yMax
    End Function
    Function PointZMax(vertices As List(Of Point3D)) As Double
        Dim zMax As Double
        For Each item In vertices
            If (item.Z > zMax) Then
                zMax = item.Z
            End If
        Next
        Return zMax
    End Function

    Function PointXMin(vertices As List(Of Point3D)) As Double
        Dim xMin = vertices(0).X
        For Each item In vertices
            If (item.X < xMin) Then
                xMin = item.X
            End If
        Next
        Return xMin
    End Function

    Sub PointYMin(vertices As List(Of Point3D), yMin As Double)
        For Each item In vertices
            If (item.Y < yMin) Then
                yMin = item.Y
            End If
        Next
    End Sub
    Sub PointZMin(vertices As List(Of Point3D), zMin As Double)
        For Each item In vertices
            If (item.Z < zMin) Then
                zMin = item.Z
            End If
        Next
    End Sub


End Class


