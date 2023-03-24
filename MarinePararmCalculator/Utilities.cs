using MarinePararmCalculator.Entities;
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



        public static void WriteText(List<CalculationParameter> calculatedParams, string Path)
        {
            StreamWriter writer;
            writer = File.CreateText(Path);
            writer.WriteLine($"{"[B]",-11:f} {"[L]",-11:f} {"[T]",-11:f} {"[Cb]",-11:f} {"[Δ]",-11:f} ");
            foreach (CalculationParameter param in calculatedParams)
            {
                writer.WriteLine($"{param.B,-11:f} {param.L,-11:f} {param.T,-11:f} {param.Cb.ToString("0.00"),-11:f} {param.Delta.ToString("0.00"),-11:f} ");
            }
            writer.Close();

        }
    }
}
