using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[3];
            for (int i = 0; i < 3; i ++ )
            {
                words[i] = Console.ReadLine();
            }
            Console.WriteLine(string.Join("!", words));
        }
    }
}
