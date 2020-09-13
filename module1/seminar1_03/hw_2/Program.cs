using System;

namespace hw_2
{
    class Program
    {
        static int Reverse(string number)
        {
            //создание массива, состоящего из символов введенного числа 
            char[] elements = number.ToCharArray();
            //разворот
            Array.Reverse(elements);
            /* введено точно число, так что преобразуем массив в строку, затем обратно
            в число. нули при этом уйдут */
            int new_number = int.Parse(String.Join("", elements));
            return new_number;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Введите целое число: ");
                //проверка и запись введенных данных
                if (int.TryParse(Console.ReadLine(), out int number)) {
                    //вывод 
                    Console.WriteLine($"{number} -> {Reverse(number.ToString())}");
                }
                else
                {
                    Console.WriteLine("Кажется, вы ввели неверные данные.");
                }
                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
