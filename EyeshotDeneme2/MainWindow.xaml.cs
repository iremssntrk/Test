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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using devDept.Eyeshot.Entities;
using Microsoft.Win32;

namespace EyeshotDeneme2
{

    public partial class MainWindow : System.Windows.Window
    {
        List<IndexTriangle> triangles;

        List<Point3D> vertices;

        string path;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            triangles = new List<IndexTriangle>();

            vertices = new List<Point3D>();

            //var color_tri = new ColorTriangle(0, 1, 2, 255, 255, 255);

            //triangles.Add(color_tri);

        }

        private void controlbtn_Click(object sender, RoutedEventArgs e)
        {
            var filedialog = new System.Windows.Forms.OpenFileDialog();
            filedialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = filedialog.FileName;

                Translate(path);
            }
        }


        private void controlbtn2_Click(object sender, RoutedEventArgs e)
        {
            Translate(path);
        }

        Bitmap image1;

        private void Translate(string path)
        {
            try
            {
                image1 = new Bitmap(path, true);

                int x, y;

                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        System.Drawing.Color pixelColor = image1.GetPixel(x, y);

                        var center = new Point3D(x, y, 0);
                        //CreateSquare(center, pixelColor, vertices, triangles);

                        CreateAndAddSquare(center, pixelColor);
                    }
                }

                //var mymesh = new Mesh(vertices, triangles);
                //mymesh.ColorMethod = colorMethodType.byEntity;
                //sim1.Entities.Add(mymesh);
                sim1.Invalidate();

                sim1.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPick;

                Label1.Content = "Pixel format: " + image1.PixelFormat.ToString();
            }
            catch (ArgumentException)
            {
                System.Windows.MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }
        }

        private void CreateSquare(Point3D center, System.Drawing.Color color, List<Point3D> vertices, List<IndexTriangle> triangles)
        {
            var p1 = new Point3D(center.X - 0.5, center.Y - 0.5, 0);
            var p2 = new Point3D(center.X - 0.5, center.Y + 0.5, 0);
            var p3 = new Point3D(center.X + 0.5, center.Y - 0.5, 0);
            var p4 = new Point3D(center.X + 0.5, center.Y + 0.5, 0);

            var i1 = vertices.Count;
            vertices.Add(p1);

            var i2 = vertices.Count;
            vertices.Add(p2);

            var i3 = vertices.Count;
            vertices.Add(p3);

            var i4 = vertices.Count;
            vertices.Add(p4);


            var tri1 = new ColorTriangle(i1, i3, i2, color.R, color.G, color.B);
            triangles.Add(tri1);

            var tri2 = new ColorTriangle(i3, i4, i2, color.R, color.G, color.B);
            triangles.Add(tri2);
        }

        private void CreateAndAddSquare(Point3D center, System.Drawing.Color color)
        {
            var p1 = new Point3D(center.X - 0.5, center.Y - 0.5, 0);
            var p2 = new Point3D(center.X - 0.5, center.Y + 0.5, 0);
            var p3 = new Point3D(center.X + 0.5, center.Y - 0.5, 0);
            var p4 = new Point3D(center.X + 0.5, center.Y + 0.5, 0);

            var vertices = new List<Point3D>();

            var i1 = vertices.Count;
            vertices.Add(p1);

            var i2 = vertices.Count;
            vertices.Add(p2);

            var i3 = vertices.Count;
            vertices.Add(p3);

            var i4 = vertices.Count;
            vertices.Add(p4);

            var triangles = new List<IndexTriangle>();

            var tri1 = new ColorTriangle(i1, i2, i3 , color.R, color.G, color.B);
            triangles.Add(tri1);

            var tri2 = new ColorTriangle(i3, i4, i2, color.R, color.G, color.B);
            triangles.Add(tri2);

            var mymesh = new Mesh(vertices, triangles);
            mymesh.ColorMethod = colorMethodType.byEntity;
            sim1.Entities.Add(mymesh);
            sim1.Invalidate();
        }
    }
}
