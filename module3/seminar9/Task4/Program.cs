using System;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Block3D[] block3Ds = Enumerable.Range(0, (new Random()).Next(4, 20)).Select(x => GetRndBl()).ToArray();
            Array.ForEach(block3Ds, Console.WriteLine);
            Array.Sort(block3Ds);
            Console.WriteLine("Sorted");
            Array.ForEach(block3Ds, Console.WriteLine);
            Console.ReadLine();
        }

        static Block3D GetRndBl()
        {
            Rectangle rectangle = new Rectangle((new Random()).Next(1, 15), (new Random()).Next(1, 15));
            return new Block3D(rectangle);
        }
    }

    struct Rectangle: IComparable
    {
        int left;
        int top;

        public Rectangle(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public int Area => left* top;

        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
            {
                Rectangle other = (Rectangle)obj;
                return Area.CompareTo(other.Area);
            }
            return 1;
        }
    }

    class Block3D: IComparable
    {
        public Rectangle Rectangle { get; }

        public Block3D(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public int CompareTo(object obj)
        {
            if (obj is Block3D)
            {
                Block3D other = (Block3D)obj;
                return Rectangle.CompareTo(other.Rectangle);
            }
            return 1;
        }

        public override string ToString() => $"Block area = {Rectangle.Area}";
    }
}

//Объявить структуру Rectangle, описывающую прямоугольник, заданный длинами сторон. Структура реализует интерфейс IComparable, сравнение структур происходит по величине площади прямоугольника.

//Объявить класс Block3D, описывающий «кирпич», заданный основанием и высотой. Основание – объект структуры Rectangle. Класс реализует интерфейс IComparable, сравнивая кирпичи по величине площади основания.

//В основной программе протестировать работу методов классов, отсортировав массив элементов типа Block3D.