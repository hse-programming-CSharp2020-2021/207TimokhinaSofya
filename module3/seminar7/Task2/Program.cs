using System;
using System.Diagnostics.CodeAnalysis;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Structures.CircleS circle1 = new Structures.CircleS(1, 3, 7);
            Structures.CircleS circle2 = new Structures.CircleS(-1, 6, 5);
            Console.WriteLine(circle1.CompareTo(circle2));
            Console.ReadKey();
        }
    }
}

// Это библиотека.
namespace Structures
{
    struct PointS
    {
        double x, y;

        public double X
        {
            get => x;
            set => x = value;
        }

        public double Y
        {
            get => y;
            set => y = value;
        }

        public PointS(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(PointS other) => Math.Sqrt(Math.Pow(x - other.X, 2) + Math.Pow(y - other.y, 2));
    }

    struct CircleS : IComparable<CircleS>
    {
        PointS centre;
        double rad;

        public double Rad
        {
            get => rad;
            set => rad = value < 0 ? throw new ArgumentException() : value;

        }

        public PointS Centre
        {
            get => centre;
            set => centre = value;
        }

        public CircleS(double x, double y, double rad)
        {
            centre = new PointS(x, y);
            this.rad = rad < 0 ? throw new ArgumentException() : rad;
        }

        public int CompareTo([AllowNull] CircleS other) => rad.CompareTo(other.rad);
    }
}