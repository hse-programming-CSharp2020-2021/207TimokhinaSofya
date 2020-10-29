using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Birthday
    {
        string name;
        int year, month, day;
        private string[] mounthes = "января февраля марта апреля мая июня июля августа сентября ноября декабря".Split();
        public Birthday(string name, int y = 1970, int m = 1, int d = 1)
        {
            this.name = name;
            year = y;
            month = m;
            day = d;
        }
        DateTime date
        {
            get { return new DateTime(year, month, day); }
        }
        public void DateToString()
        {
            Console.WriteLine($"{day} {mounthes[month - 1]} {year}");

        }
        public void DateToOtherString()
        {
            Console.WriteLine($"{day}-{month}-{year}");
        }
        public string Info
        {
            get { return $"{name}, {date}"; }
        }
        public double HowManyDays()
        {
            return (DateTime.Now - date).TotalDays;
        }
    }
}
