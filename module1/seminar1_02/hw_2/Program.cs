using System;
using System.Linq;

namespace hw_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите ESC");
            do
            {
                Console.Write("Введите трехзначное число: ");
                if (int.TryParse(Console.ReadLine(), out int P) && P.ToString().Length == 3) //проверка введенных данных (число +  длина
                {
                    var digits = P.ToString().ToList().OrderByDescending(x => x); //сортировка.
                    //можно было засписать в отдельный метод, я пользовалась встроенной
                    Console.WriteLine(string.Join("", digits)); //из массива в строку
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }  while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
