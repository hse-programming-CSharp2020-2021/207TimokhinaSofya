
//Объявить структуру ConsoleSimbolStruct, описывающую символ, расположенный в определённой позиции консольного окна.  Поля:

//•simb – символ
//•x – целочисленная координата
//•y – целочисленная координата
//Для получения значений полей использовать свойства.

//Инициализация полей выполняется конструктором с параметрами типов char, int, int.

//В основной программе создать массив символов, со случайными координатами.

//ConsoleSimbolStruct сделать классом. Создать наследника ColorConsoleSimbol.
//    В основной программе сделать массив из ConsoleSimbolStruct и ColorConsoleSimbol. Выполнить 4 вида сериализации и десериализации.

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    class Program
    {
        static async Task Main()
        {
            Random random = new Random();
            var simbols = Enumerable.Range(1, random.Next(10, 20)).Select(x => GetRandom()).ToArray();
            Console.WriteLine(string.Join<ConsoleSimbolStruct>(Environment.NewLine, simbols));
            Data(simbols);
            await Json(simbols);
            Xml(simbols);
            Bin(simbols);

        }

        static ConsoleSimbolStruct GetRandom()
        {
            Random random = new Random();
            return random.Next(0, 2) == 0 ? new ConsoleSimbolStruct((char)random.Next('a', 'z'), random.Next(10, 100), random.Next(10, 100)) : new ColorConsoleSimbol((char)random.Next('a', 'z'), random.Next(10, 100), random.Next(10, 100));
        }

        static async Task Json(ConsoleSimbolStruct[] simbols)
        {
            Console.WriteLine("json");
            using (Stream file = new FileStream("JsonSer.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await JsonSerializer.SerializeAsync(file, simbols);
            }
            ConsoleSimbolStruct[] deserial;
            using (Stream file = File.OpenRead("JsonSer.json"))
            {
                deserial = await JsonSerializer.DeserializeAsync<ConsoleSimbolStruct[]>(file);
                Console.WriteLine(string.Join<ConsoleSimbolStruct>(Environment.NewLine, deserial));

            }
        }

        static void Xml(ConsoleSimbolStruct[] simbols)
        {
            Console.WriteLine("xml");
            XmlSerializer formatter = new XmlSerializer(typeof(List<ConsoleSimbolStruct>), new Type[] { typeof(ColorConsoleSimbol) });

            using (FileStream fs = new FileStream("simb.xml", FileMode.Create))
            {
                formatter.Serialize(fs, simbols.ToList());
            }

            using (FileStream fs = new FileStream("simb.xml", FileMode.Open))
            {

                List<ConsoleSimbolStruct> deserial = (List<ConsoleSimbolStruct>)formatter.Deserialize(fs);
                Console.WriteLine(string.Join(Environment.NewLine, deserial));
            }
        }

        static void Bin(ConsoleSimbolStruct[] simbols)
        {
            Console.WriteLine("bin");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("bin.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, simbols);
            }

            using (FileStream fs = new FileStream("bin.dat", FileMode.OpenOrCreate))
            {
                ConsoleSimbolStruct[] deserial = (ConsoleSimbolStruct[])formatter.Deserialize(fs);
                Console.WriteLine(string.Join<ConsoleSimbolStruct>(Environment.NewLine, deserial));
            }
        }

        static void Data(ConsoleSimbolStruct[] simbols)
        {
            Console.WriteLine("dataContract");
            DataContractSerializer serializer = new DataContractSerializer(typeof(ConsoleSimbolStruct[]), new Type[] { typeof(ColorConsoleSimbol)});
            using (Stream file = new FileStream("data.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.WriteObject(file, simbols);
            }

            ConsoleSimbolStruct[] deserial;
            using (Stream file = File.OpenRead("data.json"))
            {
                deserial = (ConsoleSimbolStruct[])serializer.ReadObject(file);
                Console.WriteLine(string.Join<ConsoleSimbolStruct>(Environment.NewLine, deserial));
            }
        }
    }


    [Serializable]
    [DataContract]
    public class ConsoleSimbolStruct
    {
        [DataMember]
        public char Simb { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }

        public ConsoleSimbolStruct() { }

        public ConsoleSimbolStruct(char simb, int x, int y)
        {
            X = x;
            Y = y;
            Simb = simb;
        }

        public override string ToString()
        {
            return $"Base {Simb}. x = {X}, y = {Y}";
        }
    }


    [Serializable]
    [DataContract]
    public class ColorConsoleSimbol : ConsoleSimbolStruct
    {
        public ColorConsoleSimbol(char simb, int x, int y): base(simb, x, y)
        {
            X = x;
            Y = y;
            Simb = simb;
        }

        public ColorConsoleSimbol() { }

        public override string ToString()
        {
            return $"Color {Simb}. x = {X}, y = {Y}";
        }
    }
}
