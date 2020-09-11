using System;

namespace Task1
{
    class Program
    {
        public static string ReturnRandomSting()
        {
            Random rnd = new Random();
            string str = "";
            for (int i = 0; i < rnd.Next(1, 20); i ++)
            {
                str += (char)rnd.Next('a', 'z' + 1);

            }
            return str;
        }
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i ++)
            {
                Console.WriteLine(ReturnRandomSting());
            }
        }
    }
}
