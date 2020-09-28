using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { -1, -5, 0, -108, 34, 35, 21 };
            int maxValue = ar.OrderByDescending(x => Math.Abs(x)).First();
            Console.WriteLine(maxValue);
            Console.ReadLine();
        }
    }
}
