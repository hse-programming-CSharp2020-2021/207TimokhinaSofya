using System;

namespace hw_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите esc");
            do
            {
                try
                {
                    //получение данных + проверка
                    //можно было через tryparce и if 
                    Console.Write("Введите a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введите b:");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Введите c:");
                    double c = double.Parse(Console.ReadLine());
                    //проверка без if всех условий для трекгольника 
                    Console.WriteLine((a + b > c && a + c > b && b + c > a) ? "Такой треугольник существует" : "Такой треугольник не существует");
                }
                catch
                //при неверно введенных данных
                {
                    Console.WriteLine("Ошибка");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
