using System;

namespace Task7
{
    class Program
    {
        static void nodnok (int a, int b, out int nod, out int nok)
        {
            nok = a * b;
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a; 
            }
            nod = a | b;
            nok /= nod;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
            {
                Console.WriteLine("Неверное значение. Выход.");
            }
            Console.Write("Введите второе число: ");
            if (!int.TryParse(Console.ReadLine(), out int b) || a <= 0)
            {
                Console.WriteLine("Неверное значение. Выход.");
            }
            nodnok(a, b, out int nod, out int nok);
            Console.WriteLine($"Для чисел {a} и {b}: НОД = {nod}, НОК = {nok}.");
            Console.ReadLine();
        }
    }
}
