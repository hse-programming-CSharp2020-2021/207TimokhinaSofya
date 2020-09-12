using System;
using System.Linq;

namespace hw_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (int.TryParse(Console.ReadLine(), out int P) && P.ToString().Length == 3)
            {
                var digits = P.ToString().ToList().OrderByDescending(x=>x);
                Console.WriteLine(string.Join("", digits));
            }
            else
            { 
                Console.WriteLine("Ошибка");
            }
        }
    }
}
