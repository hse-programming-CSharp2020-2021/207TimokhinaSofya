using System;

namespace hw_5
{
    class Program
    {
        //возвращение значения ф-ии в указанной точке
        static double Funk_G(double x)
        {
            if (x <= 0.5)
            {
                return Math.Sin(Math.PI / 2);
            }
            return Math.Sin(Math.PI * (x - 1) / 2);
        }

        static void Main(string[] args)
        {
            do
            {
                double x;
                Console.Clear();
                //запрос х до тех пор, пока не будет введено число 
                do
                {
                    Console.Write("Введите x: ");
                } while (!double.TryParse(Console.ReadLine(), out x));

                Console.WriteLine($"G = F({x}) = {Funk_G(x):f3}");
                Console.WriteLine("Для выхода нажмите esc.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
