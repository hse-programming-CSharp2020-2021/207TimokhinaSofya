using System;

namespace Task5
{
    class Program
    {
        static int func(int n, int k)
        {
            if (n == k && n >= 0) return 1;
            else if (k == 0 && n > 0) return 0;
            else if (n == 0 && k > 0) return 0;
            return func(n - 1, k - 1) + k * func(n - 1, k);
        }
        static void Main(string[] args)
        {
            int n, k;
            Console.Write("Введите n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Введите n: ");
            }
            Console.Write("Введите k: ");
            while (!int.TryParse(Console.ReadLine(), out k) || k <= 0 || k >= n)
            {
                Console.Write("Введите k: ");
            }
            Console.WriteLine(func(n, k));
            Console.ReadLine();
        }
    }
}
