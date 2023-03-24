using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        static Logger()
        {
            _writer = new StreamWriter("log.txt", true);
        }

        public static void Write(string message)
        {
            _writer.WriteLine(message);
        }

        private static StreamWriter _writer;

        public static void Close()
        {
            _writer.Close();
        }
    }
}
