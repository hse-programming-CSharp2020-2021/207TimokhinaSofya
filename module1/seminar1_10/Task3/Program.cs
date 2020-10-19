using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            do
            {
                Console.WriteLine("Для выхода нажмите esc");
                int a = ReadNumber();
                int b = ReadNumber();
                for (int i = a; i <= b; i++)
                {
                    if (CountSum(i) == 2 * CountDigits(i))
                    {
                        Console.WriteLine(i);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("Таких чисел нет!");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ReadLine();
        }


        private static int CountSum(int number)
        {

            return number.ToString().Sum(el => el - '0');
        }

        private static int CountDigits(int number)
        {
            return number.ToString().Length;
        }


        private static int ReadNumber()
        {
            int a;
            do

            {
                Console.Write("Введите число от 1 до 10000: ");
                try
                {

                    a = int.Parse(Console.ReadLine());
                    return a >= 10000 || a < 1 ? throw new Exception("Число больше 10000 или мешьше 1") : a;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
    }
}
    
