
using Microsoft.Win32;
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
using System.Drawing;
using MarinePararmCalculator.FilePath;
using MarinePararmCalculator;
using MarinePararmCalculator.Entities;
using MarinePararmCalculator.Calculation;
using MarinePararmCalculator.Utilities;
using System.Runtime.Remoting.Contexts;
using MarinePararmCalculator.Utilities.FilePath;
using MarinePararmCalculator.Utilities.Error;

namespace MarineParamCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string settedPathForCalculation;
        string settedPathForLog;
        FileManagement fileIOManagement;
        Parameter Model { get; set; }
        CalculationManager calculationManager { get; set; }
        public MainWindow()
        {
            fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamRWClass());
            Model = new Parameter();
            calculationManager = new CalculationManager(Model, new CbCalculator(), new DeltaCalculator());
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {        
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;   //default location
            settedPathForCalculation = System.IO.Path.Combine(directory, "calc.txt");
            settedPathForLog = System.IO.Path.Combine(directory, "log.txt");
        }


        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            var result = calculationManager.CalculateAndPrint(settedPathForCalculation, settedPathForLog);
            MessageBox.Show(result.Message);
        }


        private void NavBar_button3_Click(object sender, RoutedEventArgs e)   //Display calculation
        {
            var result = fileIOManagement.DisplayFile(settedPathForCalculation, ListBox);
        }

        private void NavBar_button4_Click(object sender, RoutedEventArgs e)   //Display Log
        {
            var result = fileIOManagement.DisplayFile(settedPathForLog, ListBox);

        }

        private void NavBar_button2_Click(object sender, RoutedEventArgs e)  //Log direction selection
        {
            var result = fileIOManagement.FileSelection("txt | *.txt");
            if (result.Result)
            {
                fileIOManagement.LogToFile(MessageString.LogFilePathChanged, settedPathForLog);
                settedPathForLog = result.Data;
            }
            else
            {
                fileIOManagement.LogToFile(result.Message, settedPathForLog);
                MessageBox.Show(result.Message);
            }
        }

        private void controlbtn_Click(object sender, RoutedEventArgs e)   //Calculation direction
        {
            var result = fileIOManagement.FileSelection("txt | *.txt");
            if (result.Result)
            {
                fileIOManagement.LogToFile(MessageString.CalculationFilePathChanged, settedPathForLog);
                settedPathForCalculation = result.Data;
            }     
            else
            {
                fileIOManagement.LogToFile(result.Message, settedPathForLog);
                MessageBox.Show(result.Message);
            }
                
        }


        private void Cb_Text_TextChanged(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(Cb_Text.Text, out parsedValue);
            if (isParsed)
            {
                Model.Cb = parsedValue;
                var result = calculationManager.CalculateDelta();
                if (result.Result)
                {
                    Delta_Text.Text = (result.Data).ToString();
                    Model.Delta = result.Data;
                }
                else
                    MessageBox.Show(result.Message);
            }
            else
            {
                Cb_Text.Text = "0";
            }
             
        }

        private void Delta_Text_TextChanged(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(Delta_Text.Text, out parsedValue);
            if (isParsed)
            {
                Model.Delta= parsedValue;
                var result = calculationManager.CalculateCb();
                if (result.Result)
                {
                    Cb_Text.Text = (result.Data).ToString();
                    Model.Cb = result.Data;
                }      
                else
                    MessageBox.Show(result.Message);
            }
            else
            {
                Delta_Text.Text = "0";
            }
        }

        private void B_Text_KeyUp(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(B_Text.Text, out parsedValue);
            if (isParsed)
            {
                Model.B = parsedValue;
                var result = calculationManager.CalculateDelta();
                if (result.Result)
                    Delta_Text.Text = (result.Data).ToString();
                else
                    MessageBox.Show(result.Message);
            }
            else
            {
                B_Text.Text = "0";
            }
        }

        private void L_Text_KeyUp(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(L_Text.Text, out parsedValue);
            if (isParsed)
            {
                Model.L = parsedValue;
                var result = calculationManager.CalculateDelta();
                if (result.Result)
                    Delta_Text.Text = (result.Data).ToString();
                else
                    MessageBox.Show(result.Message);
            }
            else
            {
                L_Text.Text = "0";
            }
        }

        private void T_Text_KeyUp(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(T_Text.Text, out parsedValue);
            if (isParsed)
            {
                Model.T = parsedValue;
                var result = calculationManager.CalculateDelta();
                if (result.Result)
                    Delta_Text.Text = (result.Data).ToString();
                else
                    MessageBox.Show(result.Message);
            }
            else
            {
                T_Text.Text = "0";
            }
        }
    }


}

