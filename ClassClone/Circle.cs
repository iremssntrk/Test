using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClone
{
    public class Circle:Shape
    {
        public Circle(double radius)
        {
            _radius = radius;
        }

        private double _radius;

        public double Radius
        {
            get;
            set;
        }

        public override Shape Clone()
        {
            var clone_circle = new Circle(_radius);
            return clone_circle;
        }
    }
}
