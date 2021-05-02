using System;
using System.Collections.Generic;
using System.Linq;
class Program
{

    static void Main()
    {

        Fibbonacci fi = new Fibbonacci();
        var fib = fi.NextMemb(7).ToArray();

        TriangleNumbers triangleNumbers = new TriangleNumbers();
        var tr = triangleNumbers.NextMemb(7).ToArray();
        Console.WriteLine("Fib");
        Array.ForEach(fib, Console.WriteLine);
        Console.WriteLine("triangle");
        Array.ForEach(tr, Console.WriteLine);
        Console.WriteLine("+");
        for (int i = 0; i < Math.Max(tr.Count(), fib.Count()); i++)
            Console.WriteLine(tr[i] + fib[i]);
    }

    class Fibbonacci
    {
        int current = 0;
        int previous = 1;

        public IEnumerable<int> NextMemb(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var next = current + previous;
                yield return current;
                previous = current;
                current = next;
            }
            yield break;
        }
    }

    class TriangleNumbers
    {
        int number = 0;
        public IEnumerable<double> NextMemb(int count)
        {
            for (int i = 0; i < count; i++)
                yield return number * 0.5 * (number++ + 1);
            yield break;
        }
    }
}
