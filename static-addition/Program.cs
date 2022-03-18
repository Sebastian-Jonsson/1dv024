using System;
using System.IO;

namespace StaticAdding
{
    /// <summary>
    /// Represents the main place where the program starts the execution.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Which static method is called?
            int sum = MyMath.Add(123, 456);
            Console.WriteLine($"Summan är: {sum}\n");

            // Which static method is called?
            double anotherSum = MyMath.Add(9.87, 6.54);
            Console.WriteLine($"Summan är: {anotherSum}\n");

            // Which static method is called?
            Console.WriteLine("Summan är: {0}\n", MyMath.Add(123, 6.54));
        }
    }
}
