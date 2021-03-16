using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta", "DarkSeaGreen", "Lime", "Purple", "DarkGreen", "DarkOrange", "Black", "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}";
            return string.Format(format, x, y, color);
        }
    }

    class Test
    {
        static Random gen = new Random();
        public static void Main()
        {
            //int N = int.Parse(Console.ReadLine()); // Количество создаваемых объектов (число строк в файле)
            int N = 10;
                   //  TODO: Определить значение N 
            List<ColorPoint> list = new List<ColorPoint>();
            ColorPoint one;
            for (int i = 0; i < N; i++)
            {
                one = new ColorPoint();
                one.x = gen.NextDouble();
                one.y = gen.NextDouble();
                int j = gen.Next(0, ColorPoint.colors.Length);
                one.color = ColorPoint.colors[j];
                list.Add(one);
            }
            string[] arrData = Array.ConvertAll(list.ToArray(),
                         (ColorPoint cp) => cp.ToString());
            // Запись массива стpок в текстовый файл:
            string path = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "file.txt";
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                Array.ForEach(arrData, x => binaryWriter.Write(x.ToCharArray()));
            }
            Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}", N, path);

            using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                try
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        Console.WriteLine(binaryReader.ReadString());
                    }
                }
                catch { }
            }
        }
    }
}
