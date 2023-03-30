
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
using System.Runtime.Remoting.Contexts;
using System.IO;

namespace MarineParamCalculatorMustafa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model _model;
        string _pathOfOutput;
        string _pathOfLogging;
        Logger _logger;
        public MainWindow()
        {
            _model = new Model();
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {        
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);   //default location
            _pathOfOutput = System.IO.Path.Combine(directory, "calc.txt");
            _pathOfLogging = System.IO.Path.Combine(directory, "log.txt");
            _logger = new Logger(_pathOfLogging);
        }


        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator(_model, 6, _logger);
            MessageBox.Show(calculator.ToString());
        }


        private void NavBar_button3_Click(object sender, RoutedEventArgs e)   //Display calculation
        {
            DisplayFile(_pathOfOutput, ListBox);
        }

        private void NavBar_button4_Click(object sender, RoutedEventArgs e)   //Display Log
        {
            DisplayFile(_pathOfLogging, ListBox);
        }

        private void NavBar_button2_Click(object sender, RoutedEventArgs e)  //Log direction selection
        {
            //Select Logg directory
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "txt | *.txt";
            if (filedialog.ShowDialog() == true)
            {
                string oldPath = _pathOfLogging;
                _pathOfLogging = filedialog.FileName;
                _logger.RenewPath(_pathOfLogging);
                _logger.Log("Logging path is changed from " + oldPath);
            }
            else
            {
                MessageBox.Show("no path is selected");
            }
        }

        private void controlbtn_Click(object sender, RoutedEventArgs e)   //Calculation direction
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "txt | *.txt";
            if (filedialog.ShowDialog() == true)
            {
                string oldPath = _pathOfOutput;
                _pathOfOutput = filedialog.FileName;
                _logger.Log("Output path is changed from " + oldPath + " to " + _pathOfOutput);
            }
            else
            {
                MessageBox.Show("no path is selected");
            }
        }


        private void Cb_Text_TextChanged(object sender, KeyEventArgs e)
        {
            double parsedValue;
            bool isParsed = double.TryParse(Cb_Text.Text, out parsedValue);
            if (isParsed)
            {
                _model.SetCb(parsedValue);                
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
                _model.SetDelta(parsedValue);
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
                _model.SetB(parsedValue);
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
                _model.SetL(parsedValue);
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
                _model.SetT(parsedValue);
            }
            else
            {
                T_Text.Text = "0";
            }
        }

        private bool DisplayFile(string path, ListBox ListBox)
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
            return true;
        }

    }


}

