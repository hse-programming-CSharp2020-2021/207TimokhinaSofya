using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            LatinChar latinChar;



            char minChar = char.Parse(Console.ReadLine());
            char maxChar = char.Parse(Console.ReadLine());
            for (char i = minChar; i < maxChar; i++)
            {
                latinChar = new LatinChar(i);
                Console.WriteLine((char)latinChar.Char);
            }
        }
    }

    class LatinChar
    {
        private char _char = 'a';



        public char Char
        {
            get
            {
                return _char;
            }
            set
            {
                if (value >= 'a' && value <= 'z')
                    _char = value;
                else
                    throw new ArgumentException();
            }
        }



        public LatinChar(char symbol)
        {
            _char = symbol;
        }

    }
}
