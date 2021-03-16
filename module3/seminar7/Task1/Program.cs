using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Circle circle = new Circle(random.Next(-10, 10), random.Next(-10, 10), random.Next(-10, 10));
                    Console.WriteLine(circle);
                }
                catch { Console.WriteLine("!"); }
            }
            Console.ReadKey();
        }

    }
    struct Coords
    {
        double x;
        double y;

        public Coords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"x = {x}, y = {y}";
    }

    class Circle
    {
        Coords centre;
        double rad;

        public double Rad
        {
            get => rad;
            set => rad = value < 0 ? throw new ArgumentException() : value;
        }
        public Circle(double x, double y, double rad)
        {
            centre = new Coords(x, y);
            Rad = rad;
        }

        public override string ToString() => $"radius = {Rad}, centre = {centre}";
    }
}
