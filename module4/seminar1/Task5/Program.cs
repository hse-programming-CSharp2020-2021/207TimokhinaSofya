using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("a.ser", FileMode.Create))
            {
                Multiple multiple = new Multiple(new Random().Next(1, 10));
                binaryFormatter.Serialize(fileStream, multiple);
            }

            using (FileStream fileStream = new FileStream("a.ser", FileMode.Open))
            {
                Multiple multiple = binaryFormatter.Deserialize(fileStream) as Multiple;
                Console.WriteLine(multiple);
            }
        }
    }

    [Serializable]

    class Multiple
    {
        string name;
        int divisor;
        List<int> set;

        public Multiple(int divisor)
        {
            this.divisor = divisor <= 0 || divisor > 9 ? throw new ArgumentException() : divisor;
            name = "один два три четыре пять шесть семь восемь девять".Split()[divisor - 1];
            set = Enumerable.Range(0, 99).Where(x => x % divisor == 0).ToList();
        }

        public override string ToString()
        {
            return $"Divisor = {divisor} ({name}), set = {string.Join(", ", set)}";
        }
    }
}
