using System;

namespace HW_4
{
    class Program
    {
        static void Create(int N)
        {
            int[] Array = new int[N];
            for (int i = 0; i < N; i++)
                Array[i] = i <= 1 ? 1 : Array[i - 1] + Array[i - 2];
            for (int i = N - 1; i >= 0; i--)
                Console.WriteLine($"F({i}) = {Array[i]}.");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            Create(N);
            Console.ReadLine();
        }
    }
}
