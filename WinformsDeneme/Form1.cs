using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsDeneme
{
    public partial class Form1 : Form
    {
        bool PrimeValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = "";
            label2.Text = "";
            int IntegerValue;
                //=Int16.Parse(textBox2.Text);
            var  deger= int.TryParse(textBox2.Text, out IntegerValue);
            if (deger)
            {
                PrimeValue = PrimeTest(IntegerValue);
                if (PrimeValue)
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Bu sayı asaldır";
                    MessageBox.Show("Bu sayı asaldır");
                    for (int i = 2; i < IntegerValue; i++)
                    {
                        if(PrimeTest(i))
                           listBox1.Items.Add(i);
                    }

                    
                }
                else
                {
                    label1.ForeColor = Color.Blue;
                    label1.Text = "Bu sayı asal değildir";
                    MessageBox.Show("Bu sayı asal değildir");
                }
            }

            else
            {
                label2.Text = "Geçerli bir değer girin";
                MessageBox.Show("Geçerli bir değer girin");
            }
                



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
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
