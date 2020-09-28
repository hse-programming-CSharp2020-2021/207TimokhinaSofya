using System;

namespace HW_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N < 0)
            {
                Console.WriteLine("Ошибка");
                return;
            }
            Console.Write("Введите M: ");
            if (!int.TryParse(Console.ReadLine(), out int M) || M < 0)
            {
                Console.WriteLine("Ошибка");
                return;
            }
            M = 1 << M;
            N = 1 << N;
            Console.WriteLine(N + M);
            Console.ReadLine();
        }
    }
}
