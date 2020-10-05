using System;
using System.Linq;

namespace sem04_tasl4
{
    class Program
    {
        static void create(ref int[][] array, int N)
        {
            Random random = new Random();
            int Min = int.MinValue;
            int Max = int.MaxValue;
            for (int i = 0; i < N; i++) array[i] = Enumerable.Range(0, N).Select(s => random.Next(Min + 1, Max)).ToArray();
        }
        static long determinant2(int[][] array)
        {
            return array[0][0] * array[1][1] - array[0][1] * array[1][0];
        }
        static long determinant3(int[][]array)
        {
            return array[0][0] * array[1][1] * array[2][2] +
                array[0][1] * array[1][2] * array[2][0] +
                array[0][2] * array[1][0] * array[2][1] -
                array[0][0] * array[1][2] * array[2][1] -
                array[0][1] * array[1][0] * array[2][2] -
                array[0][2] * array[1][1] * array[2][0];
        }
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Введите N от 2 до 3: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || (N != 2 && N != 3));
            int[][] array = new int[N][];
            create(ref array, N);
            Console.WriteLine("Матрица: ");
            foreach (int[] element in array) Console.WriteLine(string.Join("\t", element));
            Console.WriteLine($"Определитель равен: {(N == 2 ? determinant2(array): determinant3(array))}.");
            Console.ReadLine();
        }
    }
}
