using System;

namespace Task3
{
    class Program
    {
        static double functuon(double i)
        {
            return Math.Pow(i, 2);
        }
        static void Main(string[] args)
        {
            double area = 0;
            if (!(double.TryParse(Console.ReadLine(), out double delta) &&
                double.TryParse(Console.ReadLine(), out double A)))
            {
                Console.WriteLine("Проверьте введенные данные!");
            }
            else
            {
                A /= delta;
                while (A > 0) {
                    area += delta * (functuon(A * delta) + functuon((A - 1) * delta)) / 2;
                    A -= 1;
                }
                Console.WriteLine(area);
            }
        }
    }
}
