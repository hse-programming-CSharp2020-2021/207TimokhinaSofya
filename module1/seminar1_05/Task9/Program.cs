using System;
using System.Linq;

namespace Task9
{
    class Program
    {
        static void Change(ref double[] Array, double param)
        {
            double max_el = Array.Max();
            for (int i = 0; i < Array.Count(); i ++)
            {
                if (Array[i] == max_el)
                    Array[i] = param;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            double N;
            while (!double.TryParse(Console.ReadLine(), out N))
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            double[] Array = { 1, 3.5, 56.7, 100.5, 55, 76, 374.4, 108.2, 374.4, 65 };
            Console.WriteLine($"Начальный массив: {string.Join(", ", Array)}");
            Change(ref Array, N);
            Console.WriteLine($"Измененный: {string.Join(", ", Array)}");
            Console.ReadLine();
        }
    }
}
