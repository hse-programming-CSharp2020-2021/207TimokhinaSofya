using System;

namespace hw_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите ESC");
            do
            {
                string number = Console.ReadLine();
                if (int.TryParse(number, out int sucsess) && number.Length == 4) //проверка введенных данных, можно было через try
                {
                    //все элементы введенного числа в записываются в массив
                    //можно было пройти циклом (отдельный метод), идти с конца строки и записывать в новую 
                    char[] str = number.ToCharArray();
                    Array.Reverse(str); //переворачиваем массив
                    //идем по элементам 
                    foreach (char el in str)
                    {
                        Console.WriteLine(el);
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }
    }
}
