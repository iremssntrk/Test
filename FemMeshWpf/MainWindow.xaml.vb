Imports System.Windows.Media.Media3D

Class MainWindow


    Dim image1 As Bitmap
    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click

        image1 = New Bitmap("C:\\Users\\isenturk\\Documents\\logo.jpg", True)

        For index1 = image1.Width - 1 To 0 Step -1

            For index2 = image1.Height - 1 To 0 Step -1

                Dim PixelColor As System.Drawing.Color = image1.GetPixel(index1, index2)
                Dim Center As Point3D = New Point3D(index1, image1.Height - index2, 0)

                Translate(PixelColor, Center)

            Next
        Next



        sim1.Invalidate()




        MyBase.OnContentRendered(e)
    End Sub

    Sub Translate(pixelColor As Color, center As Point3D)

        Dim triangles As List(Of IndexTriangle) = New List(Of IndexTriangle)

        Dim v1 = New Point3D(center.X - 0.5, center.Y - 0.5, 0)
        Dim v2 = New Point3D(center.X - 0.5, center.Y + 0.5, 0)
        Dim v3 = New Point3D(center.X + 0.5, center.Y - 0.5, 0)
        Dim v4 = New Point3D(center.X + 0.5, center.Y + 0.5, 0)

        Dim vertices As List(Of Point3D) = New List(Of Point3D)()

        Dim i1 = vertices.Count
        vertices.Add(v1)
        Dim i2 = vertices.Count
        vertices.Add(v2)
        Dim i3 = vertices.Count
        vertices.Add(v3)
        Dim i4 = vertices.Count
        vertices.Add(v4)


        Dim tri = New ColorTriangle(i1, i2, i3, pixelColor.R, pixelColor.G, pixelColor.B)
        Dim tri2 = New ColorTriangle(i3, i4, i2, pixelColor.R, pixelColor.G, pixelColor.B)
        triangles.Add(tri2)
        triangles.Add(tri)
        Dim mesh As Mesh = New Mesh(vertices, triangles)
        mesh.ColorMethod = colorMethodType.byEntity
        sim1.Entities.Add(mesh)


    End Sub

End Class
