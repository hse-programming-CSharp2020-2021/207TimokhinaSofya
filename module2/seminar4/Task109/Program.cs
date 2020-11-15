using System;
using System.Linq;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int N;
                do
                {
                    Console.Write("Введите число N > 0: ");
                } while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);
                Random random = new Random();
                Circle[] circles = Enumerable.Range(0, N).Select(eq => new Circle(random.Next(-10, 11), random.Next(-10, 11), random.Next(-10, 11))).ToArray();
                Circle circle = new Circle(random.Next(-10, 11), random.Next(-10, 11), random.Next(-10, 11));
                foreach (Circle circle1 in circles)
                    circle1.Print(circle);
                Console.WriteLine("Для выхода нажмите esc, для повтора - любую другую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class Circle
    {
        public double x, y, radius;
        public Circle() { }
        public Circle(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        private bool Cross(Circle circle)
        {
            return Math.Pow(Math.Pow(x - circle.x, 2) + Math.Pow(y - circle.y, 2), 0.5) <= radius + circle.radius;
        }

        public void Print(Circle circle = null)
        {
            Console.WriteLine($"Центр: ({x},{y}), радиус = {radius} {(circle != null ? Cross(circle) ? "пересекается": "": "")}");
        }
    }
}
