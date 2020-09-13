using System;

namespace hw_4
{
    class Program
    {
        static double Func_G(double x, double y)
        {
            //проверка, возврат значения в заданной точке
            if (x < y && x > 0)
            {
                return x + Math.Sin(y);
            }
            else if (x > y && x < 0)
            {
                return y - Math.Cos(x);
            }
            return 0.5 * x * y;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                double x, y;
                //запрос значений до тех пор, пока они не будут удовл условиям 
                do
                {
                    Console.Write("Введите x: ");
                } while (!double.TryParse(Console.ReadLine(), out  x));
                do
                {
                    Console.Write("Введите y: ");
                } while (!double.TryParse(Console.ReadLine(), out y));
                //вывод полученного значния 
                Console.WriteLine($"G = F({x},{y}) = {Func_G(x, y):f3}");
                Console.Write("Для выхода нажмите esc.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
