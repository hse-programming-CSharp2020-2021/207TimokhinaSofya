using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fileStream = new FileStream("a.bin", FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                Random random = new Random();
                Student[] students = Enumerable.Range(1, 10).Select(x => new Student("a", 1)).ToArray();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, students);
            }

            using (FileStream fileStream = new FileStream("a.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Student[] students = bf.Deserialize(fileStream) as Student[];
                Array.ForEach(students, Console.WriteLine);
            }
        }
    }

    [Serializable()]
    class Student
    {
        public string SecondName { get; private set; } = "";
        public int GradeNumber { get; private set; } = 1;

        public Student(string secondName, int grade)
        {
            SecondName = secondName;
            GradeNumber = grade;
        }

        public override string ToString()
        {
            return $"Student. SecondName {SecondName}, GradeNumber {GradeNumber}";
        }
    }
}