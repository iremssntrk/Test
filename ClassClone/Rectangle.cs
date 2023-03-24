using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClassClone
{
    public class Rectangle:Shape
    {
        public Rectangle(double height, double width)
        {
            _height = height;
            _width = width;
        }

        private double _height;

        private double _width;

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public override Shape Clone()
        {
            var clone_rect = new Rectangle(_height, _width);
            return clone_rect;
        }

        public override bool Equals(object obj)
        {
            var another_rect = (Rectangle)obj;
            if(_width == another_rect.Width)
            {
                return true;
               
            }
            else
            {
                return false;
            }
        }
    }
}
