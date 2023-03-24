using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test._22
{
    public class Circle_22:IArea
    {
        public readonly int _a;
        public Circle_22(int a)
        {
            _a = a;
        }
        public double GetArea(double a)
        {
            return Math.PI * a * a;
        }

        public double GetArea(double a, double b)
        {
            throw new NotImplementedException();
        }

    }
}
