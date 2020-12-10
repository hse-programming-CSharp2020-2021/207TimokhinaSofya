using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите строку: ");
                StringBuilder str = new StringBuilder(Console.ReadLine());
                //string str = "Привет     ююю  вывфы";
                Console.WriteLine($"Строка: {str}");
                Console.WriteLine($"Без лишних пробелов: {DeleteSpace(str)}");
                Console.WriteLine($"Больше 4 букв: {CountMoreThan4(str)}");
                Console.WriteLine($"Начинается с гласной: {CountStartsWithVowel(str)}");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string DeleteSpace(StringBuilder str)
        {
            return string.Join(" ", str.ToString().Split().Where(x => x != ""));
        }

        static int CountMoreThan4(StringBuilder str)
        {
            return DeleteSpace(str).Split().Where(x => x.Length > 4).ToArray().Count();
        }

        static int CountStartsWithVowel(StringBuilder str)
        {
            List<string> vowels = new List<string>() { "у", "е", "ы", "а", "о", "э", "ё", "и", "ю" };
            return DeleteSpace(str).Split().Where(x => vowels.IndexOf(x.First().ToString()) != -1).ToArray().Count();
        }

    }
}
