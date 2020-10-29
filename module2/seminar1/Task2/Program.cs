using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите N >= 2: ");
            }while (!int.TryParse(Console.ReadLine(), out N) && N >= 2);

            int[][] array = new int[N][];
            array[0] = new int[1] { 1 };
            array[1] = new int[2] { 1, 1 };
            for (int i = 1; i < N; i ++)
            {
                int[] row = new int[i + 1];
                for (int j = 0; j <= i; j ++)
                {
                    row[j] = (j == 0 || j == i) ? 1 : array[i - 1][j - 1] + array[i - 1][j];
                }
                array[i] = row;
            }

            for (int i = 0; i < N; i ++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
            Console.ReadLine();
        }
    }
}
