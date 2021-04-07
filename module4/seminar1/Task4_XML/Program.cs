using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Linq;

namespace Task4
{
    delegate void Qdelegate(QuadraticEquation qe);
    class Program
    {
        static void Main(string[] args)
        {
            Processing.WriteFile("equation.xml", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.ReadFile("equation.xml", new Qdelegate(Processing.Solve));
            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();

        }
    }

    [Serializable, XmlRoot("QuadraticEquation")]
    public class QuadraticEquation
    {
        public double A { get; set; }
        public double C { get; set; }
        public double B { get; set; }

        public double Discriminant => Math.Pow(B, 2) - 4 * A * C;
        public double X1 => (-B - Math.Sqrt(Discriminant)) / (2 * A);
        public double X2 => (-B + Math.Sqrt(Discriminant)) / (2 * A);
        public QuadraticEquation() { }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a == 0 ? throw new ArgumentException(): a;
            B = b;
            C = c;
        }
    }


    static class Processing
    {
        public static void Solve(QuadraticEquation quadraticEquation)
        {
            if (quadraticEquation.Discriminant < 0) Console.WriteLine("Discriminant = 0");
            else if (quadraticEquation.Discriminant == 0) Console.WriteLine($"X = {quadraticEquation.X1}");
            else Console.WriteLine($"x1 = {quadraticEquation.X1}; x2 = {quadraticEquation.X2}");
        }

        public static QuadraticEquation GenerateRandomequation()
        {
            Random random = new Random();
            double a = random.Next();
            while (a == 0) a = random.Next();
            return new QuadraticEquation(a, random.Next(), random.Next());
        }

        public static void WriteFile(string filename, int numberOfEq = 10)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<QuadraticEquation>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                List<QuadraticEquation> quadraticEquations = Enumerable.Range(1, numberOfEq).Select(x => GenerateRandomequation()).ToList();
                formatter.Serialize(fileStream, quadraticEquations);
            }
        }

        public static void ReadFile(string filename, Qdelegate qDel)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<QuadraticEquation>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                Console.WriteLine("OK");
                while (true)
                {
                    try
                    {
                        var quadraticEquation = (List<QuadraticEquation>)formatter.Deserialize(fileStream);
                        quadraticEquation.ForEach(x => qDel(x));
                    }
                    catch { return; }
                }
            }
        }
    }
}