using System;
using System.Drawing;


public delegate void SquareSizeChanged(float value);
class Program
{
    delegate double del();
    static void Main(string[] args)
    {
        do
        {
            Square square = new Square();
            square.OnSizeChanged += SquareConsoleInfo;
            square.Left = (GetFloat(), GetFloat());
            square.Right = (GetFloat(), GetFloat());
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
    private static float GetFloat()
    {
        float x;
        do
        {
            Console.Write("Введите значение: ");
            float.TryParse(Console.ReadLine(), out x);
        } while (x <= 0);
        return x;
    }

    static void SquareConsoleInfo(float number) => Console.WriteLine(Math.Round(number, 2));
}

class Square
{
    private PointF left = new PointF(11, 2);
    private PointF right = new PointF(13, 4);
    internal event SquareSizeChanged OnSizeChanged;

    public (float x, float y) Left
    {
        get => (left.X, left.Y);
        set
        {
            new PointF(value.x, value.y);
            OnSizeChanged?.Invoke(Lenght);
        }
    }

    public (float x, float y) Right
    {
        get => (right.X, right.Y);
        set
        {
            right = new PointF(value.x, value.y);
            OnSizeChanged?.Invoke(Lenght);
        }
    }

    private float Lenght => (float)(Math.Sqrt(Math.Pow(right.X - left.X, 2) +
                    Math.Pow(right.Y - left.Y, 2)) * Math.Sqrt(2));
}
