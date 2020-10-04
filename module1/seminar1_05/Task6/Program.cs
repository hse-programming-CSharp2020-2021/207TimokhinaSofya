using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Array = new List<int>() { 1, 2, 3, 45, 46 };
            Array.RemoveAll(e => e % 2 == 0);

            Console.WriteLine(string.Join(", ", Array));
            Console.ReadLine();
        }
    }
}
