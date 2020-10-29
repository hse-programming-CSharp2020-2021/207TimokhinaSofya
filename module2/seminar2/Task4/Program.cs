using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class HexNumber
    {
        uint number;
        char[] hexView;
        public HexNumber(uint n)
        {
            number = n;
            hexView = series(n);
        }
        public HexNumber() : this(0) { }

        public uint Number
        {
            get { return number; }
            set
            {
                number = value;
            }
        }

        public char[] HexView
        {
            get { return hexView; }
        }

        public string Record
        {
            get { return $"0x{new String(hexView)}"; }
        }

        char[] series(uint num)
        {
            int arLen = num == 0 ? 1 : (int)Math.Log(num, 16) + 1;
            char[] res = new char[arLen];

            for (int i = arLen - 1; i >= 0; i--)
            {
                uint temp = (uint)(num % 16);
                if (temp >= 0 && temp <= 0)
                    res[i] = (char)('0' + temp);
                else res[i] = (char)('A' + temp % 10);
                num /= 16;
            }
            return res;
        }

    }
}
