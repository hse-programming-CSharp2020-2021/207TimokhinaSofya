using System;
using System.Linq;
using System.Collections.Generic;

namespace HW_3
{
    class Program
    {
        public class Poligon
        {
            int count;
            double radius;
            public Poligon(int n = 3, double r = 1)
            {
                count = n;
                radius = r;
            }

            public double perimetr
            {
                get { return 2 * radius * count * Math.Tan(Math.PI / count); }

                
            }
            public double area
            {
                get { return perimetr * radius / 2; }
            }

            public string PolygonData()
            {
                return $"{count}, {radius}, {perimetr}, {area}";
            }
        }
        static void Main(string[] args)
        {
            List<Poligon> poligons = new List<Poligon>();
            double randius = -1;
            int count = -1;
            while (randius != 0 && count != 0)
            {
                do
                {
                    Console.Write("Введите радиус > 0: ");
                } while (!double.TryParse(Console.ReadLine(), out randius) || randius < 0);
                do
                {
                    Console.Write("Введите количество сторон > 0: ");
                } while (!int.TryParse(Console.ReadLine(), out count) || count < 0);
                poligons.Add(new Poligon(count, randius));
            }
            poligons.RemoveAt(poligons.Count - 1);
            if (poligons.Count != 0)
            {
                double max = poligons.Max(x => x.area);
                double min = poligons.Min(x => x.area);
                foreach (Poligon poligon in poligons)
                {
                    if (poligon.area == max)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (poligon.area == min)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(poligon.PolygonData());
                    Console.ResetColor();
                }
            }
            else
                Console.WriteLine("Пусто");
            Console.ReadLine();
        }

    }
}
