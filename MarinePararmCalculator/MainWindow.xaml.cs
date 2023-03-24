using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace MarinePararmCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        StreamWriter writer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            List<double> Cbs = new List<double>();
            List<double> Deltas = new List<double>();
            writer.Close();
            writer = File.CreateText(path);
            int Delta_m;
            //Calculation delta 
            for (int i = 0; i < 6; i++)
            {
                if (int.TryParse(Delta_Text.Text, out Delta_m))
                Deltas.Add(Delta_m * i/ 5);
            }
            foreach (var delta in Deltas)
            {
                if (delta!=0)
                {
                    Cbs.Add(int.Parse(B_Text.Text) * int.Parse(L_Text.Text) * int.Parse(T_Text.Text) / delta);
                }
                else
                {
                    Cbs.Add(0);
                }
            }

            Write("[B]        [L]        [T]          [Cb]        [Δ]");

            for (int i = 0; i < 6; i++)
            {
                Write(B_Text.Text+ "          " + L_Text.Text + "          " + T_Text.Text+ "          " + Cbs[i].ToString("0.00") + "        " + Deltas[i].ToString("0.00"));
            }


            writer.Close();

        }

        public void Write(string text)
        { 
            writer.WriteLine(text);
        }

        public void Calculator(string text) 
        { 
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            string directory = "C:\\Users\\isenturk\\Desktop";
            path = System.IO.Path.Combine(directory, "calc.txt");
            writer = File.CreateText(path);
        }
    }
}
