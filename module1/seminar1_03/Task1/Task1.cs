using System;

namespace Task1
{
    class Program
    {
        static string Checkmark(int mark)
        {
            switch (mark)
            {
                case 1:case 2:case 3:
                    return "Неудовлетворительно";
                case 4:case 5:
                    return "Удовлетворительно";
                case 6:case 7:
                    return "Хорошо";
                case 8:case 9:case 10:
                    return "Отлично";
            }
            return "Вы ошиблись";
        }
        static void Main(string[] args)
        {
            if (int.TryParse(Console.ReadLine(), out int mark)) {
                Console.WriteLine(Checkmark(mark));
            }
            else
            {
                Console.WriteLine("Ошибка");
            
            }
        }
    }
}
