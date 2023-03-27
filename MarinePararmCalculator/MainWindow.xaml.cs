
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
            pathLog = System.IO.Path.Combine(directory, "log.txt");
        }


        private void CalculateButtonClick(object sender, RoutedEventArgs e)  
        {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result = calculationManager.CalculateAndPrint(T_Text.Text, B_Text.Text, L_Text.Text, Cb_Text.Text, Delta_Text.Text, pathCalculation);
            MessageBox.Show(result.Message);
        }


        private void NavBar_button3_Click(object sender, RoutedEventArgs e)   //Display calculation
        {
            FileManagement fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamReaderClass());
            var result = fileIOManagement.DisplayFile(pathCalculation, ListBox);
        }

        private void NavBar_button4_Click(object sender, RoutedEventArgs e)   //Display Log
        {
            FileManagement fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamReaderClass());
            var result = fileIOManagement.DisplayFile(pathLog, ListBox);

        }

        private void NavBar_button2_Click(object sender, RoutedEventArgs e)  //Log direction selection
        {
            FileManagement fileIOManagement = new FileManagement(new OpenFileDialogClass(),new StreamReaderClass());
            var result = fileIOManagement.FileSelection("txt | *.txt");
            if (result.Result)
                pathLog = result.Data;
            else
                MessageBox.Show(result.Message);

        }

        private void controlbtn_Click(object sender, RoutedEventArgs e)   //Calculation direction
        {
            FileManagement fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamReaderClass());
            var result = fileIOManagement.FileSelection("txt | *.txt");
            if (result.Result)
                pathCalculation = result.Data;
            else
                MessageBox.Show(result.Message);
        }


        private void Cb_Text_TextChanged(object sender, KeyEventArgs e)
       {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result=calculationManager.CalculateDelta(T_Text.Text, B_Text.Text, L_Text.Text, Cb_Text.Text);
            if (result.Result)
                Delta_Text.Text =(result.Data).ToString();     
            else
                MessageBox.Show(result.Message);        
        }

        private void Delta_Text_TextChanged(object sender, KeyEventArgs e)
        {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result = calculationManager.CalculateCb(T_Text.Text, B_Text.Text, L_Text.Text, Delta_Text.Text);
            if (result.Result)
                Cb_Text.Text = (result.Data).ToString();
            else
                MessageBox.Show(result.Message);
        }

        private void B_Text_KeyUp(object sender, KeyEventArgs e)
        {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result = calculationManager.CalculateDelta(T_Text.Text, B_Text.Text, L_Text.Text, Cb_Text.Text);
            if (result.Result)
                Delta_Text.Text = (result.Data).ToString();
            else
                MessageBox.Show(result.Message);
        }

        private void L_Text_KeyUp(object sender, KeyEventArgs e)
        {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result = calculationManager.CalculateDelta(T_Text.Text, B_Text.Text, L_Text.Text, Cb_Text.Text);
            if (result.Result)
                Delta_Text.Text = (result.Data).ToString();
            else
                MessageBox.Show(result.Message);
        }

        private void T_Text_KeyUp(object sender, KeyEventArgs e)
        {
            CalculationManager calculationManager = new CalculationManager(new CbCalculator(), new DeltaCalculator());
            var result = calculationManager.CalculateDelta(T_Text.Text, B_Text.Text, L_Text.Text, Cb_Text.Text);
            if (result.Result)
                Delta_Text.Text = (result.Data).ToString();
            else
                MessageBox.Show(result.Message);
        }
    }


}

