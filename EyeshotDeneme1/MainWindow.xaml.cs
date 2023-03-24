using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace EyeshotDeneme1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vertices = new List<Point3D>();
            var vertices2 = new List<Point3D>();
            var vertices3 = new List<Point3D>();
            var vertices4 = new List<Point3D>();
            var vertices5 = new List<Point3D>();
            var vertices6 = new List<Point3D>();
            var vertices7 = new List<Point3D>();
            var vertices8 = new List<Point3D>();
            var vertices9 = new List<Point3D>();
            var vertices10 = new List<Point3D>();
            var vertices11 = new List<Point3D>();
            var vertices12 = new List<Point3D>();


            var v1 = new Point3D(0,0,0);
            var v2 = new Point3D(0,1,0);
            var v3 = new Point3D(0,0,1);
            var v4 = new Point3D(0,1,1);
            var v5 = new Point3D(-1,0,1);
            var v6 = new Point3D(-1,1,1);
            var v7 = new Point3D(-1,1,0);
            var v8 = new Point3D(-1,0,0);



            vertices.Add(v1); 
            vertices.Add(v2);  
            vertices.Add(v3);  

            vertices2.Add(v2);
            vertices2.Add(v3);
            vertices2.Add(v4);

            vertices3.Add(v3);
            vertices3.Add(v4);
            vertices3.Add(v5);

            vertices4.Add(v5);
            vertices4.Add(v4);
            vertices4.Add(v6);

            //bir yüz
            vertices5.Add(v4);
            vertices5.Add(v6);
            vertices5.Add(v2);

            vertices6.Add(v2);
            vertices6.Add(v7);
            vertices6.Add(v6);

            //bir yüz
            vertices7.Add(v1);
            vertices7.Add(v2);
            vertices7.Add(v7);

            vertices8.Add(v1);
            vertices8.Add(v8);
            vertices8.Add(v7);

            //bir yüz
            vertices9.Add(v8);
            vertices9.Add(v5);
            vertices9.Add(v3);

            vertices10.Add(v1);
            vertices10.Add(v8);
            vertices10.Add(v3);

            //bir yüz
            vertices11.Add(v5);
            vertices11.Add(v7);
            vertices11.Add(v8);

            vertices12.Add(v5);
            vertices12.Add(v6);
            vertices12.Add(v7);



            var triangles = new List<IndexTriangle>();

            var tri1 = new IndexTriangle(0, 1, 2);
            triangles.Add(tri1);

            var mymesh = new Mesh(vertices, triangles);
            var mymesh2 = new Mesh(vertices2, triangles);
            var mymesh3 = new Mesh(vertices3, triangles);
            var mymesh4 = new Mesh(vertices4, triangles);
            var mymesh5 = new Mesh(vertices5, triangles);
            var mymesh6 = new Mesh(vertices6, triangles);
            var mymesh7 = new Mesh(vertices7, triangles);
            var mymesh8 = new Mesh(vertices8, triangles);
            var mymesh9 = new Mesh(vertices9, triangles);
            var mymesh10 = new Mesh(vertices10, triangles);
            var mymesh11 = new Mesh(vertices11, triangles);
            var mymesh12 = new Mesh(vertices12, triangles);

            mymesh.Color = System.Drawing.Color.Red;
            mymesh.ColorMethod = colorMethodType.byEntity;
            mymesh2.Color = System.Drawing.Color.Red;
            mymesh2.ColorMethod = colorMethodType.byEntity;

            mymesh3.Color = System.Drawing.Color.Blue;
            mymesh3.ColorMethod = colorMethodType.byEntity;
            mymesh4.Color = System.Drawing.Color.Blue;
            mymesh4.ColorMethod = colorMethodType.byEntity;

            mymesh5.Color = System.Drawing.Color.Gold;
            mymesh5.ColorMethod = colorMethodType.byEntity;
            mymesh6.Color = System.Drawing.Color.Gold;
            mymesh6.ColorMethod = colorMethodType.byEntity;

            mymesh7.Color = System.Drawing.Color.DarkGray;
            mymesh7.ColorMethod = colorMethodType.byEntity;
            mymesh8.Color = System.Drawing.Color.DarkGray;
            mymesh8.ColorMethod = colorMethodType.byEntity;

            mymesh9.Color = System.Drawing.Color.DarkGreen;
            mymesh9.ColorMethod = colorMethodType.byEntity;
            mymesh10.Color = System.Drawing.Color.DarkGreen;
            mymesh10.ColorMethod = colorMethodType.byEntity;

            mymesh11.Color = System.Drawing.Color.Firebrick;
            mymesh11.ColorMethod = colorMethodType.byEntity;
            mymesh12.Color = System.Drawing.Color.Firebrick;
            mymesh12.ColorMethod = colorMethodType.byEntity;

            sim1.Entities.Add(mymesh);
            sim1.Entities.Add(mymesh2);
            sim1.Entities.Add(mymesh3);
            sim1.Entities.Add(mymesh4);
            sim1.Entities.Add(mymesh5);
            sim1.Entities.Add(mymesh6);
            sim1.Entities.Add(mymesh7);
            sim1.Entities.Add(mymesh8);
            sim1.Entities.Add(mymesh9);
            sim1.Entities.Add(mymesh10);
            sim1.Entities.Add(mymesh11);
            sim1.Entities.Add(mymesh12);

            sim1.Invalidate();
        }
    }
}





//private void Window_Loaded(object sender, RoutedEventArgs e)
//{
//    var vertices = new List<Point3D>();

//    var v1 = new Point3D(0, 0, 0);
//    var v2 = new Point3D(0, 1, 0);
//    var v3 = new Point3D(0, 0, 1);

//    vertices.Add(v1);
//    vertices.Add(v2);
//    vertices.Add(v3);

//    var triangles = new List<IndexTriangle>();

//    var tri1 = new IndexTriangle(0, 1, 2);
//    triangles.Add(tri1);

//    var mymesh = new Mesh(vertices, triangles);
//    mymesh.Color = System.Drawing.Color.Red;
//    mymesh.ColorMethod = colorMethodType.byEntity;

//    sim1.Entities.Add(mymesh);

//    sim1.Invalidate();
//}