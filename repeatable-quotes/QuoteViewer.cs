using System;

namespace repeatable_quotes
{
    public class QuoteViewer
    {
        // Fields
        private int _count;

        // Constructors
        public QuoteViewer() // Empty constructor required for specific caller in Program
        {
            // Empty!
        }

        public QuoteViewer(string quote, int count) // Two param constructor required for specific caller in Program
        {
            Quote = quote;
            Count = count;
        }

        // Properties // Count type is set here and sent along
        public int Count 
        {
            get { return _count; }
            set { _count = value; }
        }

        public string Quote { get; set; } // Quote type is set here and sent along properly

        // Methods // Simple for loop and what to write in between and how many times the Count which is _count, Quote what to write is sent from Program
        public void View()
        {
            Console.WriteLine("~~~~~");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(Quote);
            }
            Console.WriteLine("~~~~~");
        }
    }
}