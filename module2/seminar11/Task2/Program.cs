using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeomProgr geomProgr;
            do
            {
                try
                {
                    geomProgr = new GeomProgr(double.Parse(Console.ReadLine()),
                        double.Parse(Console.ReadLine()));
                    Console.WriteLine(geomProgr[1]);
                    Console.WriteLine(geomProgr.ProgrSum(10));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("Для завершения программы нажмите ESC");
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }

    public class GeomProgr
    {

        public GeomProgr()
        { 

            _b = 1;
            _q = 1;
            objectNumber++;
            Console.WriteLine(objectNumber + ": Конструктор без параметров");

        }

        // Конструктор общего вида (конструктор с параметрами):​

        public GeomProgr(double b, double q) : this()
        {
            _b = b == 0 || q == 0 ? throw new ArgumentException("Ошибка в аргументах конструктора!") : _b;
            _q = q;
            Console.WriteLine(objectNumber + ": Конструктор с параметрами");
        }

        public double this[int n]
        {
            get
            {
                return n < 0 ? throw new ArgumentException("Такого индекса нет!") : B * Math.Pow(Q, n - 1);
            } 
        }

​

        public double ProgrSum(int n)
        {
            return n < 0 ? throw new ArgumentException("Аргумент должен быть больше 0!"): B * (1 - Math.Pow(Q, n)) / (1 - Q);
        }


        public static uint objectNumber = 0;

        double _b; // первый член прогрессии b!=0​

        double _q; // знаменатель прогрессии q!=0​

        public double B
        {

            get { return _b; }

            set
            {
                if (value == 0)
                    throw new ArgumentException("Недопустимое значение первого члена прогрессии!");
                _b = value;
            }
        }

        public double Q
        {
            get { return _q; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Недопустимое значение знаменателя прогрессии!");
                _q = value;
            }
        }

    }
}
