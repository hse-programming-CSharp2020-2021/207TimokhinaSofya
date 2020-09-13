using System;

namespace hw_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода нажмите ESC");
            do
            {
                try //можно было через tryparce и if 
                {
                    //получение данных
                    Console.Write("Какой у вас бюджет? ");
                    double budget = double.Parse(Console.ReadLine());
                    Console.Write("Процент на игры: ");
                    double precent = double.Parse(Console.ReadLine());
                    //проверка процента (не более 100)
                    if (precent > 100)
                    {
                        Console.WriteLine("Процент больше 100, перебор");
                    }
                    else // если все условия выполнены, то возврат суммы на игры 
                    {
                        double summa = budget * (precent / 100);
                        Console.WriteLine("Бюджет равен: {0}.", string.Format("{0:C3}", summa));
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}