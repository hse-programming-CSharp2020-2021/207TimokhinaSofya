using System;
using System.Linq;

namespace sem04_task5
{
    class Program
    {
        static void create(ref string[][] array, int N)
        {
            Random random = new Random();
            for (int i = 0; i < N; i++) array[i] = Enumerable.Range(0, N).Select(s => random.Next(0, 26).ToString()).ToArray();
        }
        static void Main(string[] args)
        {
            int N = 10;
            string[][] array = new string[N][];
            create(ref array, N);
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < N; i++) Console.WriteLine(string.Join("\t", array[i]));
            Console.WriteLine("Вывод 1: ");
            first(N, array);
            Console.WriteLine("Вывод 2: ");
            second(N, array);
            Console.WriteLine("Вывод 3:");
            third(N, array);
            Console.WriteLine("Вывод 4: ");
            Console.WriteLine("Я не поняла :(");
            Console.ReadLine();
        }

        private static void third(int N, string[][] array)
        {
            int number = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(((i == N / 2 || j <= number || j >= N - number - 1) ? " " : array[i][j]) + "\t");
                if (i < N / 2 - 1) number++;
                else if (i > N / 2 - 1) number--;
                Console.WriteLine();
            }
        }

        private static void second(int N, string[][] array)
        {
            int number = -1;
            for (int i = 0; i < N; i++)
            {
                if (i + 1 == N / 2) number = 1;
                for (int j = 0; j < N; j++)
                {
                    Console.Write(((number == -1 || j < N / 2 - number + 1 || j > N / 2 + number - 2) ? " " : array[i][j]) + "\t");
                }
                if (number != -1) number++;
                Console.WriteLine();
            }
        }

        private static void first(int N, string[][] array)
        {
            int number = 0;
            bool flag = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(j >= number ? " " : array[i][j] + "\t");
                    if (number == N / 2) flag = true;
                }
                number += flag ? -1 : 1;
                Console.WriteLine();
            }
        }
    }
}
