// Проект 2. Чтение целых из двоичного потока. 
// ЧИТАТЬ И ЗАПИСЫВАТЬ СТРОГО ПО ОДНОМУ ЧИСЛУ!!! 
using System;
using System.IO;
class Program
{
    static void Main()
    {
        Write();
        FileStream f = new FileStream("../../../t.dat", FileMode.Open);

        BinaryReader fIn = new BinaryReader(f);
        long n = f.Length / 4; int a;
        for (int i = 0; i < n; i++)
        {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
        }
        Console.WriteLine("\nЧисла в обратном порядке:");
        f.Position = f.Length - 4;
        for (int i = 0; i < n; i++)
        {
            a = fIn.ReadInt32();
            Console.Write(a + " ");
            f.Position = Math.Max(f.Position - 8, 0);
        }
        // 2) TODO: увеличить  все числа в файле в 5 раз
        BinaryWriter fOut = new BinaryWriter(f);
           n = f.Length / 4;
        for (int i = 0; i < n; i++)
        {
            a = 5 * fIn.ReadInt32();
            f.Position -= 4;
            fOut.Write(a);
        }

        // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
        Console.WriteLine("Числа из файла.");
        f.Position = 0;
        for (int i = 0; i < n; i++)
        {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
        
        }
        fIn.Close();
        f.Close();
        fOut.Close();
        Console.ReadKey();
    }

    // Проект 1. Запись целых чисел в двоичный поток
    static void Write()
    { 
        BinaryWriter fOut = new BinaryWriter(

            new FileStream("../../../t.dat", FileMode.Create));

        for (int i = 0; i <= 10; i += 2)

            fOut.Write(i);

        fOut.Close();
    }
}