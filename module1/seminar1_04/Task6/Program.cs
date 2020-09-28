using System;
using System.Linq;

namespace Task6
{
    class Program
    {
        static double First_Funk(double x)
        {
            double old_sum = -1;
            double sum = 0;
            int index = 0;
            while ((old_sum - sum) != 0 && !double.IsNaN(sum))
            {
                old_sum = sum;
                sum += Math.Pow(-1, index) * Math.Pow(x, index * 2) * Math.Pow(2, index + 2) /
                    Enumerable.Range(1, index + 2).Aggregate(1, (p, item) => p * item);
                index++;
            }
            return sum;
        }

        static double Second_Funk(double x)
        {
            double old_sum = -1;
            double sum = 0;
            int index = 0;
            while ((old_sum - sum) != 0 && !double.IsNaN(sum) && !(sum > double.MaxValue))
            {
                old_sum = sum;
                sum += Math.Pow(x, index) / Enumerable.Range(1, index).Aggregate(1, (p, item) => p * item);
                index++;
            }
            return sum;

        }
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("x больше нуля. Введите еще раз: ");
            }
            Console.WriteLine($"Первая функция при x = {x} равна {First_Funk(x)}.");
            Console.WriteLine($"Первая функция при x = {x} равна {Second_Funk(x)}.");
        }
    }
}
