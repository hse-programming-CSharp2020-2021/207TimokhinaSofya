using System;
using System.Linq;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                UserString userString = new UserString();
                Console.WriteLine($"Получилась строка: {userString}");
                Console.WriteLine($"Строка без  выбранного слова: {userString.MoveOff()}");
                Console.WriteLine("Для выхода нажмите esc, чтобы перезапустить - не esc.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class UserString
    {
        internal static string userString;

        public UserString()
        {
            userString = CreateString(GetLenght(), GetMinAndMaxChar());
        }

        private static string CreateString(int lenght, (char, char) paramsForChars)
        {
            char minChar = paramsForChars.Item1;
            char maxChar = paramsForChars.Item2;
            if (lenght <= 0) throw new ArgumentException("Длина строки - положительное число!");
            if (minChar > maxChar) throw new ArgumentException("Заданы неверные границы.");

            Random random = new Random();
            return string.Join(string.Empty, Enumerable.Range(0, lenght).Select(x => (char)random.Next(minChar, maxChar + 1)).ToArray());
        }

        private static int GetLenght()
        {
            int lenght;
            Console.Write("Длина строки: ");
            while (!int.TryParse(Console.ReadLine(), out lenght) || lenght <= 0)
            {
                Console.Write("Неверное значение. Введите еще раз: ");
            }
            return lenght;
        }

        private static (char, char) GetMinAndMaxChar()
        {
            char minChar, maxChar;
            Console.Write("Минимальный символ: ");
            while (!char.TryParse(Console.ReadLine(), out minChar))
            {
                Console.Write("Неверное значение. Введите еще раз: ");
            }

            Console.Write("Максимальный символ: ");
            while (!char.TryParse(Console.ReadLine(), out maxChar) || minChar > maxChar)
            {
                Console.Write("Неверное значение. Введите еще раз: ");
            }

            return (minChar, maxChar);
        }

        public override string ToString()
        {
            return userString;
        }

        private static string GetStringOnlyWithLetters()
        {
            Console.Write("Слово или буква для заменты: ");
            string word;
            while ((word = Console.ReadLine()).Any(x => !char.IsLetter(x)))
            {
                Console.Write("Строка должна состоять только из букв. Повторите попытку: ");
            }
            return word;
        }

        public string MoveOff()
        {
            return userString.Replace(GetStringOnlyWithLetters(), string.Empty);
        }
    }
}
