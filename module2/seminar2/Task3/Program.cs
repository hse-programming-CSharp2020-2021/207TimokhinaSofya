using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Point[] points = new Point[] { new Point(random.Next(-10, 10) + random.NextDouble(), random.Next(-10, 10) + random.NextDouble()),
            new Point(random.Next(-10, 10) + random.NextDouble(), random.Next(-10, 10) + random.NextDouble()), new Point(GetNumber(), GetNumber())};
            foreach (Point point in points.OrderBy(x => x.Ro))
            {
                Console.WriteLine(point.String);
            }
            Console.ReadLine();
        }

        static double GetNumber()
        {
            double number;
            do
            {
                Console.Write("Введите кординату: ");
            } while (!double.TryParse(Console.ReadLine(), out number));
            return number;
        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point() : this(0, 0) { }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public string String 
        {
            get
            {
                return $"{X}, {Y}, {Ro}, {Fi}";
            }
        }

        public double Ro
        {
            get
            {
                return Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5);
            }
        }
        public double Fi
        {
            get
            {
                if (X > 0 && Y >= 0)
                    return Math.Atan(Y / X);
                if (X > 0 && Y < 0)
                    return Math.Atan(Y / X) + 2 * Math.PI;
                if (X < 0)
                    return Math.Atan(Y / X) + Math.PI;
                if (X == 0 && Y > 0)
                    return Math.PI / 2;
                if (X == 0 && Y < 0)
                    return 3 * Math.PI / 2;
                return 0;
            }
        }
    }


}
