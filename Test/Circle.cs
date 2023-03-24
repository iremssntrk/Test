using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Circle : ShapeBaseClass
    {
      public Circle(double r)
        {
            Radius = r;
        }
        
        public double Radius;

        public override double GetArea()
        {
            return Math.PI* System.Math.Pow(Radius, 2);
        }
    }
}
