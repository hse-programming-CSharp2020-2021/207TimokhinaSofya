using System;
using System.Collections.Generic;
using System.Linq;


namespace sem03_task20
{
    class Program
    {
        static void ArrayItemDouble(ref List<int> array)
        {
            int N = array.Count();
            int X;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out X) || X < 1);
            for (int i = 0; i < N; i ++)
            {
                if (array[i] == X) array.Add(array[i]);
            }
        }
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1);

            List<int> array = new List<int>();
            Random random = new Random();
            for (int i = 0; i < N; i++) array.Add(random.Next(10, 101));

            Console.WriteLine($"Исходный массив: {string.Join(",", array)}");
            ArrayItemDouble(ref array);
            Console.WriteLine($"Первое преобразование: {string.Join(",", array)}");
            ArrayItemDouble(ref array);
            Console.WriteLine($"Второе преобразование: {string.Join(",", array)}");
            Console.ReadLine();
        }
    }
}
