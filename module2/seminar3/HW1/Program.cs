using System;

namespace HW1
{
    class ArProgress
    {
        private double A1;
        private double d;
        public ArProgress(double first, double dif)
        {
            A1 = first;
            d = dif;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0) return -1;
                return Math.Round(A1 + (index - 1) * d, 2);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ArProgress progress = new ArProgress(1, 1.3);
            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(-10, 10);
                Console.WriteLine($"Член под номером {index} равен {progress[index]}.");
            }
            Console.ReadLine();
        }
    }
}
