using System;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 2 4 555
            string path = Directory.GetCurrentDirectory() +
                Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
                Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "Program.cs";
            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                Console.WriteLine(string.Join(", ", System.Text.Encoding.Default.GetChars(array).Where(x => char.IsDigit(x))));
            }
            Console.ReadKey();
        }
    }
}
