using System;

namespace hw_1
{
    class Program
    {
        static double function(double x)
        {
            return Math.Round(3 * x * x * (x + 1) * (4 * x - 1) + 2 * (x - 4), 3);
        }
        static void Main(string[] args)
        {
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write(function(x));
            }
            else
            {
                Console.WriteLine("Неверное значение!");
            }
        }
    }
}
