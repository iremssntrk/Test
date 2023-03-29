Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Class MainWindow
    Dim streamClass As StreamRW
    Dim translate As Translate
    Dim quad As Quad4
    Public Sub New()
        InitializeComponent()
        streamClass = New StreamRW()
        translate = New Translate(sim1)
        sim1.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPick

    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        Dim Path As String
        Dim istep As Integer
        Dim Mat As Material = New Material("steel")
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim count As Integer
        Dim count2 As Integer
        Dim NoOfVertices As Integer
        Dim NoOfElement As Integer
        Path = "C:\Users\isenturk\Documents\irem.txt"

        Dim triangles As List(Of Element) = New List(Of Element)
        Dim vertices As List(Of Point3D)
        For Each item As String In streamClass.FileRead(Path).ToList

            If (istep = 1) And (count2 < NoOfVertices) Then
                translate.SumVertices(vertices, item)
                count2 = count2 + 1
            ElseIf (istep = 1) And (count2 = NoOfVertices) Then
                istep = 0
                count2 = 0
            End If
            If (istep = 2) And (count < NoOfElement) Then
                translate.SumElement(Mat, vertices, item)
                count = count + 1
            ElseIf (istep = 2) And (count = NoOfElement) Then
                istep = 0
                count = 0
            End If


            If item.Contains("elements:") Then
                Dim ForSplit = Split(item, " ")
                Integer.TryParse(ForSplit(1), NoOfElement)
                istep = 2
            ElseIf item.Contains("vertices:") Then
                vertices = New List(Of Point3D)
                Dim ForSplit = Split(item, " ")
                Integer.TryParse(ForSplit(1), NoOfVertices)
                istep = 1
            End If
        Next
        sim1.Invalidate()
    End Sub

End Class

