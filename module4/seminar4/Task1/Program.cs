using System;
using System.Collections.Generic;
using System.Linq;
class Program
{

    static void Main()
    {

        Fibbonacci fi = new Fibbonacci();

        foreach (int numb in fi.NextMemb(7))

            Console.Write(numb + "  ");

        Console.WriteLine();



        foreach (int numb in fi.NextMemb(7))

            Console.Write(numb + "  ");

        Console.WriteLine();

    }

    class Fibbonacci
    {
        int current = 0;
        int previous = 0;

        public IEnumerable<int> NextMemb(int count) =>
            Enumerable.Range(1, count).Select(x =>
            {
                int next = current + previous;
                previous = current;
                current = next;
                return next;
            });
    }
}
