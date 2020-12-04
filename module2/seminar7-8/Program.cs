using System;

namespace Task4

{ 
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticTrinomial quadraticTrinomial1 = new QuadraticTrinomial(2, 3, 7);
            QuadraticTrinomial quadraticTrinomial2 = new QuadraticTrinomial(1, -5, 6);

            foreach(double value in new int[] {1, 3, -3, 2, 7, 100, 0})
            {
                try
                {
                    Console.WriteLine($"Деление квадратного трехчлена {quadraticTrinomial1}" +
                        $" на {quadraticTrinomial2} в точке {value} " +
                        $"равно {quadraticTrinomial1.Division(quadraticTrinomial2, value)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }

    class QuadraticTrinomial
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public QuadraticTrinomial(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double GetValue(double point)
        {
            return Math.Pow(point, 2) * A + point * B + C;
        }

        public double Division(QuadraticTrinomial quadraticTrinomial, double point)
        {
            if(quadraticTrinomial.GetValue(point) == 0)
                throw new DivideByZeroException($"Ошибка. Значение многочлена {quadraticTrinomial} в этой точке = 0");
            return Math.Round(GetValue(point) / quadraticTrinomial.GetValue(point), 2);
        }

        public override string ToString()
        {
            return $"{A}x^2+{B}x+{C}";
        }
    }
}
