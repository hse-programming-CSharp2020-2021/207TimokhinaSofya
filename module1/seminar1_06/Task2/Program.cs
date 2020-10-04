using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Введите n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Введите n: ");
            }
           
            string[][] Array = new string[n][];
            for (int i = 0; i < n; i ++)
            {
                Array[i] = new string[i];
                for (int j = 0; j < i; j++)
                    Array[i][j] = "*" ;

            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join("", Array[i]));
            }
            Console.ReadLine();
        }
    }
}
