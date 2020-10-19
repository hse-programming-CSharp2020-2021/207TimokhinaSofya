using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Для выхода нажмите esc");
                do
                {
                    Console.Write("Введите N от 1 до 10000: ");
                } while (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 10000);
                List<double> Xin = new List<double>();
                List<double> Yin = new List<double>();
                List<double> Xout = new List<double>();
                List<double> Yout = new List<double>();
                List<double> X = new List<double>();
                List<double> Y = new List<double>();
                double x, y;

                
                Random random = new Random();
                for (int i = 0; i < N; i ++)
                {
                    x = random.Next(-5, 5) + random.NextDouble();
                    y = random.Next(-5, 5) + random.NextDouble();
                    X.Add(x);
                    Y.Add(y);
                    if ((Math.Pow(x, 2) + Math.Pow(y, 2)) >= 4 && (Math.Pow(x, 2) + Math.Pow(y, 2)) <= 16)
                    {
                        Xin.Add(x);
                        Yin.Add(y);
                    }
                    else
                    {
                        Xout.Add(x);
                        Yout.Add(y);
                    }
                }

                Console.WriteLine("Все точки: ");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"{ X[i]}, { Y[i]}");
                }
                Console.WriteLine("Точки в области: ");
                if (Xin.Count != 0)
                {
                    for (int i = 0; i < Xin.Count; i++)
                    {
                        Console.WriteLine($"{Xin[i]}, {Yin[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("null");
                }

                Console.WriteLine("Точки не в области: ");

                if (Xout.Count != 0)
                {
                    for (int i = 0; i < Xout.Count; i++)
                    {
                        Console.WriteLine($"{Xout[i]}, {Yout[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("null");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

    }
}
