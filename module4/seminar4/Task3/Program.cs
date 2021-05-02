using System;
using System.Collections.Generic;
using System.Collections;

namespace Task3
{
    class Program
    {
        static void Main()
        {

            Evens ev = new Evens(20, 43);
            foreach (var t in ev)
                Console.Write(t + "  ");
            Console.WriteLine();
            Console.ReadKey();
        }

        class Evens : IEnumerable<int>
        {
            private int from = 0;
            private int to = 0;

            public Evens(int from, int to)
            {
                this.from = from;
                this.to = to < from ? throw new ArgumentException() : to;
            }

            public IEnumerator<int> GetEnumerator()
            {
                for (int i = from; i <= to; i++)
                    if (i % 2 == 0) yield return i;
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}

//Создать класс Evens для представления нумеруемой (перечислимой)
//коллекции целых четных чисел из фиксированного диапазона [Nmin, Nmax].
//В основной программе создать объект класса-коллекции и применить к нему оператор foreach.