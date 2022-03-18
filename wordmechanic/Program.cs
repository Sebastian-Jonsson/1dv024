using System;

namespace WordMechanic
{
    /// <summary>
    /// Represents the main place where the program starts the execution.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the application.
        /// </summary>
        /// <param name="args">Array containing arguments passed to the application.</param>
        static void Main(string[] args)
        {
            try {
            Console.WriteLine(args);
            // Application.SourcePath = args[0];
            // Application.DestinationPath = args[1];
            Application.Run();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
