using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        delegate int[] toArray(int number);
        delegate void printArray(int[] numbers);


        static void Main(string[] args)
        {
            toArray toArray = x => x.ToString().Select(x => int.Parse(x.ToString())).ToArray();
            printArray printArray = x => Console.WriteLine(string.Join(" ", x));
            do
            {
                Console.WriteLine("Введите число: ");
                try
                {
                    printArray(toArray(int.Parse(Console.ReadLine())));
                }
                catch
                {
                    Console.WriteLine("Oh");
                }
                Console.WriteLine("Для завершения нажмите esc");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

            Console.WriteLine($"toArray target: {toArray.Target}, method: {toArray.Method}");
            Console.WriteLine($"printArray target: {printArray.Target}, method: {printArray.Method}");
        }
    }
}