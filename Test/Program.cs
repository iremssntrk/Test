// See https://aka.ms/new-console-template for more information

using System.Drawing;
using Test;
using Test._25;
using Test._22;
using Test._26;
using Test._27;
using Rectangle = Test.Rectangle;

internal class Program
{
    delegate void Temsilci(int s1);
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Method_15();
        //Method_16();
        //Method_18();
        //method_19();

        //Method_22();

        //Method_25();

        //Method_26();
        //Method_27();

    }

    private static void Method_25()
    {
        Logger logger = new Logger();
        logger.Write("deneme");
    }

    private static void Method_22()
    {
        Circle_22 circle = new Circle_22(5);
        Console.WriteLine(circle.GetArea(2));
        Rectangle_22 rectangle = new Rectangle_22();
        Console.WriteLine(rectangle.GetArea(2, 6));
    }

    private static void Method_26()
    {
        Process process = new Process();
        Temsilci UpdateProgress = process.Run;
        UpdateProgress(55);
    }

    private static void Method_27()
    {
        List<int> integers = new List<int> { 2, 4, 7, 9, 10, 11, 12 };
        EvenNumbersFinder evenNumbersFinder = new EvenNumbersFinder();
        ;
        foreach (var item in evenNumbersFinder.EvenNumber(integers).ToList())
        {
            Console.WriteLine(item);
        }
    }

    //private static void method_19()
    //{
    //    Circle circle = new Circle();
    //    Console.WriteLine(circle.GetArea(3));

    //    Rectangle rectangle = new Rectangle();
    //    Console.WriteLine(rectangle.GetArea(3, 4));
    //}

    private static void Method_18()
    {
        IncreasingClass increasingClass = new IncreasingClass();
        IncreasingClass increasingClass2 = new IncreasingClass();
        IncreasingClass increasingClass3 = new IncreasingClass();
        IncreasingClass increasingClass4 = new IncreasingClass();
        IncreasingClass increasingClass5 = new IncreasingClass();

        Console.WriteLine(increasingClass5.id);
    }

    private static void Method_16()
    {
        VectorCalculator vectorCalculator = new VectorCalculator(3, 6, 4, 8);
        //double Vector = vectorCalculator.Vector();
        //Console.WriteLine(Vector);
    }
    private static void Method_15()
    {
        RectangleCalculator rectangleCalculator = new RectangleCalculator(4.7, 5);
        double Area = rectangleCalculator.Area();
        Console.WriteLine(Area);
    }
}