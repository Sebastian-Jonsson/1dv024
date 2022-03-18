using System;

namespace ProductOfWholeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            long product = 1;

            for ( int i = 1; i <= 20; i++)
            {
                product *= i;
            }

            Console.WriteLine($"Product of all integers between 1 and 20 is {product}.");
        }
    }
}
