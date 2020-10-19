using System;
using System.Linq;

namespace sem04_task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[3][];
            Random random = new Random();
            for (int i = 0; i < 3; i++) array[i] = Enumerable.Range(0, 6).Select(s => random.Next(0, 26)).ToArray();
            long[] new_array = new long[2];
            for (int i = 0; i < 2; i ++)
            {
                int k = i * 3;
                new_array[i] = array[0][k] * array[1][k + 1] * array[2][k + 2] +
                array[0][1 + k] * array[1][2 + k] * array[2][k] +
                array[0][2 + k] * array[1][k] * array[2][1 + k] -
                array[0][k] * array[1][2 + k] * array[2][1 + k] -
                array[0][1 + k] * array[1][k] * array[2][2 + k] -
                array[0][2 + k] * array[1][1 + k] * array[2][k];
            }
            Console.WriteLine("Исходный массив: ");
            foreach (int[] element in array) Console.WriteLine(string.Join("\t", element));
            Console.WriteLine($"Преборазованный: {string.Join("\t", new_array)}");
            Console.ReadLine();
        }
    }
}
