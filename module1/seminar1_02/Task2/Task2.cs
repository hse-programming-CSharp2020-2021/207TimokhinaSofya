using System;

namespace Task2
{
    class Program
    {
        static double ReturnFib(int n)
        {
            double b = (1 + Math.Pow(5, 0.5)) / 2;
            double fib = ((Math.Pow(b, n) - Math.Pow(-b, -n)) / (2 * b - 1));
            return Math.Round(fib);
        }
        static void Main(string[] args)
        {
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if (number > 0 && success)
            {
                double fib = ReturnFib(number);
                Console.WriteLine(fib);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}

