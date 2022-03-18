using System;

namespace repeatable_quotes
{
    /// <summary>
    /// Represents the main place where the program starts the execution.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the application.
        /// </summary>
        static void Main()
        {
            // Create a new QuoteViewer object using the default
            // constructor, assign the object values using properties and
            // call a method.
            QuoteViewer qw = new QuoteViewer(); // Connected to the one without any params in the QuoteViewer, quotes are built here instead
            qw.Quote = "I have a dream.";
            qw.Count = 7;
            qw.View();

            // Create and initiate another QuoteViewer object using
            // constructor having two parameters and calls a method.
            QuoteViewer anotherQw =
                new QuoteViewer("Make love, not war.", 3); // Must have two arguments, connected to the one in QuoteViewer with two params
            anotherQw.View();

            // Change the object data using a property and call a method.
            anotherQw.Quote = "Et tu, Brute"; // Linked to the one with two params but is overwritten by the latest Quote param
            anotherQw.View();
        }
    }
}
