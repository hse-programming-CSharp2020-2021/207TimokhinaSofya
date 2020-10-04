using System;

namespace sem03_task11
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
            int[] array = new int[N];
            for (int i = 0; i < N; i++) array[i] = i <= 1? i: 34 * array[i - 1] - 2 * array[i-2];
            Console.Write(string.Join(", ", array));
            Console.ReadLine();
        }
    }
}
