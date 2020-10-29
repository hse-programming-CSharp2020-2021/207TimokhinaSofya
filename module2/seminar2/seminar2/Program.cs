using System;
using System.Linq;

namespace seminar2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            // Мне лень запрашивать минимальный и максимальный радиусы.
            double Rmin = 11;
            double Rmax = 19;
            n = 12;
            //do
            //{
            //    Console.Write("Введите число: ");
            //} while (!int.TryParse(Console.ReadLine(), out n));

            Random random = new Random();
            Circle[] circles = new Circle[n];
            for(int i = 0; i < n; i ++)
            {
                circles[i] = new Circle(random.Next(Convert.ToInt32(Rmin - Rmin % 1),
                    Convert.ToInt32(Rmax - Rmax % 1)) + random.NextDouble());
                circles[i].GetValues();
            }
            Console.WriteLine($"Масимальная площадь: {circles.Max(Circle => Circle.S)}");
            Console.ReadLine();
        }
    }
    class Circle
    {
        double r;
        public double Radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Число меньше 0!");
                r = value;
            }
        }

        public double S
        {
            get
            {
                return Math.PI * Math.Pow(r, 2);
            }
        }

        public double Length
        {
            get
            {
                return Math.PI * r * 2;
            }
        }
        public Circle()
        {
            Radius = 1;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public void GetValues()
        {
            Console.WriteLine($"Радиус {Radius:f3}, площадь {S:f3}, длина {Length:f3}");
        }

    }
}
