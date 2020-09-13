using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_1
{
    class Program
    {
        static int Find()
        {
            int i = 1;
            int summa = 0;
            //пока число не будет состоять из 3 знаков и не будет удовлетворять условию, i увеличивается
            //считаем при этом, что такое число существует
            do
            {
                i++;
                summa = (1 + i) * i / 2; //сумма арифметической прогрессии, можно без формулы 
            } while (summa.ToString().Distinct().Count() != 1 || summa.ToString().Length != 3);
            return i;
        }
        static void Main(string[] args)
        {
            int i = Find();
            //вывод
            Console.WriteLine($"Полученное число: {((1 + i) * i / 2)}");
            Console.WriteLine($"Количество членов ряда: {i}");
            Console.WriteLine($"1+2+3+ ... +{i - 2}+{i - 1}+{i}");
        }
    }
}
