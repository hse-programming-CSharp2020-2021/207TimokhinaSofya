using System;
using System.Linq;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random random = new Random();
                GeometricProgression[] geometricProgressions =
                    Enumerable.Range(0, random.Next(5, 16)).Select(eq =>
                    new GeometricProgression(random.Next(0, 11), random.Next(1, 6))).ToArray();
                int step = random.Next(3, 16);
                GeometricProgression geometricProgression = new GeometricProgression(random.Next(0, 11), random.Next(1, 6));
                Console.WriteLine($"step = {step}, случайная последовательность: {geometricProgression}");
                foreach (var geometric in geometricProgressions.Select(eq => eq).Where(eq => eq[step] > geometricProgression[step]))
                    Console.WriteLine(geometric.ToString());
                foreach (var geometric in geometricProgressions)
                    Console.WriteLine(geometric.GetSum(step));
                Console.WriteLine("Для выхода нажмите esc, для повтора - любую другую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class GeometricProgression
    {
        double start = 0;
        double increment = 0;
        public GeometricProgression() { }
        public GeometricProgression(double start, double increment)
        {
            this.start = start;
            this.increment = increment;
        }

        public double this[int index]
        {
            get { return start * Math.Pow(increment, index - 1); }
        }

        public override string ToString()
        {
            return $"Первый элемент {start}, знаменатель прогрессии {increment}";
        }

        public double GetSum(int index)
        {
            return start * (Math.Pow(increment, index) - 1) / (increment - 1);
        }
    }
}
