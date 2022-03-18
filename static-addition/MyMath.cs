using System;

namespace StaticAdding
{
    static class MyMath
    {
        /// <summary>
        ///  Addition with Integers.
        /// </summary>
        /// <param name="op1">First Integer.</param>
        /// <param name="op2">Second Integer.</param>
        /// <returns></returns>
        public static int Add(int op1, int op2)
        {
            #if DEBUG
                Console.WriteLine("Method with Integers have been called.");
            #endif
            return op1 + op2;
        }
        /// <summary>
        ///  Addition with Doubles.
        /// </summary>
        /// <param name="op1">First Double.</param>
        /// <param name="op2">Second Double.</param>
        /// <returns></returns>
        public static double Add(double op1, double op2)
        {
            #if DEBUG
                Console.WriteLine("Method with Double have been called.");
            #endif
            return op1 + op2;
        }
    }
}