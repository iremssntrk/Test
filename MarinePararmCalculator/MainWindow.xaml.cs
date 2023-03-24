
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
using MarinePararmCalculator.Path;
using MarinePararmCalculator;

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

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;   //default location
            pathCalculation = System.IO.Path.Combine(directory, "calc.txt");
            pathCalculation = System.IO.Path.Combine(directory, "log.txt");
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


        private void NavBar_button3_Click(object sender, RoutedEventArgs e)   //Display calculation
        {
            Utilities.DisplayFile(pathCalculation, ListBox); ;
        }

        private void NavBar_button4_Click(object sender, RoutedEventArgs e)   //Display Log
        {
            Utilities.DisplayFile(pathLog, ListBox);
        }



        private void NavBar_button2_Click(object sender, RoutedEventArgs e)  //Log direction selection
        {
            OpenFileDialogClass openFileDialogClass = new OpenFileDialogClass();
            var path= openFileDialogClass.FileSelection("txt | *.txt");
            if (path!=null)
            {
                pathLog = path;
            }
            
        }


        private void controlbtn_Click(object sender, RoutedEventArgs e)   //Calculation direction
        {
            OpenFileDialogClass openFileDialogClass = new OpenFileDialogClass();
            var path = openFileDialogClass.FileSelection("txt | *.txt");
            if (path != null)
            {
                pathCalculation = path;
            }

        }


        public void Logger()
        {

        }

    }
}

