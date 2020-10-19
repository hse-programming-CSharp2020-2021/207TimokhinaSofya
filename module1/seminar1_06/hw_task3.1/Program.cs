using System;
using System.Linq;
using System.IO;
namespace hw_task3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите n: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 10);
            Random random = new Random();
            File.WriteAllText("../../../../Numbers.bin", string.Join(" ", Enumerable.Range(0, n).Select(s => Convert.ToString(random.Next(n), 2)).ToArray()));
        }
    }
}
