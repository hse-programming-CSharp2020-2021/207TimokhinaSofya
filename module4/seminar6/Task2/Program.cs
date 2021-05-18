using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            Zoo zoo = new Zoo(Enumerable.Range(1, n).Select(el => GetAnimal()).ToList());
            zoo.Animals.ForEach(Console.WriteLine);
            Console.WriteLine(Environment.NewLine);
            zoo.Animals.ForEach(an => an.DoSound());
            Console.WriteLine(Environment.NewLine);
            zoo.Animals.Where(an => an is Bird && an.IsTakenCare).ToList().ForEach(Console.WriteLine);
            Console.WriteLine(Environment.NewLine);
            zoo.Animals.Where(an => an is Mammal && !an.IsTakenCare).ToList().ForEach(Console.WriteLine);
        }

        private static Animal GetAnimal()
        {
            Random random = new Random();
            switch (random.Next(0, 2)) {
                case 0:
                    return new Bird(GetARandomString(), random.Next(0, 2) == 0, random.Next(1, 101));
                 case 1:
                    return new Mammal(GetARandomString(), random.Next(0, 2) == 0, random.Next(1, 20));
                default:
                    return null;
            }
        }

        private static string GetARandomString()
        {
            Random random = new Random();
            var randomString = string.Join("", Enumerable.Range(1, random.Next(6, 12)).Select(x => (char)random.Next('a', 'z')));
            return char.ToUpper(randomString[0]) + randomString.Substring(1);
        }
    }


    interface IVocal
    {
        public void DoSound();
    }

    abstract class Animal : IVocal
    {
        static public int id = 1;
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public bool IsTakenCare { get; set; }

        public void DoSound()
        {
        }

        public override string ToString() => $"Id: {Id}, name: {Name}, is taken care: {(IsTakenCare ? "yes" : "no")}";
    }

    class Mammal: Animal
    {
        private int paws;
        public int Paws
        {
            get => paws;
            set
            {
                paws = value < 1 || value > 20 ? throw new ArgumentException("Too much") : value;
            }
        }

        public Mammal(string name, bool isTakenCare, int paws)
        {
            Name = name;
            IsTakenCare = isTakenCare;
            Paws = paws;
            Id = id++;
        }

        public override string ToString() => $"Mammal. {base.ToString()}, paws: {paws}";

        new public void DoSound()
        {
            Console.WriteLine("«я млекопитающие, би-би-би»");
        }
    }

    class Bird: Animal
    {
        private int speed;
        public int Speed
        {
            get => speed;
            set
            {
                speed = value < 1 || value > 100 ? throw new ArgumentException("Too much") : value;
            }
        }

        public Bird(string name, bool isTakenCare, int speed)
        {
            Name = name;
            IsTakenCare = isTakenCare;
            Speed = speed;
            Id = id++;
        }

        public override string ToString() => $"Bird. {base.ToString()}, speed: {speed}";
    }

    class Zoo
    {
        public List<Animal> Animals { get; set; }

        public Zoo(List<Animal> animals)
        {
            Animals = animals;
        }

        new public void DoSound()
        {
            Console.WriteLine("я птичка, пип-пип-пип");
        }
    }
}
