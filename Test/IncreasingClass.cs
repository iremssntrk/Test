using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class IncreasingClass
    {
        static int counter;

        public int id;
        public IncreasingClass()
        {
            counter = counter + 1;
            id = counter;
            //Console.WriteLine(counter);
        }
    }
}
