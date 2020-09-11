using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 10;
            string report = "Tочка ";
            Console.WriteLine("Введите координаты точки:");
            if (double.TryParse(Console.ReadLine(), out double x_point)
                && double.TryParse(Console.ReadLine(), out double y_point))
            {
                report += Math.Pow(x_point, 2) + Math.Pow(y_point, 2) > Math.Pow(r, 2)
                    ? "вне круга!" : "внутри круга!";
                Console.WriteLine(report);
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}
