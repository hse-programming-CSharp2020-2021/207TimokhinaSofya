using System;

namespace HW_3
{
    class Program
    {
        static string Create(int N, int D)
        {
            int[] Array = new int[N];
            for (int i = 0; i < N; i++)
                Array[i] = i + D * i;
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
            Console.Write("Введите D: ");
            int D;
            while (!int.TryParse(Console.ReadLine(), out D))
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            Console.WriteLine(Create(N, D));
            Console.ReadLine();
        }
    }
}
