using System;
using System.Collections.Generic;
using System.IO;

namespace HW3
{
    class Program
    {
        static int[] statistics = new int[26];
        static int openInCode = 0;
        static int closeInCode = 0;

        static int openInString = 0;
        static int closeInString = 0;
        static int total = 0;

        static bool isString = false;
        static void Main(string[] args)
        {
            try
            {
                using (var streamReader = new StreamReader(@"../../../Program.cs"))
                {
                    Console.SetIn(streamReader);
                    string line;
                    while ((line = Console.ReadLine()) != null)
                    {
                        GetNumbers(line);
                    }
                }
                StatChars();
                AboutBrackets();
            }
            catch
            {
                Console.WriteLine("Кажется, файл недоступен.");
            }

            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.ReadLine();
        }

        static void GetNumbers(string line)
        {
            foreach (char element in line)
            {
                ++total;
                if (element >= 'a' && element <= 'z')
                    statistics[element - 'a'] += 1;
                if (element == '"' || element == '\'')
                    isString = !isString;
                else if (element == '{')
                {
                    if (isString)
                        ++openInString;
                    else
                        ++openInCode;
                }
                else if (element == '}')
                {
                    if (isString)
                        ++closeInString;
                    else
                        ++closeInCode;
                }
            }
        }

        static void StatChars()
        {
            Console.WriteLine("Статистика по буквам: ");
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{(char)('a' + i)} - {statistics[i]}");
            }
        }

        static void AboutBrackets()
        {
            Console.WriteLine($"В коде было {openInCode} открытых и {closeInCode} закрытих фигурных скобок");
            Console.WriteLine($"В строках было {openInString} открытых и {closeInString} закрытих фигурных скобок");
            Console.WriteLine($"Всего {total} символов");
        }
    }
}