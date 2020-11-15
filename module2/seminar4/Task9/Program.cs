using System;
using System.Linq;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int N;
                do
                {
                    Console.Write("Введите число N > 0: ");
                } while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);
                Random random = new Random();
                LinearEquation[] linearEquations = Enumerable.Range(0, N).Select(eq => new LinearEquation(random.Next(-10, 11), random.Next(-10, 11), random.Next(-10, 11))).ToArray();
                foreach (LinearEquation linearEquation in linearEquations)
                    Console.WriteLine(linearEquation.GetSolution());
                // Не сортировала, т к там может и не быть решений.
                Console.WriteLine("Для выхода нажмите esc, для повтора - любую другую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class LinearEquation
    {
        double a, b, c;
        public LinearEquation() { }
        public LinearEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public string GetSolution()
        {
            Console.WriteLine($"{a}x + {b} = {c}");
            if (a == 0)
            {
                if (c - b == 0)
                    return "x - любое число.";
                return "Корней нет.";
            }

            return $"x = {Math.Round((c - b) / a), 2}";
        }
    }

    // Решение квадратного уравнения, я просто читать не умею.
    //class LinearEquation
    //{
    //    double a, b, c;
    //    public LinearEquation() { }
    //    public LinearEquation(double a, double b, double c)
    //    {
    //        this.a = a;
    //        this.b = b;
    //        this.c = c;
    //    }

    //    private double Discriminant()
    //    {
    //        return Math.Pow(b, 2) - 4 * a * c;
    //    }
    //    public string GetSolution()
    //    {
    //        if (a == 0)
    //        {
    //            if (b == 0)
    //            {
    //                if (c != 0)
    //                    return "Нет корней.";
    //                return "x - любое число.";
    //            }
    //            return $"x = {-c / b}";
    //        }

    //        double discriminant = Discriminant();
    //        if (discriminant < 0)
    //            return "Нет корней.";
    //        if (discriminant == 0)
    //            return $"x = {-b / (2 * a)}";
    //        return $"x1 = {(-b + Math.Pow(discriminant, 0.5)) / (2 * a)}\r\n " +
    //            $"x2 = {(-b - Math.Pow(discriminant, 0.5)) / (2 * a)}";
    //    }
    //}
}
