using System;

namespace Task3
{
    class Program
    {
        public static double S(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        public static double L(double radius)
        {
            return 2 * Math.PI * radius;
        }

        static void Main(string[] args)
        {
            int radius;
            bool success = int.TryParse(Console.ReadLine(), out radius);
            if (radius > 0 && success)
            {
                double s = S(radius);
                double l = L(radius);
                Console.WriteLine($"square = {s:f2}, length = {l:f2}.");
                Console.WriteLine(l);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        }
}
