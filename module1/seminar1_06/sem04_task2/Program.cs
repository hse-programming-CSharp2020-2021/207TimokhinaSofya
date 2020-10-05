using System;
using System.Collections.Generic;
using System.Linq;

namespace sem04_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите N: ");
            } while (!int.TryParse(Console.ReadLine(), out N));
            List<int[]> array = new List<int[]>();
            int len = 1;
            while (N != 0)
            {
                array.Add(Enumerable.Range(0, len >= N ? N : len++).Select(s => N--).ToArray());
            }
            foreach (int[] el in array) Console.WriteLine(string.Join(", ", el));
            Console.ReadLine();
        }
    }
}
