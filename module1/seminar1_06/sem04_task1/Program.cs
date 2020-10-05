using System;

namespace sem04_task1
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
            int[,] array = new int[N, N];
            int number = 1;
            for (int i = 0; i < N / 2; i ++)
            {
                for (int j = i; j < N - i; j++) array[i, j] = number++;
                for (int j = i + 1; j < N - i; j++) array[j, N - i - 1] = number++;
                for (int j = N - i - 2; j > i - 1; j--) array[N - i - 1, j] = number++;
                for (int j = N - i - 2; j > i; j--) array[j, i] = number++;
            }
            if (N % 2 == 1) array[N / 2, N / 2] = number;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++) Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
