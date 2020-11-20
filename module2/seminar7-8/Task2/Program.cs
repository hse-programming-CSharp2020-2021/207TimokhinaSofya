using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            point.Display();
            Console.WriteLine($"point.Area для Point = {point.Area}");
            point = new Circle(1, 2, 6);
            point.Display();
            Console.WriteLine($"point.Area для Circle = {point.Area}");
            point = new Square(3, 5, 8);
            point.Display();
            Console.WriteLine($"point.Area для Square = {point.Area}");
            Console.ReadLine();
        }
    }
}
