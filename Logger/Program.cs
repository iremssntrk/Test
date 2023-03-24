using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Write("Hello world! from static");

            Logger.Write("Hello, from static");

            Logger.Close();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
