using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите интервал. От: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Ошибка. Еще раз: ");
            }
            Console.Write("До: ");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b) || (b < a))
            {
                Console.Write("Ошибка. Еще раз: ");
            }
            Console.Write("Введите размер: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Ошибка. Еще раз: ");
            }
            Console.WriteLine(string.Join(" ", Returnrndsq(a, b, n)));
        }

        private static double[] Returnrndsq(int a, int b, int n)
        {
            Random rnd = new Random();
            double[] square = new double[n];
            for (int i = 0; i < n; i++)
            {
                square[i] = Math.Pow(rnd.Next(a, b + 1), 2);
            }
            return square;
        }
    }
}
