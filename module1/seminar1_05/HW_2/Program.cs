using System;
using System.Collections.Generic;

namespace HW_2
{
    class Program
    {
        static string Create(int N)
        {
            int[] Array = new int[N];
            for (int i = 0; i < N; i++)
                Array[i] = i * 2 + 1;
            return string.Join(", ", Array);
            
        }
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            Console.WriteLine(Create(N));
            Console.ReadLine();
        }
    }
}
