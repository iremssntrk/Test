using MarinePararmCalculator.Entities;
using MarinePararmCalculator.Utilities.Error;
using MarinePararmCalculator.Utilities.FilePath.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator.Utilities
{
    public class StreamReaderClass: IFileSelection
    {
        public IResult DisplayFile(string path, ListBox ListBox)
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
            return new Result(true);
        }

        public IResult WriteFile(List<Parameter> calculatedParams, string Path)
        {
            System.IO.StreamWriter writer;
            writer = File.CreateText(Path);
            writer.WriteLine($"{"[B]",-12:f} {"[L]",-14:f} {"[T]",-13:f} {"[Cb]",-13:f} {"[Δ]",-30:f} ");
            foreach (Parameter param in calculatedParams)
            {
                writer.WriteLine($"{param.B,-11:f} {param.L,-11:f} {param.T,-11:f} {param.Cb.ToString("0.00"),-11:f} {param.Delta.ToString("0.00"),-11:f} ");
            }
            writer.Close();
            return new Result(true);
        }
    }
}
