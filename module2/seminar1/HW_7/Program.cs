using System;
using System.Linq;

namespace HW_7
{
    class Program
    {
        static string[] Filials = { "Западный", "Центральный", "Восточный" };
        static string[] Kvartal = { "1", "2", "3", "4" };
        static int[,] auto = { { 20, 24, 25 }, { 21, 20, 18 }, { 23, 27, 24 }, { 22, 19, 20 } };

        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("Вы можете выбрать следующие пункты:\r\n" +
                        "1. Вывести общее количество автомобилей, проданных всеми филиалами компании за год.\r\n" +
                        "2. Вывести минимальное количество автомобилей, проданных филиалом за квартал, а также имя филиала и номер квартала.\r\n" +
                        "3. Вывести название филиала, который продал максимальное количество автомобилей по результатам года, а также проданное филиалом количество автомобилей.\r\n" +
                        "4. Вывести наиболее успешный квартал, в котором компания показала наилучший результат по продажам(учитываются все филиалы, а также колчество автомобилей, проданной в нем.\r\n" +
                        "0. Выход\r\n");
            do
            {
                do
                {
                    Console.WriteLine("Что вы хотете сделать? Введите номер: ");
                } while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 4);

                switch (input)
                {
                    case 1:
                        GetSum();
                        break;
                    case 2:
                        GetMax();
                        break;
                    case 3:
                        GetBestFilial();
                        break;
                    case 4:
                        GetBestKvartal();
                        break;
                }
            } while (input != 0);
        }

        static void GetSum()
        {
            int sum = 0;
            for (int i = 0; i < Kvartal.Length; i++)
                for (int j = 0; j < Filials.Length; j++) sum += auto[i, j];
            Console.WriteLine($"Общее количество автомобилей: {sum}.");
        }

        static void GetMax()
        {
            int[] indexes = { 0, 0 };
            for (int i = 0; i < Kvartal.Length; i++)
                for (int j = 0; j < Filials.Length; j++)
                    if (auto[indexes[0], indexes[1]] < auto[i, j])
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                    }
            Console.WriteLine($"Максимальное количество автомобилей {auto[indexes[0], indexes[1]]} продал филиал {Filials[indexes[1]]} в {Kvartal[indexes[0]]} квартале.");
        }

        static void GetBestFilial()
        {
            int[] Amount = new int[Filials.Length];
            for (int i = 0; i < Filials.Length; i++)
            {
                for (int j = 0; j < Kvartal.Length; j++)
                    Amount[i] += auto[j, i];
            }
            int index = Array.IndexOf(Amount, Amount.Max());
            Console.WriteLine($"Лучшим оказался филиал {Filials[index]}, продав {Amount[index]} автомобилей.");
        }

        static void GetBestKvartal()
        {
            int[] Amount = new int[Kvartal.Length];
            for (int i = 0; i < Kvartal.Length; i++)
            {
                for (int j = 0; j < Filials.Length; j++)
                    Amount[i] += auto[i, j];
            }
            int index = Array.IndexOf(Amount, Amount.Max());
            Console.WriteLine($"Квартал {Kvartal[index]} был лучшим, в нем продали {Amount[index]} автомобилей!");
        }

    }
}