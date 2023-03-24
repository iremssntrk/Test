using BloneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CloneClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person() { Id = 123, Name = "Ahmet" };
            Person b = new Person();
            Clone.CopyTo(a, b);
            Console.WriteLine(b.Name);
        }
    }
}



