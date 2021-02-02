using System;

namespace Task1
{
    class Program
    {
        delegate void Calculate(double x);
        static void Main(string[] args)
        {
            try
            {
                double x = double.Parse(Console.ReadLine());
                Calculate calculate = x =>
                    {

                        double answer = 0;
                        for (int i = 1; i <= 5; i++)
                        {
                            double smallResult = 1;
                            for (int j = 1; j <= 5; i++)
                                smallResult *= i * x / j;
                            answer += smallResult;
                        }
                        Console.WriteLine(answer);
                    };
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
