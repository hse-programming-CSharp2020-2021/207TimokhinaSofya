using System;

namespace Task3
{
    class Program
    {
        static double function(double i)
        {
            return Math.Pow(i, 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите esc");
            do
            {
                Console.WriteLine("Введите A и delta.");
                if (!(double.TryParse(Console.ReadLine(), out double delta) &&
                    double.TryParse(Console.ReadLine(), out double A)))
                {
                    Console.WriteLine("Проверьте введенные данные!");
                }
                else
                {
                    int n = (int)(A / delta);
                    double result = 0;
                    for (int i = 0; i < n; i++)
                    {
                        result += delta *
                            (function(i * delta) + function((i + 1) * delta)) / 2;
                    }
                    Console.WriteLine(result);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
