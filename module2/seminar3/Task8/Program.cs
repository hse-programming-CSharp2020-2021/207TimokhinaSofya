using System;

namespace Task8
{
    class Week
    {
        private string[] days = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
        public Week() { }

        public string this[int index]
        {
            get { return (index >= 1 && index <= 7) ? days[index - 1] : "такого дня нет"; } 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Week week = new Week();
            for (int i = 0; i < 10; i ++)
            {
                int index = random.Next(-10, 10);
                Console.WriteLine($"День недели {index} называется: {week[index]}.");
            }
            Console.ReadLine();
        }
    }
}
