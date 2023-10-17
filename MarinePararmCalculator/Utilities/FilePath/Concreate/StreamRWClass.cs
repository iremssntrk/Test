using MarinePararmCalculator.Entities;
using MarinePararmCalculator.Utilities.Error;
using MarinePararmCalculator.Utilities.FilePath.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator.Utilities
{
    public class StreamRWClass: IFileSelection
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

        public IResult WriteFile(string message, string path)
        {
            StreamWriter writer= new StreamWriter(path, true);
            writer.WriteLine(message);
            writer.Close();
            return new Result(true);
        }

        public void ClearFile(string path)
        {
            StreamWriter writer = new StreamWriter(path, false);
            writer.Flush();
            writer.Close();
        }

    }
}
