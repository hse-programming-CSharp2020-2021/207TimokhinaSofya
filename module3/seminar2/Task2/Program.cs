using System;
using System.Linq;
using System.Text;

namespace Task2
{
    delegate string ConvertRule(string param);
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Converter converter = new Converter();
            ConvertRule convertRule = RemoveSpaces;
            convertRule += RemoveDigits;
            string[] vs = Enumerable.Range(0, random.Next(4, 6)).Select(x => CreateString()).ToArray();

            Array.ForEach(vs, str => Console.WriteLine($"Слово: {str}\r\n" +
                    $"\tС помощью методов: {converter.Convert(converter.Convert(str, RemoveSpaces), RemoveDigits)}\r\n" +
                    $"\tС помощью делегата: {converter.Convert(str, convertRule)}"));

            Console.ReadKey();
        }

        public static string RemoveDigits(string str) => string.Join("", str.ToCharArray().Where(x => !int.TryParse(x.ToString(), out int _)).ToArray());
        public static string RemoveSpaces(string str) => string.Join("", str.ToCharArray().Where(x => x != ' ').ToArray());

        static public string CreateString()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < random.Next(2, 15); i++)
                stringBuilder.Append(new char[3]{ (char)random.Next(97, 122), ' ', (char)random.Next(48, 58) }[random.Next(3)]);
            return stringBuilder.ToString();
        }
    }

    class Converter
    {
        public string Convert(string str, ConvertRule cr) {
            foreach (ConvertRule convertRule in cr.GetInvocationList())
                str = convertRule(str);
            return str;
        }
    }
}
