using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace DataBaseTask2
{
    class DataBase
    {
        private readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();

        public string Name { get; }

        public DataBase(string name)
        {
            Name = name;
        }

        public void CreateTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (_tables.ContainsKey(tableType))
                throw new DataBaseException($"Table already exists {tableType.Name}!");

            _tables[tableType] = new List<T>();
        }

        public void InsertInto<T>(IEntityFactory<T> values) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            ((List<T>)_tables[tableType]).Add(values.Instance);
        }

        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))

                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return (IEnumerable<T>)_tables[tableType];
        }

        public void Serialize<T>() where T: IEntity
        {
            Type tableType = typeof(T);
            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");
            try
            {
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All)
                };
                using (StreamWriter stream = new StreamWriter($"DB{tableType.Name}.json"))
                {
                    var jsonString = JsonSerializer.Serialize(_tables[tableType], typeof(List<T>), serializerOptions);
                    stream.WriteLine(jsonString);
                    Console.WriteLine("Serialized.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops. Serialization error {e.Message}.");
            }

        }

        public void Deserialize<T>() where T: IEntity
        {
            Type tableType = typeof(T);
            try
            {
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All)
                };
                using (StreamReader fileStream = new StreamReader($"DB{tableType.Name}.json"))
                {
                    string jsonData = fileStream.ReadToEnd();
                    var data = JsonSerializer.Deserialize(jsonData, typeof(List<>).MakeGenericType(new Type[] { tableType }), serializerOptions);
                    _tables[tableType] = data;
                    Console.WriteLine("Deserialized.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops. Deserialization error {e.Message}.");
            }
        }
    }
}
