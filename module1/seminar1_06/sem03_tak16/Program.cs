using System;
using System.Collections.Generic;
using System.Linq;

namespace sem03_tak16
{
    class Program
    {
        static int min_index(List<int> array)
        {
            return array.IndexOf(array.Min()) + 1;
        }

        static int sum(List<int> array)
        {
            return array.IndexOf(array.Max()) + min_index(array) + 2;
        }

        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1);
            // Не поняла, какой массив нужно было формировать, так что так:
            List<int> Array = new List<int>();
            Random random = new Random();
            for (int i = 0; i < N; i++) Array.Add(random.Next(N));
            Console.WriteLine($"Исходный массив: {string.Join(", ", Array)}");
            Console.WriteLine($"Индекс минимального элемента: {min_index(Array)}");
            Console.WriteLine($"Сумма индексов масимального и минимального элементов: {sum(Array)}");
            Console.ReadLine();
        }
    }
}
