Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Eyeshot.FontStyleCharData
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Class MainWindow

    Dim _vertices As List(Of Point3D)

    Dim _cubes As List(Of Element)
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        sim.Entities.Clear()

        Dim degree As Double

        Double.TryParse(TextBox1.Text, degree)
        _vertices = New List(Of Point3D)

        Dim rotate As Double

        Double.TryParse(TextBox2.Text, rotate)

        rotate = (Math.PI / 180 * rotate)

        Dim rotate2
        Double.TryParse(TextBox3.Text, rotate2)

        rotate2 = (Math.PI / 180 * rotate2)

        Dim radians As Double = (Math.PI / 180 * degree)

        create_new_femmesh(radians, rotate, rotate2)
    End Sub

    Private Sub create_new_femmesh(radians As Double, rotate As Double, rotate2 As Double)
        Dim mat = New Material("Steel", System.Drawing.Color.FromArgb(255, 0, 255, 0))
        Dim mat2 = New Material("Steel", System.Drawing.Color.FromArgb(255, 255, 0, 0))
        Dim mat3 = New Material("Steel", System.Drawing.Color.FromArgb(255, 0, 0, 255))

        Dim start_point = New Node(0, 0, 0)

        Dim end_point = New Node(0, 10 * Math.Cos(radians), 10 * Math.Sin(radians))

        Dim long_vec = (end_point - start_point).AsVector

        Dim hor_vec = New Vector3D(1, 0, 0)

        Dim vert_vec = Vector3D.Cross(hor_vec, long_vec)
        vert_vec.Normalize()

        Dim height = 1.0
        Dim thickness = 0.1
        Dim web_height = 1.0 - 2 * thickness
        Dim flange_width = 1.0
        Dim flange_eccentricity = (flange_width - thickness) / 2


        Dim x1 = Math.Cos(rotate)
        Dim x2 = Math.Sin(rotate)
        Dim rotated = (x1 * vert_vec + x2 * hor_vec)
        rotated.Normalize()
        vert_vec = rotated
        hor_vec = Vector3D.Cross(long_vec, rotated)
        hor_vec.Normalize()



        'Dim y1 = Math.Cos(rotate2)
        'Dim y2 = Math.Sin(rotate2)
        'Dim rotated2 = (y1 * hor_vec + y2 * vert_vec)
        'rotated2.Normalize()
        'hor_vec = rotated2
        'vert_vec = Vector3D.Cross(hor_vec, long_vec)
        'vert_vec.Normalize()


        Dim y1 = Math.Sin(rotate2)
        Dim y2 = Math.Cos(rotate2)
        Dim rotated2 = (y1 * hor_vec + y2 * long_vec)
        rotated2.Normalize()
        hor_vec = rotated2
        long_vec = Vector3D.Cross(hor_vec, vert_vec)
        long_vec.Normalize()



        Dim p11_start = start_point - thickness / 2 * hor_vec - web_height / 2 * vert_vec
        Dim p12_start = p11_start + thickness * hor_vec
        Dim p13_start = p12_start + web_height * vert_vec
        Dim p14_start = p13_start - thickness * hor_vec

        Dim p21_start = start_point - flange_width / 2 * hor_vec - height / 2 * vert_vec
        Dim p22_start = p21_start + flange_width * hor_vec
        Dim p23_start = p22_start + thickness * vert_vec
        Dim p24_start = p23_start - flange_width * hor_vec

        Dim p31_start = start_point - flange_width / 2 * hor_vec + web_height / 2 * vert_vec
        Dim p32_start = p31_start + flange_width * hor_vec
        Dim p33_start = p32_start + thickness * vert_vec
        Dim p34_start = p33_start - flange_width * hor_vec



        Dim p11_end = end_point - thickness / 2 * hor_vec - web_height / 2 * vert_vec
        Dim p12_end = p11_end + thickness * hor_vec
        Dim p13_end = p12_end + web_height * vert_vec
        Dim p14_end = p13_end - thickness * hor_vec

        Dim p21_end = end_point - flange_width / 2 * hor_vec - height / 2 * vert_vec
        Dim p22_end = p21_end + flange_width * hor_vec
        Dim p23_end = p22_end + thickness * vert_vec
        Dim p24_end = p23_end - flange_width * hor_vec

        Dim p31_end = end_point - flange_width / 2 * hor_vec + web_height / 2 * vert_vec
        Dim p32_end = p31_end + flange_width * hor_vec
        Dim p33_end = p32_end + thickness * vert_vec
        Dim p34_end = p33_end - flange_width * hor_vec


        _vertices.Add(New Node(p11_start.X, p11_start.Y, p11_start.Z))
        _vertices.Add(New Node(p12_start.X, p12_start.Y, p12_start.Z))
        _vertices.Add(New Node(p13_start.X, p13_start.Y, p13_start.Z))
        _vertices.Add(New Node(p14_start.X, p14_start.Y, p14_start.Z))

        _vertices.Add(New Node(p21_start.X, p21_start.Y, p21_start.Z))
        _vertices.Add(New Node(p22_start.X, p22_start.Y, p22_start.Z))
        _vertices.Add(New Node(p23_start.X, p23_start.Y, p23_start.Z))
        _vertices.Add(New Node(p24_start.X, p24_start.Y, p24_start.Z))

        _vertices.Add(New Node(p31_start.X, p31_start.Y, p31_start.Z))
        _vertices.Add(New Node(p32_start.X, p32_start.Y, p32_start.Z))
        _vertices.Add(New Node(p33_start.X, p33_start.Y, p33_start.Z))
        _vertices.Add(New Node(p34_start.X, p34_start.Y, p34_start.Z))


        _vertices.Add(New Node(p11_end.X, p11_end.Y, p11_end.Z))
        _vertices.Add(New Node(p12_end.X, p12_end.Y, p12_end.Z))
        _vertices.Add(New Node(p13_end.X, p13_end.Y, p13_end.Z))
        _vertices.Add(New Node(p14_end.X, p14_end.Y, p14_end.Z))

        _vertices.Add(New Node(p21_end.X, p21_end.Y, p21_end.Z))
        _vertices.Add(New Node(p22_end.X, p22_end.Y, p22_end.Z))
        _vertices.Add(New Node(p23_end.X, p23_end.Y, p23_end.Z))
        _vertices.Add(New Node(p24_end.X, p24_end.Y, p24_end.Z))

        _vertices.Add(New Node(p31_end.X, p31_end.Y, p31_end.Z))
        _vertices.Add(New Node(p32_end.X, p32_end.Y, p32_end.Z))
        _vertices.Add(New Node(p33_end.X, p33_end.Y, p33_end.Z))
        _vertices.Add(New Node(p34_end.X, p34_end.Y, p34_end.Z))

        Dim web = New Hexa8(0, 1, 2, 3, 12, 13, 14, 15, mat)

        Dim lower_flange = New Hexa8(4, 5, 6, 7, 16, 17, 18, 19, mat2)

        Dim upper_flange = New Hexa8(8, 9, 10, 11, 20, 21, 22, 23, mat3)

        _cubes = New List(Of Element)
        _cubes.Add(web)
        _cubes.Add(lower_flange)
        _cubes.Add(upper_flange)


        Dim femmesh = New FemMesh(_vertices, _cubes)
        sim.Entities.Add(femmesh)

        sim.Invalidate()
    End Sub

    Private Sub create_femmesh(radians As Double)
        Dim mat = New Material("Steel", System.Drawing.Color.FromArgb(255, 0, 255, 0))
        Dim mat2 = New Material("Steel", System.Drawing.Color.FromArgb(255, 255, 0, 0))
        Dim mat3 = New Material("Steel", System.Drawing.Color.FromArgb(255, 0, 0, 255))


        _vertices.Add(New Node(0.05 * Math.Cos(radians), 0.05 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(0.05 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.05 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(-0.05 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.05 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(-0.05 * Math.Cos(radians), -0.05 * Math.Sin(radians), 0.4))


        _vertices.Add(New Node(0.05 * Math.Cos(radians), 0.05 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(0.05 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.05 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(-0.05 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.05 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(-0.05 * Math.Cos(radians), -0.05 * Math.Sin(radians), -0.4))

        _vertices.Add(New Node(0.5 * Math.Cos(radians), 0.5 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.5 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.5 * Math.Sin(radians), 0.4))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians), -0.5 * Math.Sin(radians), 0.4))

        _vertices.Add(New Node(0.5 * Math.Cos(radians), 0.5 * Math.Sin(radians), 0.5))
        _vertices.Add(New Node(0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.5 * Math.Sin(radians), 0.5))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.5 * Math.Sin(radians), 0.5))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians), -0.5 * Math.Sin(radians), 0.5))


        _vertices.Add(New Node(0.5 * Math.Cos(radians), 0.5 * Math.Sin(radians), -0.5))
        _vertices.Add(New Node(0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.5 * Math.Sin(radians), -0.5))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.5 * Math.Sin(radians), -0.5))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians), -0.5 * Math.Sin(radians), -0.5))


        _vertices.Add(New Node(0.5 * Math.Cos(radians), 0.5 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) + 0.5 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians) - 10 * Math.Sin(radians), 10 * Math.Cos(radians) - 0.5 * Math.Sin(radians), -0.4))
        _vertices.Add(New Node(-0.5 * Math.Cos(radians), -0.5 * Math.Sin(radians), -0.4))


        'For Each item In _vertices
        '    item.X = item.X * Math.Cos(radians) - item.Y * Math.Sin(radians)
        '    item.Y = item.X * Math.Sin(radians) + item.Y * Math.Cos(radians)
        'Next



        Dim cube1 = New Hexa8(0, 1, 2, 3, 4, 5, 6, 7, mat)

        Dim cube2 = New Hexa8(8, 9, 10, 11, 12, 13, 14, 15, MAT2)

        Dim cube3 = New Hexa8(16, 17, 18, 19, 20, 21, 22, 23, mat3)

        _cubes = New List(Of Element)
        _cubes.Add(cube1)
        _cubes.Add(cube2)
        _cubes.Add(cube3)



        Dim femmesh = New FemMesh(_vertices, _cubes)
        sim.Entities.Add(femmesh)

        sim.Invalidate()


    End Sub
End Class


'Dim deger As Integer
'deger = 40
'Dim rotation = New devDept.Geometry.Rotation(deger, Vector3D.AxisX, New Point3D(0, 0, 0))
'For Each entity In sim.Entities
'    entity.TransformBy(rotation)
'Next