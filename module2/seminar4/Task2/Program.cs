using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[] { new Person("1", DateTime.Now, false),
                new Student("2", DateTime.Now, false, "2", "2"),
                new Employee("3", DateTime.Now, false, "3", "3", "3", 3)};
            foreach (Person person in people)
                person.ShowInfo();
            Console.ReadLine();
        }
    }

    class Person
    {
        public string fullName { get; set; }
        public DateTime birthDate { get; set; }
        public bool isMale { get; set; }

        public Person(string fullName, DateTime birthDate, bool isMale)
        {
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.isMale = isMale;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {fullName}\r\n Дата рождения: {birthDate}\r\n Пол:{(isMale ? "мужской": "женский")}");
        }
    }

    class Student : Person
    {
        public string institute { get; set; }
        public string speciality { get; set; }

        public Student(string fullName, DateTime birthDay, bool isMale,
            string institute, string speciality) : base(fullName, birthDay, isMale)
        {
            this.institute = institute;
            this.speciality = speciality;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($" Институт: {institute }\r\n Специальность: {speciality}");
        }
    }

    class Employee : Person
    {
        public string companyName { get; set; }
        public string post { get; set; }
        public string schedule { get; set; }
        public decimal salary { get; set; }

        public Employee(string fullName, DateTime birthDay, bool isMale, string companyName,
            string post, string schedule, decimal salary): base(fullName, birthDay, isMale)
        {
            this.companyName = companyName;
            this.post = post;
            this.schedule = schedule;
            this.salary = salary;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.Write($" Компания: {companyName}\r\n Должность: {post}\r\n График: {schedule}\r\n Зарплата: {salary}");
        }
    }
}
