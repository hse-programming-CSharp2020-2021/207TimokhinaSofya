using System;
using System.Linq;

namespace Task1
{
    class A
    {
        public virtual string getA()
        {
            return "A";
        }
    }

    class B: A
    {
        public override string getA()
        {
            return "B";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            A[] array = Enumerable.Range(0, 10).Select(el => random.Next(0, 2) == 0 ? new A() : new B()).ToArray();
            Console.WriteLine($"Все объекты: \r\n{string.Join(", ", array.Select(el => el.getA()).ToArray())}");
            Console.WriteLine($"Объекты А: \r\n{string.Join(", ", array.Where(el => el is A).Select(el => el.getA()).ToArray())}");
            Console.WriteLine($"Объекты B: \r\n{string.Join(", ", array.Where(el => el is B).Select(el => el.getA()).ToArray())}");
            Console.ReadLine();
        }
    }
}
