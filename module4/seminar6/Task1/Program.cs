using System;
using System.Collections.Generic;
using System.Linq;

//В некоторой коллекции хранятся целые числа. Вводите n с клавиатуры и генерируете последовательность от -10000 до 10000.
//Все выражения составить в форме запросов и в форме методов расширений.
//1) Составить LINQ-выражение, формирующее коллекцию, содержащую их последние цифры.
//2) Сгруппировать коллекцию по последней цифре.
//3) Составить запрос, формирующий коллекцию четных положительных чисел и выводит их количество
//4) Составить запрос, находящий сумму всех четных чисел
//5) Составить запрос, который сортирует числа по 1 и по последней цифре числа

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var seq = Enumerable.Range(1, random.Next(8, 13)).Select(el => el = random.Next(-10000, 10000)).ToList();
            Console.WriteLine($"seq: {string.Join(", ", seq)}\r\n");
            LastNums(seq);
            GroupByLast(seq);
            Evens(seq);
            EvensSum(seq);
            Sort(seq);
        }

        static void LastNums(List<int> seq)
        {
            var last1 = seq.Select(el => Math.Abs(el % 10));
            var last2 = from el in seq
                        select Math.Abs(el % 10);
            Console.WriteLine($"last1: {string.Join(", ", last1)}");
            Console.WriteLine($"last2: {string.Join(", ", last2)}\r\n");
        }

        static void GroupByLast(List<int> seq)
        {
            var group1 = seq.GroupBy(el => el % 10).Select(group => $"{group.Key}, nums: {string.Join(", ", group)}");
            var group2 = from el in seq
                         group el by el % 10 into gr
                                             select $"{gr.Key}, nums: {string.Join(", ", gr)}";
            Console.WriteLine($"group1: \r\n{string.Join("\r\n", group1)}");
            Console.WriteLine($"group2: \r\n{string.Join("\r\n", group2)}\r\n");
        }

        static void Evens(List<int> seq)
        {
            var evens1 = seq.Where(el => el % 2 == 0 && el > 0).Count();
            var evens2 = (from el in seq
                         where el % 2 == 0 && el > 0
                         select el).Count();
            Console.WriteLine($"evens1 {evens1}");
            Console.WriteLine($"evens2 {evens2}\r\n");
        }

        static void EvensSum(List<int> seq)
        {
            var evens1 = seq.Where(el => el % 2 == 0).Sum();
            var evens2 = (from el in seq
                          where el % 2 == 0
                          select el).Sum();
            Console.WriteLine($"evens1 {evens1}");
            Console.WriteLine($"evens2 {evens2}\r\n");
        }

        static void Sort(List<int> seq)
        {
            var sort1 = seq.OrderBy(el => Math.Abs(el / Math.Pow(10, (int)Math.Log10(el)))).ThenBy(el => Math.Abs(el % 10));
            var sort2 = from el in seq
                        orderby Math.Abs(el / Math.Pow(10, (int)Math.Log10(el))), Math.Abs(el % 10)
                        select el;
            Console.WriteLine($"sort1: {string.Join(", ", sort1)}");
            Console.WriteLine($"sort1: {string.Join(", ", sort1)}\r\n");
        }
    }
}
