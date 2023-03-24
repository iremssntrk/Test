
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
using MarinePararmCalculator.FilePath;
using MarinePararmCalculator;
using MarinePararmCalculator.Entities;
using MarinePararmCalculator.Calculation;

namespace MarineParamCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathCalculation;
        string pathLog;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)  
        {

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;   //default location
            pathCalculation = System.IO.Path.Combine(directory, "calc.txt");
            pathCalculation = System.IO.Path.Combine(directory, "log.txt");
            //writer = File.CreateText(pathCalculation);
        }


        private void ButtonClick(object sender, RoutedEventArgs e)  
        {
            List<CalculationParameter> calculatedParams = new List<CalculationParameter>();
            CalculationParameter Params = new CalculationParameter();
            Params.Cb=Int32.Parse(Cb_Text.Text);
            Params.Delta = Int32.Parse(Delta_Text.Text);
            Params.B = Int32.Parse(B_Text.Text);
            Params.L = Int32.Parse(L_Text.Text);
            Params.T = Int32.Parse(T_Text.Text);

            Calculator calculator = new Calculator();
            calculatedParams=calculator.Delta(Params);
            calculator.Cb(ref calculatedParams, Params);

            foreach (var item in calculatedParams)
            {
                item.L = Params.L;
                item.T = Params.T;
                item.B = Params.B;
            }
            Utilities.WriteText(calculatedParams, pathCalculation);
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

