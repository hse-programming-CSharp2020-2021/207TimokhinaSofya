using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_2
{
    class Program
    {
        static IEnumerable<int> Negative(List<int> Numbers)
        {
            return from el in Numbers where el < 0 select el;
        }
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            Console.WriteLine("Для окончания введите любую не числовую последовательность символов.");

            while (Negative(Numbers).Sum() > -1000)
            {
                Console.Write("Введите число: ");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Окончание ввода.");
                    continue;
                }
                Numbers.Add(number);
            }
            Console.WriteLine($"Среднее арифметическое отрицательных элементов: {Negative(Numbers).Sum() / Negative(Numbers).Count()} .");
            Console.ReadLine();
        }
    }
}
