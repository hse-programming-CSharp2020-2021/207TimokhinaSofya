using System;
using System.Linq;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = 'к', finish = 'ю';
            do
            {
                RusString testString = new RusString(start, finish, 10); Console.WriteLine(testString); Console.WriteLine(testString.CountLetter('о'));
                // тестируем неверные входные данные
                try
                {
                    testString = new RusString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Состояние объекта не изменено");
                }
                Console.WriteLine(testString); Console.WriteLine(testString.CountLetter('о'));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }


    public class RusString
    {
        String str; // строка русских символов
        static Random rnd = new Random();
        public RusString(char start, char finish, int n)
        {
            // проверяем количество символов строки и допустимые границы
            if (n <= 0 || start < 'а' || finish > 'я')
                throw new ArgumentOutOfRangeException();
            char[] letters = new char[n];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)rnd.Next(start, finish + 1);
            }
            str = new String(letters);
        }
        /// <summary>
        /// Свойство, возвращающее информацию о палиндромности
        /// </summary>
        public bool IsPalindrome
        {
            get
            {
                return new string(str.ToCharArray().Reverse().ToArray()) == str;
            }
        }
        public int CountLetter(char letter)
        {
            return (letter < 'а' || letter > 'я') ? throw new ArgumentOutOfRangeException("Недопустимый символ") :
                str.Where(x => x == letter).ToArray().Count();
        }
        public override string ToString()
        {
            return str;
        }
    }
}
