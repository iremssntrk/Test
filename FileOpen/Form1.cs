using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileOpen
{
    public partial class Form1 : Form
    {
        string[] 
            s = new string[30];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (var item in Directory.GetFiles(@"C:\Users\isenturk\Desktop"))
            {
                comboBox2.Items.Add(item);
                //paths[counter] = item;
                counter = counter + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filedialog = new OpenFileDialog();
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                var path = filedialog.FileName;
                comboBox1.Items.Clear();
                //path = paths[comboBox2.SelectedIndex];
                foreach (var item in Read(path))
                {
                    comboBox1.Items.Add(item.ToString());
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private List<string> Read(string path)
        {
            List<string> ReadedString = new List<string>();
            String line;
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                ReadedString.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            return ReadedString;
        }
    }
}
