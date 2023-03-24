using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace WpfDeneme
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        bool PrimeValue;
        public MainWindow()
        {

            InitializeComponent();
        }
        int counter;

        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            ListBox1.Items.Clear();
            Label1.Content = "";
            Label1.Content = "";
            int IntegerValue;
            //=Int16.Parse(textBox2.Text);
            var deger = int.TryParse(TextBox2.Text, out IntegerValue);
            if (deger)
            {
                PrimeValue = PrimeTest(IntegerValue);
                if (PrimeValue)
                {
                    Label1.Content = "Bu sayı asaldır";
                    MessageBox.Show("Bu sayı asaldır");
                    for (int i = 2; i < IntegerValue; i++)
                    {
                        if (PrimeTest(i))
                            ListBox1.Items.Add(i);
                    }


                }
                else
                {
                    Label1.Content = "Bu sayı asal değildir";
                    MessageBox.Show("Bu sayı asal değildir");
                }
            }

            else
            {
                Label1.Content = "Geçerli bir değer girin";
                MessageBox.Show("Geçerli bir değer girin");
            }



        }

        private bool PrimeTest(int Value)
        {
            int counter = 0;
            PrimeValue = false;
            for (int i = 2; i < Value; i++)
            {
                if ((Value % i) == 0)
                {
                    counter = counter + 1;
                }

            }
            if (counter == 0)
                return true;
            return false;
        }
    }
}









