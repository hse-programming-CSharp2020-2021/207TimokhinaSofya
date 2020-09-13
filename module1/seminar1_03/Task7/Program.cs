using System;

namespace Task7
{
    class Program
    {
        static double discr(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
        static void equation(double a, double b, double c)
        {
            //проверка всех вариантов 
            if(a == 0)
            {
                if (b == 0) {
                    if (c == 0) {
                        Console.WriteLine("Бесконечно много корней");
                        return; //выход из функции без дальнейшей проверки
                    }
                    else
                    {
                        Console.WriteLine("Нет корней");
                        return;
                    }
                }
                Console.WriteLine($"x = {-c / b:f3}.");
                return;
            }
            if (b == 0) {
                if (c > 0) {
                    Console.WriteLine("Нет корней");
                    return;
                }
                double x = Math.Pow(-c / a, 0.5);
                Console.WriteLine($"x1 = {x:f3}, x2 = {-x:f3}.");
                return;
            }
            double d = discr(a, b, c);
            if (d < 0) {
                Console.WriteLine("Нет корней.");
                return;
            }
            else if (d == 0)
            {
                Console.WriteLine($"x = {-b / (2 * a):f3}.");
                return;
            }
            d = Math.Pow(d, 0.5);
            Console.WriteLine($"x1 = {(-b - d) / (2 * a):f3}, x2 = {(-b + d) / (2 * a):f3}.");
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                try
                {
                    //получение значений 
                    Console.Write("a = ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("c = ");
                    double c = double.Parse(Console.ReadLine());
                    //вызов функции и вывод полученного ответа 
                    equation(a, b, c);
                }
                catch
                //при неверно введенных значениях
                {
                    Console.WriteLine("Ошибка");
                }
                Console.WriteLine("Для выхода нажмите esc.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
