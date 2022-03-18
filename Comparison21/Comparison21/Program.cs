using System;

namespace Tjugoett
{
    class Program
    {

        /// <summary>
        /// The entry of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameOn(10);
        }
    }
}
