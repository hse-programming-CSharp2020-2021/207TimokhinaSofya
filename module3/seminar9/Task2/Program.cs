using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Write();
            int number;
            Read();
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.Write("Number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out number) && number >= 1 && number <= 100)
                {
                    ReplaceClosest(number);
                    Read();
                }
                else
                {
                    Console.WriteLine("Next");
                }
            }
            Console.ReadLine();
        }

        static void Write()
        {
            BinaryWriter fOut = new BinaryWriter(
                new FileStream("../../../Numbers.dat", FileMode.Create));
            Random random = new Random();

            for (int i = 0; i < 10; i++)

                fOut.Write(random.Next(1, 101));

            fOut.Close();
        }

        static void ReplaceClosest(int number)
        {
            var position = 0;
            int abs = 0;
            using (FileStream f = new FileStream("../../../Numbers.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                using (BinaryReader fIn = new BinaryReader(f))
                {
                    long n = f.Length / 4; int a;
                    for (int i = 0; i < n; i++)
                    {
                        a = fIn.ReadInt32();
                        if (Math.Abs(a - number) < abs)
                        {
                            abs = Math.Abs(a - number);
                            position = i;
                        }
                    }
                }

                using (BinaryWriter fIn = new BinaryWriter(f))
                {
                    fIn.Seek(position, SeekOrigin.Begin);
                    fIn.Write(number);
                }
            }
        }


        static void Read()
        {
            using (FileStream f = new FileStream("../../../Numbers.dat", FileMode.Open))
            {

                using (BinaryReader fIn = new BinaryReader(f))
                {
                    long n = f.Length / 4; int a;
                    for (int i = 0; i < n; i++)
                    {
                        a = fIn.ReadInt32();
                        Console.Write(a + " ");
                    }
                }
            }
        }
    }
}