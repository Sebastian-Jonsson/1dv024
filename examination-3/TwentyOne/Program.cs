using System;
using System.Text;


namespace TwentyOne
{
    /// <summary>
    /// Class which is the program to start the game 21.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Fixes the output encoding for some symbols and initializes the entirety as a whole.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Table.GameStart();
        }
    }
}
