using System;

namespace seminar1_04
{
    class Program
    {
        static bool Shifr(ref char ch)
        {
            if (!(ch >= 'a' && ch <= 'z'))
            {
                return false;
            }
            ch = (char)(ch + 4);
            if (ch > 122)
            {
                ch = (char)(ch - 25);
            }
            Console.WriteLine(ch);
            return true;
        }

        static void Main(string[] args)
        {
            char ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine(Shifr(ref ch));

        }
    }
}