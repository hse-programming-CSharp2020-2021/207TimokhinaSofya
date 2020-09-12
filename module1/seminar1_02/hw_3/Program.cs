using System;

namespace hw_3
{
    class Program
    {
        public static double discriminant(double A, double B, double C)
        {
            return Math.Pow(B, 2) - 4 * A * C;
        }
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                double discr = Math.Pow(discriminant(a, b, c), 0.5);
                Console.WriteLine(discr >= 0 ? $"x1 = {((-b - discr) / (2 * a)).ToString("f3")}, x2 = {((-b + discr) / (2 * a)).ToString("f3")}":
                    "Нет корней или уравнение не квадратное");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
    }
}

