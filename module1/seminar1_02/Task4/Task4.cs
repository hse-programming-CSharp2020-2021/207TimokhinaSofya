using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            bool success = int.TryParse(number, out int result);
            if (success && number.Length == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(number[i]);
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}