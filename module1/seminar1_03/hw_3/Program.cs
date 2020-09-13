using System;

namespace hw_3
{
    class Program
    {
        static bool Check(double x, double y)
        {
            //длина вектора 
            double p = Math.Pow(Math.Pow(x, 2) + Math.Pow(y, 2), 0.5);
            //если вектор больше радиуса 
            if (p > 2) {
                return false;
            }
            //если точка совпадает с началом координат 
            if (p == 0) {
                return true;
            }
            //угол ( от точки (0, 0))
            double q = Math.Acos(x / p);
            Console.WriteLine(q);
            if (x < 0 || y < 0) {
                q *= -1;
            }
            if (q <= Math.PI / 4 && q >= - Math.PI/ 2)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                double x, y; //координаты точки 
                //получение данных до тех пор, пока не будут получены верные 
                do
                {
                    Console.Write("Координата x: ");
                } while (!double.TryParse(Console.ReadLine(), out x));
                do
                {
                    Console.Write("Координата y: ");
                } while (!double.TryParse(Console.ReadLine(), out y));
                //вызов ф-ии, вывод результата 
                if (Check(x, y))
                {
                    Console.WriteLine("Точка внутри сектора");
                }
                else
                {
                    Console.WriteLine("Точка не внутри сектора.");
                }
                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
