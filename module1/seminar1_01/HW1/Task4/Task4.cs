using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int U = int.Parse(Console.ReadLine());
            int R = int.Parse(Console.ReadLine());
            double I = U / R;
            double P = Math.Pow(U, 2) / R;
            Console.WriteLine("Сила тока: ", I);
            Console.WriteLine("Мощность: ", P);
        }
    }
}
