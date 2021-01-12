using System;

namespace Task2
{
    class Program
    {
        delegate int Cast(double number);
        static Random random = new Random();


        static void Main(string[] args)
        {
            WithAnon();
            WithLambda();
            Console.ReadLine();
        }

        static void WithAnon()
        {
            Cast anon1 = delegate (double number)
            {
                return (int)number.ToString().Length - 1;
            };

            Cast anon2 = delegate (double number)
            {
                return (int)Math.Round(number, 0, MidpointRounding.ToEven);
            };


            for (int i = 0; i < 5; i++)
            {
                double rndNumber = random.Next(0, 20) + random.NextDouble();
                Console.WriteLine($"number = {rndNumber} => порядок {anon1(rndNumber)}, ближайшее целое четное {anon2(rndNumber)}");
            }
        }

        static void WithLambda()
        {
            Cast lam1 = (number) => (int)number.ToString().Length;
            Cast lam2 = (number) => (int)Math.Round(number, 0, MidpointRounding.ToEven);
            Cast bigDelegate = lam1 + lam2;
            for (int i = 0; i < 5; i++)
            {
                double rndNumber = random.Next(0, 20) + random.NextDouble();
                Console.WriteLine($"number = {rndNumber} => ближайшее целое четное {bigDelegate(rndNumber)}");
            }
        }
    }
}
