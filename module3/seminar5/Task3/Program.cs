using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            PassengerQueue passengerQueue = new PassengerQueue();
            Random random = new Random();
            for (int i = 0; i < random.Next(10, 20); i++)
                passengerQueue.AddToQueue(random.Next(2) == 1 ? new Passenger(CreateRandomString(),
                    CreateRandomString(), random.Next(1, 100)) : new PassengerWithChildren(CreateRandomString(), CreateRandomString(),
                    random.Next(1, 100), random.Next(1, 20)));
            passengerQueue.StartServingQueue();
            Console.ReadKey();

        }
        internal static string CreateRandomString()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            int lenght = random.Next(5, 8);
            for (int i = 0; i < lenght; i++)
                stringBuilder.Append((char)random.Next('а', 'я'));
            stringBuilder[0] = char.ToUpper(stringBuilder[0]);
            return stringBuilder.ToString();
        }
    }

    class Passenger
    {
        public Passenger(string name, string surname, int age)
        {
            Name = name.Length <= 30 && Array.TrueForAll(name.ToCharArray(), x => char.IsLetter(x)) ? name : throw new ArgumentException("Strange");
            Surname = surname.Length <= 40 && Array.TrueForAll(surname.ToCharArray(), x => char.IsLetter(x)) ? surname : throw new ArgumentException("Strange");
            Age = age >= 0 && age <= 120 ? age : throw new ArgumentException("Strange");
        }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public int Age { get; protected set; }
        public bool IsOld => Age >= 65;
        public override string ToString() => $"{Name} {Surname}, {Age} years old";
    }

    class PassengerWithChildren: Passenger
    {
        public int ChildrenNumber { get; set; }
        public bool IsNewBorn { get; }
        public PassengerWithChildren(string name, string surname, int age, int childrenNumber):base(name, surname, age)
        {
            ChildrenNumber = childrenNumber >= 1 && childrenNumber <= 40 ? childrenNumber: throw new ArgumentException("Strange");
            IsNewBorn = new Random().Next(2) == 1;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {ChildrenNumber} children";
        }
    }

    class PassengerQueue
    {
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger passenger)
        {
            if (passenger.IsOld || (passenger is PassengerWithChildren && ((PassengerWithChildren)passenger).IsNewBorn))
                priorityQueue.Enqueue(passenger);
            else
                ordinaryQueue.Enqueue(passenger);

        }
        public void StartServingQueue()
        {
            while (priorityQueue.Count > 3 && ordinaryQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
                Console.WriteLine(ordinaryQueue.Dequeue());
            }


            if (priorityQueue.Count != 0)
                for (int i = 0; i < priorityQueue.Count; i++) Console.WriteLine(priorityQueue.Dequeue());
            if (ordinaryQueue.Count != 0)
                for (int i = 0; i < ordinaryQueue.Count; i++) Console.WriteLine(ordinaryQueue.Dequeue());
        }

    }
}
