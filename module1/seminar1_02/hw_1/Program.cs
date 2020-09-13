using System;

namespace hw_1
{
    class Program
    {
        static double function(double x) //возвращает значение заданной функции
        {
            //можно было не раскладывать на множители
            return Math.Round(3 * x * x * (x + 1) * (4 * x - 1) + 2 * (x - 4), 3);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите  ESC.");
            do
            {
                Console.Write("Введите число: ");
                if (double.TryParse(Console.ReadLine(), out double x)) //проверка введенных данных + запись 
                {
                    Console.Write(function(x));
                }
                else
                {
                    Console.WriteLine("Неверное значение!");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
