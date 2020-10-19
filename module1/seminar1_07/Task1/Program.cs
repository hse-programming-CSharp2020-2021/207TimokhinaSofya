using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите n: ");
            } while (!int.TryParse(Console.ReadLine(), out n));
            File.WriteAllText("../../../../IntNumber.txt", Convert.ToString(n, 2));
        }
    }
}
