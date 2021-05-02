using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            State state1 = new State();
            State state2 = new State();
            State state3 = state1 + state2;
            bool isGreater = state1 > state2;
        }
    }

    class State
    {
        public decimal Population { get; set; }// население
        public decimal Area { get; set; }      // территория

        public static State operator +(State one, State two)
        {
            return new State() { Population = one.Population + two.Population,
                Area = one.Area + two.Area };
        }

        public static bool operator > (State one, State two)
        {
            return one.Area == two.Area ? one.Population > two.Population : one.Area > two.Area;
        }

        public static bool operator < (State one, State two)
        {
            return one.Area == two.Area ? one.Population <= two.Population : one.Area < two.Area;
        }
    }
}
