using System;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int a = 1; a <= 20; a ++)
                for (int b = 1; b <= 20; b ++)
                    for (int c = 1; c <= 20; c ++)
                    {
                        if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) &&
                            a != c && b != c && a != b)
                            Console.WriteLine($"a = {a}, b = {b}, c = {c}.");
                    }
            Console.ReadLine();
        }
    }
}
