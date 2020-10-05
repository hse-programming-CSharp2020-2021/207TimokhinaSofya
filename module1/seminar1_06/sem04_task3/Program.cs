using System;

namespace sem04_task3
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
            string[][] array = new string[N][];
            for (int i = 0; i < N; i ++)
            {
                array[i] = new string[N + i + 1];
                for (int j = 0; j < N + i; j++) array[i][j] = j >= N - i - 1? "*": " ";
            }
            foreach (string[] element in array) Console.WriteLine(string.Join("", element));
            Console.ReadLine();
        }
    }
}
