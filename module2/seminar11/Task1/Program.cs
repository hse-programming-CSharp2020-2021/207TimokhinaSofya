using System;

namespace Task1

{
    public class Program
    {

        static void Main(string[] args)
        {

            Matrix res = new Matrix() ; // ссылка на двумерный массив (матрица)​

            do
            {
                try
                {
                    res.GetIntValue();
                    res.UnitMatr();
                    res.MatrPrint();

                }

                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                finally
                {
                    Console.WriteLine("Для завершения программы нажмите ESC");
                }

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

    }

    }

    public  class Matrix
    {
        int[,] array;
        int rank;
        public void GetIntValue()
        {

            Console.WriteLine("Введите порядок матрицы: ");
            rank = int.Parse(Console.ReadLine());

        }

        public  void MatrPrint()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j]}\t");
                Console.WriteLine();
            }
        }

        public  int[,] UnitMatr()
        {

            if (rank <= 0)
                throw new ArgumentOutOfRangeException("Аргумент метода ​ должен быть положительным!");
            int[,] array = new int[rank, rank];
            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                    array[i, j] = i == j ? 1 : 0;
            return array;

        }

    }
}
