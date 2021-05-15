using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var collection = Enumerable.Range(1, random.Next(15, 20)).Select(x => x = random.Next(-20, 20)).ToArray();
            Console.WriteLine("All");
            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine("**2");
            Console.WriteLine(string.Join(", ", collection.Select(x => Math.Pow(x, 2))));
            Console.WriteLine(">0 && len == 2");
            Console.WriteLine(string.Join(", ", collection.Where(x => x > 0 && Math.Abs(x).ToString().Length == 2)));
            Console.WriteLine("%2 == 0 + order");
            Console.WriteLine(string.Join(", ", collection.Where(x => x % 2 == 0).OrderBy(x => -x)));
            Console.WriteLine("oder by len");
            Console.WriteLine(string.Join(", ", collection.OrderBy(x => Math.Abs(x).ToString().Length)));
        }
    }
}
