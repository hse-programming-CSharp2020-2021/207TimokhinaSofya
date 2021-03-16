using System;
using System.IO;
using System.Linq;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WithFile();
            WithStreamWriter();
            WithFileStream();
            WithBinaryStream();
        }

        static string[] CreateArray() => Enumerable.Range(0, 10).Select(x => (new Random()).Next(0, 200).ToString()).ToArray();

        static void WithFile()
        {
            string path = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "file1.txt";
            File.WriteAllLines(path, CreateArray());
            int sum = 0;
            foreach (string line in File.ReadAllLines(path))
            {
                if (int.TryParse(line, out int num) && num % 2 == 0)
                    sum += num;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static void WithStreamWriter()
        {
            string path = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "file2.txt";
            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(path)))
            {
                Array.ForEach(CreateArray(), x => streamWriter.WriteLine(x));
            }

            using (StreamReader streamReader = new StreamReader(File.OpenRead(path)))
            {
                int sum = 0;
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number) && number % 2 == 0)
                        sum += number;
                }
                Console.WriteLine(sum);
            }
            Console.ReadKey();
        }

        static void WithFileStream()
        {
            string path = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "file3.txt";
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] vs = System.Text.Encoding.Default.GetBytes(string.Join(Environment.NewLine, CreateArray()));
                fileStream.Write(vs);
            }
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fileStream.Length];
                string[] textFromFile = System.Text.Encoding.Default.GetString(array).Split();
                Console.WriteLine(textFromFile.Where(x => int.TryParse(x, out _)).Select(x => int.Parse(x)).ToArray().Sum());
                Console.ReadKey();
            }
        }

        struct a
        {
            protected int k;
        }
        enum Enumed: bool
        {
            one = 1
        }
        enum En2: bool
        {

        }


        static void WithBinaryStream()
        {
            string path = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." +
            Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "file4.txt";
            using (BinaryWriter binary = new BinaryWriter(File.OpenWrite(path)))
            {
                Array.ForEach(CreateArray(), x => binary.Write(x));
            }
            using (BinaryReader binary = new BinaryReader(File.OpenRead(path)))
            {
                int sum = 0;
                while(binary.PeekChar() > -1)
                {
                    string line = binary.ReadString();
                    if (int.TryParse(line, out int number) && number % 2 == 0)
                        sum += number;
                }
                Console.WriteLine(sum);
            }
            Console.ReadKey();

        }
    }
}
