using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    delegate void Qdelegate(QuadraticEquation qe);
    class Program
    {
        static void Main(string[] args)
        {
            Processing.WriteFile("equation.ser", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.ReadFile("equation.ser", new Qdelegate(Processing.Solve));
            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();

        }
    }

    [Serializable]
    class QuadraticEquation
    {
        private double a = 1;
        private double b = 2;
        private double c = 1;
        public double A
        {
            get => a;
            set => a = value == 0 ? throw new ArgumentException() : value;

        }
        public double C { get => c; set => c = value; }
        public double B { get => b; set => b = value; }

        public double Discriminant => Math.Pow(b, 2) - 4 * a * c;
        public double X1 => (-b - Math.Sqrt(Discriminant)) / (2 * a);
        public double X2 => (-b + Math.Sqrt(Discriminant)) / (2 * a);
        public QuadraticEquation() { }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
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
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                for (int i = 0; i < numberOfEq; i++)
                    binaryFormatter.Serialize(fileStream, GenerateRandomequation());
            }
        }

        public static void ReadFile(string filename, Qdelegate qDel)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                while (true)
                {
                    try
                    {
                        QuadraticEquation quadraticEquation = binaryFormatter.Deserialize(fileStream) as QuadraticEquation;
                        qDel(quadraticEquation);
                    }
                    catch { return; }
                }
            }
        }
    }
}