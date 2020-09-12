using System;
using System.Collections.Generic;

namespace hw_7
{
    class Program
    {
        static List<double> separation(double number)
        {
            double full = Math.Truncate(number);
            double frac = number - full;
            return new List<double> { full, frac };
        }
        static List<double> updown(double number)
        {
            double root = number > 0 ? Math.Pow(number, 0.5): -1;
            double sqr = Math.Pow(number, 2);
            return new List<double> { root, sqr };
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                var sep = separation(number);
                var ud = updown(number);;
                Console.WriteLine($"Квадрат числа равен: {ud[1].ToString("f3")}. \r\n" +
                    $"Корень: {(ud[0] == -1 ? "не удалось вычислить.": ud[0].ToString("f3"))}. \r\n" +
                    $"Целая часть = {sep[0]}, дробная = {sep[1].ToString("f3")}.");

            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
