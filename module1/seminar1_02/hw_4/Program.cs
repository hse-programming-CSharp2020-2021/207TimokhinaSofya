using System;

namespace hw_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            if (int.TryParse(number, out int sucsess) && number.Length == 4)
            {
                char[] str = number.ToCharArray();
                Array.Reverse(str);
                foreach (char el in str)
                {
                    Console.WriteLine(el);
                }
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
