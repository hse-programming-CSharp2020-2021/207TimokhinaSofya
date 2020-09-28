using System;

namespace HW_3
{
    class Program
    {
        static void Funk(double a, double b, double c)
        {
            double x = 1;
            double res;
            while (x <= 2.01)
            {
                if (x < 1.2)
                    res = a * Math.Pow(x, 2) + b * x + c;
                else if (x == 1.2)
                    res = a / x + Math.Pow(Math.Pow(x, 2) + 1, 0.5);
                else
                    res = (a + b * x) / (Math.Pow(Math.Pow(x, 2) + 1, 0.5));
                Console.WriteLine("x = {0:f2}, y = {1:f5}.", x, res);
                x += 0.05;
            }
                
        }

        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Ошибка");
                return;
            }
            Console.Write("Введите b: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("Ошибка");
                return;
            }
            Console.Write("Введите c: ");
            if (!double.TryParse(Console.ReadLine(), out double c))
            {
                Console.WriteLine("Ошибка");
                return;
            }
            Funk(a, b, c);
            Console.ReadLine();

        }
    }
}
