using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProgressBarWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        int ProgressBarValue;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            timer.Tick += timer1_Tick;
            timer.Interval = TimeSpan.FromSeconds(1000);
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(Convert.ToDouble(int.Parse(TextBox1.Text)) );
            if (ProgressBarValue >= 100)
                ProgressBarValue = 0;
            ProgressBarValue = ProgressBarValue + 10;
            ProgressBar1.Value = ProgressBarValue;
        }


        private void Window_Load(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "1";
            timer.Interval = TimeSpan.FromSeconds(Convert.ToDouble(int.Parse(TextBox1.Text)));
        }
    }



}










