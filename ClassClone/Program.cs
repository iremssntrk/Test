using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rec_org = new Rectangle(5, 10);
            var circ_org = new Circle(5);

            var rect_clone = (Rectangle)rec_org.Clone();

            var circ_clone = (Circle)circ_org.Clone();

            rect_clone.Height = 15;

            circ_clone.Radius = 20;
        }
    }
}
