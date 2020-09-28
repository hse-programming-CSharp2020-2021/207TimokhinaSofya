using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Введите число: ");
            }
            double[] square = new double[number];
            for (int i = 0; i < number; i++)
            {
                square[i] = Math.Pow(i + 1, 2);
            }
            Console.WriteLine($"Квадраты чисел до {number}: ", string.Join(", ", square));
        }
    }
}
