using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle first = new Triangle(1, 2, 3, 4, 5, 6);
            Console.WriteLine($"Площадь: {first.Area}, периметр: {first.Perimetr}");
            Triangle second = new Triangle(new Point(0, 0), new Point(4, 0), new Point(2, 4));
            Console.WriteLine($"Площадь: {second.Area}, периметр: {second.Perimetr}");
            Console.ReadLine();
        }
    }

    class Point
    {
        private double X;
        private double Y;
        public Point() { }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double x
        {
            get { return X; }
        }

        public double y
        {
            get { return Y; }
        }
    }

    class Triangle
    {
        private Point point1;
        private Point point2;
        private Point point3;
        private double[] lengh = new double[3];
        static Triangle() { }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            point1 = new Point(x1, y1);
            point2 = new Point(x2, y2);
            point3 = new Point(x3, y3);
            GetLenght();
        }


        public Triangle(Point one, Point two, Point three)
        {
            point1 = one;
            point2 = two;
            point3 = three;
            GetLenght();
        }


        public double Area
        {
            get
            {
                double p = (lengh[0] + lengh[1] + lengh[2]) / 2;
                return Math.Pow(p * (p - lengh[0]) * (p - lengh[1]) * (p - lengh[2]), 0.5);
            }
        }

        public double Perimetr
        {
            get { return lengh.Sum(); }
        }

        private void GetLenght()
        {
            lengh[0] = Math.Pow(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2), 0.5);
            lengh[1] = Math.Pow(Math.Pow(point1.x - point3.x, 2) + Math.Pow(point1.y - point3.y, 2), 0.5);
            lengh[2] = Math.Pow(Math.Pow(point2.x - point3.x, 2) + Math.Pow(point2.y - point3.y, 2), 0.5);
        }
    }
}
