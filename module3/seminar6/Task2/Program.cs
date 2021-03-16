using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Sum(new ArithmeticProgression(3, 5), 10));
            Console.ReadKey();
        }

        static double Sum(ISequence sequence, int numberOfEl)
        {
            double sum = 0;
            for (int i = 1; i <= numberOfEl; i++)
                sum += sequence.GetElement(i);
            return sum;
        }
        interface ISequence
        {
            public double GetElement(int id);
        }

        class ArithmeticProgression : ISequence
        {
            readonly double a1, d;

            public ArithmeticProgression(double a1, double d)
            {
                this.a1 = a1;
                this.d = d;
            }

            public double GetElement(int id)
            {
                if (id < 1) throw new ArgumentException();
                else return a1 + (id - 1) * d;
            }
        }

        class GeometricProjression : ISequence
        {
            double a1, d;

            public GeometricProjression(double a1, double d)
            {
                this.a1 = a1;
                this.d = d;
            }

            public double GetElement(int id)
            {
                if (id < 1) throw new ArgumentException();
                else return a1 * Math.Pow(d, id - 1);
            }
        }
    }
}
