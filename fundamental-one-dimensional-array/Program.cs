using System;

namespace fundamental_one_dimensional_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 10, 23, 5, 1, 15 };

            for (int i = 0; i < values.Length; ++i)
            {
                Console.Write($"{values[i]}");
            }
            
            Console.WriteLine();

            int temp = values[1];
            temp = temp * 2;
            values[1] = temp;

            values[4] *= 2;

            foreach (int value in values)
            {
                Console.Write($"{value} ");
            }

            Console.WriteLine();
        }
    }
}
