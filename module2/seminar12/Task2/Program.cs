using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        // Что-то пошло не так
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите число: ");
                string hexNumber = Console.ReadLine();
                Console.WriteLine(ConvertHex2Bin1(hexNumber));
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string ConvertHex2Bin1(string hexNumber)
        {
            List<string> values = new List<string>() { "A", "B", "C", "D", "E", "F" };
            double numberTen = Enumerable.Range(0, hexNumber.Count()).Select(i =>
            (int.TryParse(hexNumber[i].ToString(), out _) ? int.Parse(hexNumber[i].ToString()) : values.IndexOf(hexNumber[i].ToString()) == -1 ? throw new ArgumentException() : values.IndexOf(hexNumber[i].ToString())) * Math.Pow(16, hexNumber.Count() - 1 - i)).ToArray().Sum();
            Console.WriteLine(numberTen);
            string number = "";
            while (numberTen != 0)
            {
                numberTen /= 2;
                number += Math.Round(numberTen % 2);
            }
            Console.WriteLine(number);
            return Enumerable.Range(hexNumber.Count(), 0).Select(i => number[i]).ToString();
        }

        static string ConvertHex2Bin2(string hexNumber)
        {
            List<string> values = new List<string>() { "A", "B", "C", "D", "E", "F" };
            double numberTen = Enumerable.Range(0, hexNumber.Count()).Select(i =>
            (int.TryParse(hexNumber[i].ToString(), out _) ? int.Parse(hexNumber[i].ToString()) : values.IndexOf(hexNumber[i].ToString()) == -1 ? throw new ArgumentException() : values.IndexOf(hexNumber[i].ToString())) * Math.Pow(16, i)).ToArray().Sum();
            StringBuilder number = new StringBuilder();
            while (numberTen != 0)
            {
                number.Append(numberTen % 10);
                numberTen /= 10;
            }
            return number.ToString().Reverse().ToString();
        }
    }
}
