using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            do
            {
                Matrix2 A = new Matrix2(random.Next(), random.Next(), random.Next(), random.Next());
                Matrix2 B = new Matrix2(random.Next(), random.Next());
                Console.WriteLine($"A: {A}");
                Console.WriteLine($"B: {A}");
                try
                {
                    Console.WriteLine($"A^(-1)");
                    Console.WriteLine(A.Inverse());
                }
                catch(Exception e) { Console.WriteLine(e.Message); }
                try
                {
                    Console.WriteLine($"B^(-1)");
                    Console.WriteLine(B.Inverse());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine($"A^T\r\n{A.Transponse()}");
                Console.WriteLine($"B^T\r\n{B.Transponse()}");
                Console.WriteLine($"A - B: \r\n{A - B}");
                Console.WriteLine($"A + B: \r\n{A + B}");
                Console.WriteLine($"A * B: \r\n{A * B}");
                try
                {
                    Console.WriteLine("A / B");
                    Console.WriteLine(A / B);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                try
                {
                    Console.WriteLine("A / a");
                    Console.WriteLine(A / random.Next());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine($"A * random.Next() \r\n {A * random.Next()}");

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class Matrix2
    {
        private double a11;
        private double a12;
        private double a21;
        private double a22;

        public Matrix2(double a11, double a12, double a21, double a22)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a21 = a21;
            this.a22 = a22;
        }

        public Matrix2(double a11, double a22)
        {
            this.a11 = a11;
            this.a22 = a22;
        }

        public Matrix2(Matrix2 matrix)
        {
            a11 = matrix.a11;
            a12 = matrix.a12;
            a21 = matrix.a21;
            a22 = matrix.a22;
        }

        public double Det => a11 * a22 - a12 * a21;

        public Matrix2 Inverse()
        {
            if (Det == 0) throw new Exception("Det = 0!");
            return new Matrix2(a11 / Det, a21 / Det, a12 / Det, a22 / Det);
        }

        public Matrix2 Transponse()
        {
            return new Matrix2(a11, a21, a12, a22);
        }

        public static Matrix2 operator+(Matrix2 matrix1, Matrix2 matrix2)
        {
            return new Matrix2(matrix1.a11 + matrix2.a11, matrix1.a12 +
                matrix2.a12, matrix1.a21 + matrix2.a21, matrix1.a22 + matrix2.a22);
        }

        public static Matrix2 operator -(Matrix2 matrix1, Matrix2 matrix2)
        {
            return new Matrix2(matrix1.a11 - matrix2.a11, matrix1.a12 -
                matrix2.a12, matrix1.a21 - matrix2.a21, matrix1.a22 - matrix2.a22);
        }

        public static Matrix2 operator *(Matrix2 matrix1, Matrix2 matrix2)
        {
            return new Matrix2(matrix1.a11 * matrix2.a11 + matrix1.a12 * matrix2.a21, matrix1.a21 * matrix2.a11 +
                matrix1.a22 * matrix2.a21, matrix1.a12 * matrix2.a21 + matrix1.a22 * matrix2.a22, matrix1.a21  * matrix2.a12 + matrix1.a22 * matrix2.a22);
        }

        public static Matrix2 operator * (Matrix2 matrix, double lambda)
        {
            return new Matrix2(matrix.a11 * lambda, matrix.a12 * lambda, matrix.a21 * lambda, matrix.a22 * lambda);
        }

        public static Matrix2 operator /(Matrix2 matrix, double lambda)
        {
            if (lambda == 0) throw new ArgumentException("Lambda = 0");
            return new Matrix2(matrix.a11 / lambda, matrix.a12 / lambda, matrix.a21 / lambda, matrix.a22 / lambda);
        }

        public static Matrix2 operator /(Matrix2 matrix1, Matrix2 matrix2)
        {
            return matrix1 * matrix2.Inverse();
        }

        public static bool operator true(Matrix2 matrix2)
        {
            return matrix2.Det > 0;
        }

        public static bool operator false(Matrix2 matrix2)
        {
            return matrix2.Det <= 0;
        }

        public static implicit operator double(Matrix2 matrix)
        {
            return matrix.Det;
        }

        public override string ToString()
        {
            return $"{a11}\t{a12}\r\n{a21}\t{a22}";
        }
    }
}
