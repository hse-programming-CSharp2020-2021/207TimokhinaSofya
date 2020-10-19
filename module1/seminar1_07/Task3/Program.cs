using System;
using System.IO;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static string Replace(ref int N, ref int M, string line)
        {
            string newline = "";
            foreach(char element in line)
            {
                if (char.IsDigit(element))
                {
                    newline += new string(element, 2);
                    N++;
                }
                else if (char.IsUpper(element)) M++;
                else newline += element;
            }
            return newline;
        }
        static void Main(string[] args)
        {
            int M = 0;
            int N = 0;
            foreach (string line in File.ReadLines("../../../firstFile.txt"))
            {
                string newline = Replace(ref N, ref M, line);
                File.AppendAllText("../../../secondFile.txt", newline + Environment.NewLine);
            }
            File.AppendAllText("../../../secondFile.txt", $"Было удвоено {N} цифр и удалено {M} заглавных букв");
            Console.ReadLine();
        }
    }
}
