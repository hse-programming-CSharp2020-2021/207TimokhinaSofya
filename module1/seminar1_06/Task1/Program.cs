using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Array = new int[6, 6];
            for (int i = 0; i < 6; i ++)
                for (int j = 0; j < 6; j ++)
                {
                    if (i == j) Array[i, j] = 0;
                    else if (i > j) Array[i, j] = -1;
                    else Array[i, j] = 1;
                }
        }
    }
}
