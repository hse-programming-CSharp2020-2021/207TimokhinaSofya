using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate(1, new Add(2), new Multiply(3));
            Console.ReadKey();
        }

        static void Calculate(double number, params ICalculation[] calculations)
        {
            foreach(ICalculation calculation in calculations)
            {
                number = calculation.Perform(number);
            }
            Console.WriteLine(number);
        }

        class Add : ICalculation
        {
            double x;
            public Add(double x) => this.x = x;

            public double Perform(double number) => x + number;
        }

        class Multiply : ICalculation
        {
            double x;
            public Multiply(double x) => this.x = x;

            public double Perform(double number) => x * number;
        }

        interface ICalculation
        {
            double Perform(double number);
        }
    }
}