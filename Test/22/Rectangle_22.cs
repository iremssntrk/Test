using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test._22
{
    public class Rectangle_22 : IArea
    {
        public double GetArea(double a,double b)
        {
            return a*b;
        }

        public double GetArea(double a)
        {
            throw new NotImplementedException();
        }
    }
}
