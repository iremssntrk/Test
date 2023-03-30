using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MarineParamCalculatorMustafa
{
    internal class Logger
    {
        string _path;
        internal Logger(string path)
        {
            _path = path;
            string directory = System.IO.Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        internal void RenewPath(string path)
        {
            _path = path;
            string directory = System.IO.Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        internal void Log(string message) 
        {
            string output = Environment.NewLine + DateTime.Now.ToShortTimeString() + message;
            File.AppendAllText(_path, output);
        }
    }
}
