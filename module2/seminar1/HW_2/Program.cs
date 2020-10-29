using System;

namespace HW_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Введите N >= 1: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1);

            int[][] array = new int[N][];
            for (int i = 0; i < N; i ++)
            {
                array[i] = new int[N];
                for (int j = 0; j < N; j ++)
                {
                    array[i][j] = (i + j + 1 < N) ? i + j + 1 : i + j + 1 - (i + j) / N * N;
                }
                Console.WriteLine(string.Join(" ", array[i]));
            }
            Console.ReadLine();
        }
    }
}
