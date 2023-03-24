using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Rectangle: ShapeBaseClass
    {
        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }
        public double Width;

        public double Height;
        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
