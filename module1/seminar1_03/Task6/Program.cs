using System;

namespace Task6
{
    class Program
    {
        static double Total(double k, double r, uint n)
        {
            //формула + возврат значения 
            return k * Math.Pow(1 + r/100, n);
        }
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    //получение значений 
                    Console.Write("Начальный капитал: ");
                    double capital = double.Parse(Console.ReadLine());
                    Console.Write("Процентная ставка: ");
                    double percent = double.Parse(Console.ReadLine());
                    Console.Write("Количество лет: ");
                    uint years = uint.Parse(Console.ReadLine());
                    //проверка
                    if (capital > 0 && percent > 0 && years > 0)
                    {
                        for (uint i = 1; i <= years; i++)
                        {
                            //вывод значений (каждый год)
                            Console.WriteLine($"Итоговая сума в конце {i + 1} года равна " +
                                $"{Total(capital, percent, i):f3}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                //при получении неверных данных
                catch
                {
                    Console.WriteLine("Ошибка");
                }
                Console.WriteLine("Для выхода нажмите esc");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
