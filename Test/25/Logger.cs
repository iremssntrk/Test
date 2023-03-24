using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test._25
{
    public class Logger
    {
        DirectoryInfo[] cDirs = new DirectoryInfo(@"C:\").GetDirectories();
        StreamWriter sw = new StreamWriter("CDriveDirs.txt");
        static Logger()
        {

        }
        public void Write(string message)
        {

            foreach (DirectoryInfo dir in cDirs)
            {
                sw.WriteLine(dir.Name);
                Console.WriteLine(dir.Name);
            }
        }

        public void Close()
        {
            sw.Close();
        }

    }
}
