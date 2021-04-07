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
            using (FileStream fileStream = new FileStream("a.bin", FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                Group[] groups = new Group[2];
                Random random = new Random();
                groups[0] = new Group("a", Enumerable.Range(1, 10).Select(x => new Student("a", 1)).ToArray());
                groups[1] = new Group("aa", Enumerable.Range(1, 20).Select(x => new Student("aa", 2)).ToArray());
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, groups);
            }

            using (FileStream fileStream = new FileStream("a.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Group[] students = bf.Deserialize(fileStream) as Group[];
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

    [Serializable()]
    class Group
    {
        public Student[] Students { get; private set; }
        public string Name { get; set; }

        public Group(string name, Student[] students)
        {
            Name = name;
            Students = students;
        }

        public override string ToString()
        {
            return $"Group {Name}\r\n{string.Join<Student>("\r\n", Students)}";
        }
    }
}