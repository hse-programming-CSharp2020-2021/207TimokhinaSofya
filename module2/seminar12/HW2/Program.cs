using System;
using System.Linq;
using System.Collections.Generic;
namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string[] strings = UserString.ValidatedSplit(GetString(), ';');
                if (strings == null)
                    Console.WriteLine("Ошибка! Получена неверная строка.");
                else
                {
                    foreach (string arg in strings)
                    {
                        foreach(string podString in arg.Trim().Split())
                            Console.Write(UserString.FirstUpcase(UserString.Shorten(podString.ToLower())));
                        Console.WriteLine();
                    }
                }


                Console.WriteLine("Для выхода нажмите esc, чтобы перезапустить - не esc.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string GetString()
        {
            Console.Write("Введите строку: ");
            return Console.ReadLine();
        }
    }


    class UserString
    {

        public static bool Validate(string str)
        {
            str = str.ToLower();
            return str.All(x => (x >= 'a' && x <= 'z') || x == ' ');
        }

        public static string Shorten(string str)
        {
            int[] indexes = Enumerable.Range(0, str.Length).Where(x => new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' }.IndexOf(str[x]) != -1).ToArray();
            if (indexes.Length == 0)
                return str;
            return str.Substring(0, indexes.Min() + 1);
        }
        public static string FirstUpcase(string str)
        {
            return char.ToUpper(str.First()) + str.Substring(1).ToLower();
        }

        public static string[] ValidatedSplit(string str, char ch)
        {
            string[] output = null;
            output = str.Split(ch);
            foreach (string s in output)
            {
                if (!Validate(s)) return null;
            }
            return output;
        }

    }


}
