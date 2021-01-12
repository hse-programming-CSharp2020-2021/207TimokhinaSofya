using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Program
    {
        static Robot rob;
        delegate void Steps();
        static Steps steps;


        static void Main(string[] args)
        {
            rob = new Robot();
            try
            {
                Commands();
            }
            catch(ApplicationException)
            {
                Console.WriteLine("Выход за поле.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Непредвиденная ошибка");
            }
            Console.WriteLine("Завершение работы");
            Console.ReadLine();
        }

        private static void Commands()
        {
                Console.WriteLine("Введите команду (4 - инструкция): ");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    CreateCommandsForRob();
                    break;
                case '2':
                    steps?.Invoke();
                    steps = null;
                    rob.Position();
                    break;
                case '3':
                    return;
                case '4':
                    Console.WriteLine("1 - новая цепочка команд\r\n 2 - вывести путь,\r\n" +
                        "3 - выход");
                    break;
            }
            Commands();
        }


        private static void CreateCommandsForRob()
        {
            Console.WriteLine("R - направо, L - налево, F - вперед, B - назад");
            Console.Write("Введи команды в 1 строку: ");
            foreach(char ch in Console.ReadLine())
            {
                if (steps == null)
                    steps = ReturnMetod(ch);
                else 
                    steps += ReturnMetod(ch);
            }
        }

        private static Steps ReturnMetod(char ch)
        {
            switch (ch)
            {
                case 'R':
                    return new Steps(rob.Right);
                case 'L':
                    return new Steps(rob.Left);
                case 'F':
                    return new Steps(rob.Forward);
                case 'B':
                    return new Steps(rob.Backward);
                default:
                    Console.WriteLine($"Команда {ch} не выполнена");
                    break;
            }
            return null;
        }

        internal class Robot
        {
            // класс для представления робота
            int x, y; // положение робота на плоскости
            List<StringBuilder> field;

            public Robot()
            {
                CreateField();
            }

            private void CreateField()
            {
                (int x, int y) size = (GetSize("ширины"), GetSize("высоты"));
                field = Enumerable.Range(0, size.y).Select(el => new StringBuilder(new String(' ', size.x))).ToList();
                x = size.x / 2;
                y = size.y / 2;
                field[x][y] = '*';
            }

            private int GetSize(string fromWhat)
            {
                Console.Write($"Введите значение {fromWhat} (больше 0, но меньше 30): ");
                string number = Console.ReadLine();
                if (int.TryParse(number, out int numberInInt) && numberInInt > 0 && numberInInt <= 30)
                    return numberInInt;
                return GetSize(fromWhat);
            }

            private void check(int x, int y)
            {
                if (x > field.Count || x < 0 || y > field[0].Length || y < 0)
                    throw new ApplicationException();
            }

            public void Right()
            {
                check(x, y + 1);
                field[x][y++] = '+';
                field[x][y] = '*';
            }// направо
            public void Left() {
                check(x, y - 1);
                field[x][y--] = '+';
                field[x][y] = '*';
            }      // налево
            public void Forward() {
                check(x + 1, y);
                field[x++][y] = '+';
                field[x][y] = '*';
            }  // вперед
            public void Backward() {
                check(x - 1, y);
                field[x++][y] = '+';
                field[x][y] = '*';
            }  // назад

            public void Position()
            {
                Console.WriteLine(field.Count);
                foreach (StringBuilder stringBuilder in field)
                {
                    PrintWithColors(stringBuilder);
                    Console.WriteLine();
                }
            }

            private static void PrintWithColors(StringBuilder stringBuilder)
            {
                for (int i = 0; i < stringBuilder.Length; i++)
                {
                    switch (stringBuilder[i])
                    {
                        case '+':
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("+");
                            Console.ResetColor();
                            break;
                        case '*':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*");
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                }
            }
        }
    }
}
