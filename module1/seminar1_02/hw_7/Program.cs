using System;
using System.Collections.Generic;

namespace hw_7
{
    class Program
    {
        //возвращает массив с данными о целой и дробной частях
        static List<double> separation(double number)
        {
            double full = Math.Truncate(number);
            double frac = number - full;
            return new List<double> { full, frac };
        }
        //возвращает массив с корнем и квадратом
        static List<double> updown(double number)
        {
            double root = number > 0 ? Math.Pow(number, 0.5): -1; // если число меньше 0, то нельзя взять корень. можно было через try
            double sqr = Math.Pow(number, 2);
            return new List<double> { root, sqr };
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите esc");
            do
            {
                Console.Write("Введите число: ");
                //получение данных. можно было через try
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    //массивы из функций записываются в переменные. можно было менять в самой функции, а не возвращать 
                    var sep = separation(number);
                    var ud = updown(number); ;
                    //вывод + форматирование + проверка корня 
                    Console.WriteLine($"Квадрат числа равен: {ud[1].ToString("f3")}. \r\n" +
                        $"Корень: {(ud[0] == -1 ? "не удалось вычислить." : ud[0].ToString("f3"))}. \r\n" +
                        $"Целая часть = {sep[0]}, дробная = {sep[1].ToString("f3")}.");

                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
