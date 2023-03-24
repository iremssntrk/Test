using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator
{
    public static class Utilities
    {
        public static void DisplayFile(string path, ListBox ListBox)
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
        }
    }
}
