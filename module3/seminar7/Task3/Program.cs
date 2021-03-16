using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for(int i = 0; i < 10; i ++)
            {
                PointsSet pointsSet = new PointsSet(random.Next(2, 10), random.Next(10, 20));
                Console.WriteLine(pointsSet);
            }
            Console.ReadKey();
        }
    }

    struct Point
    {
        public double mass;

        public Point(double mass) => this.mass = mass;
    }

    class PointsSet
    {
        public double Rad { get; set; }
        private Point[] PointArray { set; get; }
        public Point GetRandomPoint() => new Point((new Random()).Next(0, (int)Rad) + (new Random()).NextDouble());

        public PointsSet(int count, double rad)
        {
            Rad = rad;
            PointArray = Enumerable.Range(1, count).Select(x => GetRandomPoint()).ToArray();
        }

        public override string ToString() => $"{PointArray.Length} points, radius = {Rad}, mass = {Mass.ToString("#.##")}";

        private double Mass => PointArray.Select(x => x.mass).ToArray().Sum();

    }
}
