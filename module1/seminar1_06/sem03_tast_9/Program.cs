using System;
using System.Collections.Generic;

namespace sem03_tast_9
{
    class Program
    {
        static void ArrayHill(List<int> array, int N)
        {
            array.Sort();
            int[] new_array = new int[N];
            int index = 0;
            for (int i = 0; i < N; i ++) new_array[i % 2 == 0 ? index : N - ++index] = array[i];
            Console.WriteLine($"Измененный массив: {string.Join(", ", new_array)}");
        }
        static void Main(string[] args)
        {
            int N;
            Random random = new Random();
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1);
            List<int> array = new List<int>();
            for (int i = 0; i < N; i++) array.Add(random.Next(-10, 11));
            Console.WriteLine($"Исходный массив: {string.Join(", ", array)}");
            ArrayHill(array, N);
            Console.ReadLine();
        }
    }
}
