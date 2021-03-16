using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Var2
{    class Program
    {
        static void Main(string[] args)
        {
            FirstProgram.FistProgram();
            SecondProgram.ReadAll();
            Console.ReadKey();
        }

    }

    static class SecondProgram
    {
        static string path = "data.txt";

        public static void ReadAll()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка! файла не существует!");
                File.Create(path);
                return;
            }

            try
            {
                Street[] streets = File.ReadAllLines(path).ToArray().Select(element => GetStreet(element)).ToArray();
                var goodStreets = streets.Where(element => ~element % 2 == 1 && !element).ToArray();
                if (goodStreets.Length == 0)
                {
                    Console.WriteLine("Хороших улиц не было, но зато были такие: ");
                    Array.ForEach(streets, Console.WriteLine);
                }
                else
                {
                    Console.WriteLine("Хорошие улицы: ");
                    Array.ForEach(goodStreets, Console.WriteLine);
                }
            }
            catch
            {
                Console.WriteLine("Какие-то проблемы");
            }
        }

        static Street GetStreet(string element)
        {
            string[] data = element.Split();
            return new Street(data[0], data.Skip(1).Select(el => int.Parse(el)).ToArray());
        }
    }


    static class FirstProgram {
        static string path = "data.txt";

        public static void FistProgram()
        {
            bool allDataWasCorrect = true;
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка! файла не существует!");
                return;
            }

            int streetsCount = GetNumberOfStreets();
            Street[] streetArray = new Street[streetsCount];
            if (File.ReadAllLines(path).Length < streetsCount)
            {
                Console.WriteLine("В файле меньше улиц");
                allDataWasCorrect = false;
            }

            else {
                try
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        for (int i = 0; i < streetsCount; i++)
                        {
                            Street street = GetStreet(streamReader.ReadLine().Split());
                            if (street == null)
                            {
                                allDataWasCorrect = false;
                                Console.WriteLine("Не все данные корректны!");
                                break;
                            }
                            streetArray[i] = street;
                        }
                    }
                }
                catch {
                    allDataWasCorrect = false;
                    Console.WriteLine("Какие-то проблемы");
                }
            }

            if (!allDataWasCorrect)
                CreateArray(ref streetArray);
            WriteToFile(streetArray);
        }

        static void WriteToFile(Street[] streetArray)
        {
            try
            {
                using StreamWriter streamWriter = new StreamWriter(path);
                Array.ForEach(streetArray,
                    element => streamWriter.WriteLine($"{element.Name} {string.Join(" ", element.Houses)}"));
            }
            catch { Console.WriteLine("Какие-то проблемы"); }
        }


        static string GetRandomName()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < random.Next(5, 10); i++)
                stringBuilder.Append((char)random.Next('a', 'z' + 1));
            return stringBuilder.ToString();
        }

        static int[] GetRandomHouses()
        {
            Random random = new Random();
            int[] houses = new int[random.Next(2, 10)];
            for (int i = 0; i < houses.Length; i++)
                houses[i] = random.Next(1, 101);
            return houses;
        }


        static void CreateArray(ref Street[] streetArray)
        {
            for(int i = 0; i < streetArray.Length; i++)
                streetArray[i] = new Street(GetRandomName(), GetRandomHouses());
        }

        static int GetNumberOfStreets()
        {
            int count;
            Console.Write("Введите количество улиц: ");
            while (!int.TryParse(Console.ReadLine(), out count) || count < 1)
            {
                Console.Write("Количество улиц - целое число, больше ли равное одному!. Введите еще раз: ");
            }
            return count;
        }

        static Street GetStreet(string[] data)
        {
            if (data.Length <= 1) return null;


            string name = data[0];
            if (!Array.TrueForAll(name.ToCharArray(), element => char.IsLetter(element)))
                return null;

            int[] housesNumbers = new int[data.Length - 1];
            for (int i = 1; i < housesNumbers.Length; i++)
            {
                if (!int.TryParse(data[i], out int number) || number < 1 || number > 100) return null;
                housesNumbers[i] = number;
            }

            return new Street(name, housesNumbers);
        }
    }
}
