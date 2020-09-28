using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double c = Math.Pow(a, 2) + Math.Pow(b, 2);
            Console.WriteLine("Гипотенуза равна: ", Math.Pow(c, 0.5));
        }
    }
}
