using System;


namespace hw_6
{
    class Program
    {
        static void Main(string[] args)
        {
            /* можно было записать все в массив, затем отсортировать по возрастанию,
             * смотря на часть строки s[1:2] */
            do
            {
                Console.Clear();
                //далее эта переменная будет принимать значение аудитории
                string cl = "None";
                for (int i = 1; i <= 3; i++) //цикл, записываются 3 аудитории 
                {
                    Console.Write($"Введите номер адитории {i}: ");
                    string a = Console.ReadLine();
                    //проверка, верно ли введено значение 
                    if (!int.TryParse(a, out int success) || a.Length != 3)
                    {
                        Console.WriteLine("Неверные данные");
                        //если нет, то запрашиваем еще раз
                        i--;
                    }
                    //выбор наименьшего номера 
                    else if (cl == "None" || int.Parse(a.Substring(1)) < int.Parse(cl.Substring(1)))
                    {
                        cl = a;
                    }
                }
                //вывод
                Console.WriteLine($"Минимальный номер внутри этажа имеет {cl} аудитория");
                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
