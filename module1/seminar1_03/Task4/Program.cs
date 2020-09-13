using System;

namespace Task04
{
    class Program
    {
        static bool Newton(double x, out double sq, out double eps)
        {
            sq = eps = 0;
            if (x <= 0.0)
            {
                Console.WriteLine("Ошибка");
                return false;
            }
            double r1, r2 = x;
            do
            {
                r1 = r2;
                eps = x / r1 / 2 - r1 / 2;
                r2 = r1 + eps;
            } while (r1 - r2 != 0); 
            sq = r2;
            return true;
        }

        static void Main(string[] args)
        {
            Console.Title = "Формула Ньютона";

            do
            {
                Console.Clear();       // очистка консольного окна
                Console.Write("Введите значение x: ");
                try //получение х, вывод фразы при неверном значении/не прозождении ф-ии
                {
                    double x = double.Parse(Console.ReadLine());
                    double result, eps = 0;
                    //запись и вывод результата
                    if (Newton(x, out result, out eps)) {
                        Console.WriteLine($"root({x}) = {result:f4}, eps = {eps:e4}");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка");
                }
                Console.WriteLine("Для выхода нажмите клавишу ESC");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}