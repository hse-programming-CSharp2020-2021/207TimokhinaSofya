using System;
using System.IO;


namespace hw_task3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string line in File.ReadLines("../../../../Numbers.bin"))
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
