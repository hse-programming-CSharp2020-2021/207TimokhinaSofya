using System;

namespace hw_5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите a:");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите b:");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Введите c:");
                double c = double.Parse(Console.ReadLine());
                Console.WriteLine((a + b > c && a + c > b && b + c > a) ? "Такой треугольник существует" : "Такой треугольник не существует");
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
