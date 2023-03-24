using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class RectangleCalculator
    {
        double _height;
        double _widht;
        public RectangleCalculator(double height, double width)
        {
            _height = height;
            _widht = width;
        }

        public double Area()
        {
            return _height * _widht;
        }
    }
}
