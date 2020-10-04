using System;
using System.Collections.Generic;

namespace sem03_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1);
            int K;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out K) || K < 1 || K > N);
            // Не поняла, какой массив нужно было формировать, так что так:
            List<int> Array = new List<int>();
            Random random = new Random();
            for (int i = 0; i < N; i++) Array.Add(random.Next(N));
            Array.RemoveAll(item => item % Math.Pow(item, item * K) != 0);
            Console.WriteLine(string.Join(", ", Array));
            Console.ReadLine();
        }
    }
}
