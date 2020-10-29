using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][][] array = new char[3][][];

            array[0] = new char[3][];
            array[1] = new char[2][];
            array[2] = new char[1][];

            array[0][0] = new char[] { 'a', 'b' };
            array[0][1] = new char[] { 'c', 'd', 'e' };
            array[0][2] = new char[] { 'f', 'g', 'h', 'i' };
            array[1][0] = new char[] { 'j', 'k' };
            array[1][1] = new char[] { 'l', 'm', 'n' };
            array[2][0] = new char[] { 'o', 'p', 'q', 'r' };

        }
    }
}