using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Для выхода нажмите esc");
                do
                {
                    Console.Write("Введите N от 1 до 10000: ");
                } while (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 10000);
                int[] array = new int[N];
                Console.WriteLine($"Введите {N} целых чисел: ");
                for (int i = 0; i < N;)
                {
                    try
                    {
                        array[i] = int.Parse(Console.ReadLine());
                        i++;
                    }
                    catch
                    {
                        Console.WriteLine("Введено не число");
                    }
                }

                List<int> Simple = GetSimple(array);
                Console.WriteLine($"Количество простых чисел {Simple.Count}");
                Console.WriteLine($"Все простые числа {string.Join(", ", Simple)}");
                Console.WriteLine(array.OrderBy(x => x).SequenceEqual(array) ? "Возрастающая" : "Не возрастающая");
                Console.WriteLine($"Минимальный элемент {array.Min()}");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static List<int> GetSimple(int[] array)
        {
            List<int> Simple = new List<int>();
            foreach (int number in array)
            {
                int count = 0;
                for (int i = 1; i <= number; i++)
                {
                    count += number % i == 0 ? 1 : 0;
                }
                if (count <= 2)
                {
                    Simple.Add(number);
                }
            }
            return Simple;

        }
    }
}
