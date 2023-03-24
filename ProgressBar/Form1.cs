using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        int ProgressBarValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox1.Text) * 1000;
            if (ProgressBarValue >= 100)
                ProgressBarValue = 0;
            ProgressBarValue = ProgressBarValue + 10;
            progressBar1.Value=ProgressBarValue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            timer1.Interval = int.Parse(textBox1.Text)*1000;
            timer1.Start();
        }


    }
}
