using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            List<Employee> employees = Enumerable.Range(0, random.Next(3, 10)).Select(el => RandomEmployee()).OrderBy(el => el.CalculatePay()).ToList();
            Console.WriteLine($"SalesEmployees:\r\n{string.Join("; ", employees.Where(el => el is SalesEmployee))}\r\n");
            Console.WriteLine($"PartTimeEmployees:\r\n{string.Join("; ", employees.Where(el => el is PartTimeEmployee))}\r\n");
            Console.ReadLine();
        }

        static string RandomName()
        {
            return $"{(char)random.Next('А', 'Я')}{string.Join("", Enumerable.Range(0, random.Next(3, 10)).Select(el => (char)random.Next('а', 'я')).ToList())}";
        }

        static Employee RandomEmployee()
        {
            switch (random.Next(0, 3))
            {
                case 0:
                    return new Employee(RandomName(), random.Next(0, 10000));
                case 1:
                    return new SalesEmployee(RandomName(), random.Next(0, 10000), random.Next(0, 1000));
                default:
                    return new PartTimeEmployee(RandomName(), random.Next(0, 10000), random.Next(0, 1000));

            }
        }
    }

    
}
