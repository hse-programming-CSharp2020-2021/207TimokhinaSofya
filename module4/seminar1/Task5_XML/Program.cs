using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Linq;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Multiple));
            using (FileStream fileStream = new FileStream("a.ser", FileMode.Create))
            {
                Multiple multiple = new Multiple(new Random().Next(1, 10));
                xmlSerializer.Serialize(fileStream, multiple);
            }

            using (FileStream fileStream = new FileStream("a.ser", FileMode.Open))
            {
                Multiple multiple = xmlSerializer.Deserialize(fileStream) as Multiple;
                Console.WriteLine(multiple);
            }
        }
    }

    [Serializable]

    public class Multiple
    {
        public string name;
        public int divisor;
        public List<int> set;

        public Multiple(int divisor)
        {
            this.divisor = divisor <= 0 || divisor > 9 ? throw new ArgumentException() : divisor;
            name = "один два три четыре пять шесть семь восемь девять".Split()[divisor - 1];
            set = Enumerable.Range(0, 99).Where(x => x % divisor == 0).ToList();
        }

        public Multiple() { }

        public override string ToString()
        {
            return $"Divisor = {divisor} ({name}), set = {string.Join(", ", set)}";
        }
    }
}
