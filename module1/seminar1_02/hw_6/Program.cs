using System;

namespace hw_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.Write("Какой у вас бюджет? ");
                double budget = double.Parse(Console.ReadLine());
                Console.Write("Процент на игры: ");
                double precent = double.Parse(Console.ReadLine());
                if (precent > 100) {
                    Console.WriteLine("Процент больше 100, перебор");
                }
                else
                {
                    double summa = budget * (precent / 100);
                    Console.WriteLine(budget);
                    Console.WriteLine("Бюджет равен: {0}.", string.Format("{0:C3}", summa));
                }
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
