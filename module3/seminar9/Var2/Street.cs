using System;
using System.Linq;

namespace Var2
{
    // Не использовала библиотеку классов.
    public class Street
    {
        public string Name { get; private set; }
        public int[] Houses { get; set; }

        public Street(string name, int[] houses)
        {
            Name = name;
            Houses = houses;
        }

        public static int operator ~(Street street) => street.Houses.Length;

        public static bool operator !(Street street) =>  street.Houses.Contains(7);
        public override string ToString()
        {
            return $"{Name}; Houses: {string.Join(", ", Houses)}";
        }
    }
}