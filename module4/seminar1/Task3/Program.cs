using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(University));
            using (FileStream fs = new FileStream("university.xml", FileMode.OpenOrCreate))
            {
                University university = new University("name1", new List<Dept>
            {
                new Dept("dept1", new List<Human>()
                {
                    new Human("1"),
                    new Human("2")
                }),
                new Dept("dept2", new List<Human>()
                {
                    new Human("3"),
                    new Human("4")
                })
            });
                formatter.Serialize(fs, university);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fileStream = new FileStream("university.xml", FileMode.OpenOrCreate))
            {
                University university = (University)formatter.Deserialize(fileStream);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine(university);
            }
        }
    }

    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public Human() { }

        public Human(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class Professor: Human
    {
        public Professor(string name) : base(name)
        { }

        public Professor() { }
    }

    [Serializable]
    public class Dept
    {

        public string DeptName { get; set; }

        List<Human> staff;

        public List<Human> Staff => staff;

        public Dept() { }

        public Dept(string name, List<Human> staffList)
        {
            DeptName = name;
            staff = staffList;
        }

        public override string ToString()
        {
            return $"Name {DeptName}\r\n" +
                $"Staff: {(staff is null ? "NO": string.Join(", ", staff))}";
        }
    }



    [Serializable]

    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }

        public University() { }

        public University(string name, List<Dept> depts)
        {
            UniversityName = name;
            Departments = depts;
        }

        public override string ToString()
        {
            return $"Name {UniversityName}\r\n" +
                $"{string.Join<Dept>("\r\n", Departments)}";
        }
    }
}
