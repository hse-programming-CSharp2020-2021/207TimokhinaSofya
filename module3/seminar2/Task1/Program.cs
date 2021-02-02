using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = GetN();
            Random random = new Random();
            Plant[] plants = new Plant[n];

            for (int i = 0; i < n; i++)
                plants[i] = new Plant(random.Next(25, 101), random.Next(0, 101), random.Next(0, 101));

            {
                Array.ForEach(plants, x => Console.WriteLine(x));
                Console.WriteLine("______________");
            }

            {
                Array.Sort(plants, (a, b) => -a.Growth.CompareTo(b.Growth));
                Array.ForEach(plants, x => Console.WriteLine(x));
                Console.WriteLine("______________");
            }

            {
                Array.Sort(plants, (a, b) => a.Frostesistence.CompareTo(b.Frostesistence));
                Array.ForEach(plants, x => Console.WriteLine(x));
                Console.WriteLine("______________");
            }


            {
                Array.Sort(plants, delegate(Plant a, Plant b)
                {
                    if (a.Photosensitivity % 2 == 0 && b.Photosensitivity % 2 != 0)
                        return 1;
                    if (a.Photosensitivity % 2 != 0 && b.Photosensitivity % 2 == 0)
                        return -1;
                    return a.Photosensitivity.CompareTo(b.Photosensitivity);
                });

                Array.ForEach(plants, x => Console.WriteLine(x));
                Console.WriteLine("______________");
            }

            Array.ConvertAll(plants, x => x.Frostesistence % 2 == 0 ? x.Frostesistence / 3 : x.Frostesistence / 2);
            Console.ReadKey();
        }


        static private int GetN()
        {
            Console.WriteLine("Введите натуральное число n");
            if (int.TryParse(Console.ReadLine(), out int n))
                return n;
            return GetN();
        }
    }
    class Plant
    {
        private double growth;
        private double photosensitivity;
        private double frostesistence;

        public Plant(double growth, double photosensitivity, double frostesistence)
        {
            this.growth = growth;
            this.photosensitivity = photosensitivity > 100 || photosensitivity < 0 ?
                throw new ArgumentException("Неверный параметр") : photosensitivity;
            this.frostesistence = frostesistence > 100 || frostesistence < 0 ?
                throw new ArgumentException("Неверный параметр") : frostesistence;
        }

        public double Growth => growth;
        public double Photosensitivity => photosensitivity;
        public double Frostesistence {
            get => frostesistence;
            set => photosensitivity = value > 100 || value < 0 ?
                throw new ArgumentException("Неверный параметр") : value;
        }

        public override string ToString()
        {
            return $"Рост {growth} см, светочувствительность {photosensitivity}/100, " +
                $"морозоустойчивость {frostesistence}/100.";

        }

    }
}
