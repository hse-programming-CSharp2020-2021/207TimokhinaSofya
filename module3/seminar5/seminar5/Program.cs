using System;
using System.Collections.Generic;
using System.Linq;

namespace seminar5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LinkedList<char> linkedList = new LinkedList<char>();
                Stack<char> stack = new Stack<char>();
                Array.ForEach(int.Parse(Console.ReadLine()).ToString().ToCharArray(), el => {
                    linkedList.AddFirst(el);
                    stack.Push(el);
                });
                Console.WriteLine(string.Join(" ", linkedList));
                Console.WriteLine(string.Join(" ", stack));
            } 
            catch { Console.WriteLine("Ошибка"); }
            Console.ReadKey();
        }
    }
}
