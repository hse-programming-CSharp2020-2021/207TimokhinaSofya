using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(File.ReadAllText("../../../../IntNumber.txt"));
            }
            catch
            {
                Console.WriteLine("error");
            }
            Console.ReadLine();
        }
    }
}
