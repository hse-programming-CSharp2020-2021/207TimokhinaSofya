using System;

namespace HW_1
{
    class Program
    {
        static int[] Sq(int N)
        {
            int[] Array = new int[N];
            for (int i = 0; i < N; i++)
                Array[i] = 1 << i;
            return Array;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            Console.WriteLine(string.Join(", ", Sq(N)));
            Console.ReadLine();
        }
    }
}
