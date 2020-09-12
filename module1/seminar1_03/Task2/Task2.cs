using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double old = 1, res = 0;
            for (int i = 1; old - res != 0 ; i++)
            {
                Console.WriteLine(res);
                old = res;
                res += 1 / ((double)i * (i + 1) * (i + 2));

            }
            Console.WriteLine(res);
            {

            }
        }
    }
}
