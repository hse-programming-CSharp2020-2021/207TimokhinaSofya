using System;
using System.Collections.Generic;
using System.Linq;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetStack(Console.ReadLine()) ? "Da" : "No");
            Console.ReadKey();
        }

        private static bool GetStack(string data)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char el in data.ToCharArray())
            {
                if ("([{".Contains(el))
                    stack.Push(el);
                else if (")]}".Contains(el))
                {
                    if (stack.Last() == el)
                        stack.Pop();
                    else
                        return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
