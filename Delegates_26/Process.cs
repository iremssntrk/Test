using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates_26
{
    public class Process
    {
        public Process()
        {

        }

        public delegate void UpdateProgress(string message);

        public void Run(UpdateProgress progress)
        {
            progress("Started");
            Thread.Sleep(1000);
            progress("Stage 1");
            Thread.Sleep(1000);
            progress("Stage 2");
            Thread.Sleep(1000);
            progress("Finished");
        }
    }

    
}
