using System;
using System.Linq;

namespace seminar1_05
{
    class Program
    {
        static void Create(int N, ref double[] Array)
        {
            for (int i = 0; i < N; i ++)
            {
                Array[i] = (i * (i + 1) / 2) % N;
            }

        }

        static void Norm(ref double[] Array)
        {
            double maxValue = Array.Max();
            for (int i = 0; i < Array.Count(); i++)
            {
                Array[i] /= maxValue;
            }
        }

        static void Output(double[] Array)
        {
            for (int i = 0; i < Array.Count(); i++)
            {
                Console.WriteLine(Array[i].ToString("f3"));
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Ошибка. Введите еще раз: ");
            }
            double[] Array = new double[N];
            Create(N, ref Array);
            Norm(ref Array);
            Output(Array);
            Console.ReadLine();
        }
    }
}
