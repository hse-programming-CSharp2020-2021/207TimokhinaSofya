using System;
namespace Task2
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        internal protected double area;
        internal protected double len;

        public Point() { }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Display() { Console.WriteLine($"Точка"); }
        public virtual double Area => area;
        public virtual double Len => len;
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    class Circle: Point
    {
        private double rad;
        private Point center;
        public Circle(double x, double y, double rad)
        {
            this.rad = rad;
            center = new Point(x, y);
            area = Math.PI * Math.Pow(rad, 2);
            len = 2 * Math.PI * rad;
        }
        public double Rad => rad;
        public override double Area => area;
        public override double Len => len;
        public override void Display()
        {
            Console.WriteLine($"Круг, центр в точке {center}, радиус = {rad}");
        }
    }

    class Square: Point
    {
        private double side;
        private Point center;
        public Square(double x, double y, double side)
        {
            center = new Point(x, y);
            this.side = side;
            area = Math.Pow(side, 2);
            len = 4 * side;

        }

        public double Side => side;
        public override double Area => area;
        public override double Len => len;
        public override void Display()
        {
            Console.WriteLine($"Квадрат, центр в точке {center}, сторона = {side}");
        }
    }
}
