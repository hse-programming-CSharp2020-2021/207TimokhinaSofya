using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> array = new List<int>();
            for (int i = 0; i < random.Next(10, 16); i++)
            {
                array.Add(random.Next(-10, 10));
            }
            Console.WriteLine(string.Join(", ", array.OrderBy(i => i > 0 ? 0 : 1).ToArray()));
            Console.ReadLine();
        }
    }
}
