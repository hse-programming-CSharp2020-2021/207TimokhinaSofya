using System;
using System.IO;

namespace Task3
{
    class Program
    {
        public static int Main()
        {
            int av = 0;
            try
            {

                using (var writer = new StreamWriter("inputfile.txt"))
                {
                    Console.SetOut(writer);
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine((new Random()).Next(100, 1001));
                    }

                }

                using (var reader = new StreamReader("inputfile.txt"))
                {
                    Console.SetIn(reader);
                    for (int i = 0; i < 100; i++)
                    {
                        try
                        {
                            av += int.Parse(Console.ReadLine());
                        }
                        catch { }
                    }
                }
            }
            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return 1;
            }

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine(av / 100);
            Console.ReadKey();
            return 0;
        }
    }
}

//•Написать код, перенаправляющий стандартный поток чтения. Вместо клавиатуры – текстовый файл (для этого сгенерировать текстовый файл, содержащий 100 случайных вещественных значений из диапазона 100..1000).
//•Прочитать стандартным потоком все строки текстового файла, вычислить среднее значение элементов и вывести его на экран
//•Восстановить стандартный поток ввода.