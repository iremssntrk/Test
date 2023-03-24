
using Microsoft.Win32;
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
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;



namespace MarineParamCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathCalculation;
        string pathLog;
        StreamWriter writer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            string directory = "C:\\Users\\isenturk\\Desktop";   //default location
            pathCalculation = System.IO.Path.Combine(directory, "calc.txt");
            writer = File.CreateText(pathCalculation);
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            List<double> Cbs = new List<double>();
            List<double> Deltas = new List<double>();
            writer.Close();
            writer = File.CreateText(pathCalculation);
            int Delta_m;
            //Calculation delta 
            for (int i = 0; i < 6; i++)
            {
                if (int.TryParse(Delta_Text.Text, out Delta_m))
                    Deltas.Add(Delta_m * i / 5);
            }
            foreach (var delta in Deltas)
            {
                if (delta != 0)
                {
                    Cbs.Add(int.Parse(B_Text.Text) * int.Parse(L_Text.Text) * int.Parse(T_Text.Text) / delta);
                }
                else
                {
                    Cbs.Add(0);
                }
            }

            Write($"{"[B]",-11:f} {"[L]",-11:f} {"[T]",-11:f} {"[Cb]",-11:f} {"[Δ]",-11:f} ");

            for (int i = 0; i < 6; i++)
            {         
             Write($"{B_Text.Text,-11:f} {L_Text.Text,-11:f} {T_Text.Text,-11:f} {Cbs[i].ToString("0.00"),-11:f} {Deltas[i].ToString("0.00"),-11:f} ");
            }


            writer.Close();

        }

        public void Write(string text)
        {
            writer.WriteLine(text);
        }




        private void controlbtn_Click(object sender, RoutedEventArgs e)   
        {
            var filedialog = new OpenFileDialog();
            filedialog.Filter = "txt | *.txt";
            if (filedialog.ShowDialog() == true)
            {
                pathCalculation = filedialog.FileName;
            }

        }

        private void NavBar_button3_Click(object sender, RoutedEventArgs e)   //Display calculation
        {
            pathCalculation = pathCalculation;
            DisplayFile(pathCalculation);
        }

        private void NavBar_button4_Click(object sender, RoutedEventArgs e)   //Display Log
        {
            pathLog = pathLog;
            DisplayFile(pathLog);
        }

        public void DisplayFile(string path)
        {
            String line;
            ListBox.Items.Clear();
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                ListBox.Items.Add(line);
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }
    }
}

