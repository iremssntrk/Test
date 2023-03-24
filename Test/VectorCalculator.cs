using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class VectorCalculator
    {
        public double X;

        public double Y;

        public VectorCalculator(double x1,double x2, double y1, double y2)
        {
            X = x2 - x1;
            X = y2 - y1;
        }

        public VectorCalculator(double d1, double d2)
        {
            X = d1;
            Y = d2;
        }


    }
}
