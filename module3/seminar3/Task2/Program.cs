using System;
using System.Linq;


public delegate void NewLine();
class Program
{
    static void Main(string[] args)
    {
        WithStatic.NewLine += () => Console.WriteLine();
        WithStatic.GetArray(CreateArray());
        WithStatic.NewLine -= () => Console.WriteLine();
        WithStatic.NewLine += () => Console.WriteLine("****");
        WithStatic.GetArray(CreateArray());
        Console.ReadKey();
        
    }

    private static int[,] CreateArray()
    {
        Random random = new Random();
        int[,] array = new int[random.Next(5, 10), random.Next(5, 10)];
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = random.Next(-10, 10);
        return array;
    }
}

class WithStatic
{
    static internal event NewLine NewLine;

    public static void GetArray(int[,] array)
    {
        for(int i = 0; i < array.GetLength(0); i ++)
        {
            for (int j = 0; j < array.GetLength(1); j ++)
                Console.Write($"{array[i, j]}\t");
            NewLine?.Invoke();
        }
    }
}

