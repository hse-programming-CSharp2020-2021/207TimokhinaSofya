using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int>();
            List<int> B = new List<int>();
            Random rnd = new Random();
            int a = int.Parse(Console.ReadLine());
            for (int i = 0; i < a; i ++)
            {
                A.Add(rnd.Next(10, 51));
            }
            Console.WriteLine($"Массив A: {string.Join(", ", A)}.");
            int b = int.Parse(Console.ReadLine());
            for (int i = 0; i < b; i++)
            {
                B.Add(rnd.Next(10, 51));
                if (B[i] % 2 == 0)
                {
                    A.Add(B[i]);
                }
            }
            Console.WriteLine($"Массив B: {string.Join(", ", B)}.");
            Console.WriteLine($"Модифицированный массив A: { string.Join(", ", A)}.");
        }
    }
}
