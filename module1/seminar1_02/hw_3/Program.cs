using System;

namespace hw_3
{
    class Program
    {
        public static double discriminant(double A, double B, double C) // возвращает дискриминант
        {
            return Math.Pow(B, 2) - 4 * A * C;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите ESC");
            do
            {
                try //вместо if try. в таком случае, если не удалось запарсить, то не вылетает с ошибкой
                {
                    // получение данных
                    Console.Write("Введите a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введите b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Введите c: ");
                    double c = double.Parse(Console.ReadLine());
                    double discr = Math.Pow(discriminant(a, b, c), 0.5);
                    Console.WriteLine(discr >= 0 ? $"x1 = {((-b - discr) / (2 * a)).ToString("f3")}, x2 = {((-b + discr) / (2 * a)).ToString("f3")}" :
                        "Нет корней или уравнение не квадратное");
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

