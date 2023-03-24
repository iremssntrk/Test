using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myprocess = new Process();

            var process_del = new Process.UpdateProgress(ShowMessage);

            myprocess.Run(process_del);
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
