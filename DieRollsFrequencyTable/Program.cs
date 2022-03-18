using System;

namespace DieRollsFrequencyTable
{
    /// <summary>
  /// Applikationen simulerar tärningskast och presenterar utfallet i
  /// form av en frekvenstabell.
  /// </summary>
  class Program
  {
     /// <summary>
    /// Startpunkt för applikationen.
    /// </summary>
    /// <param name="args">Argument som kan skickas till applikationen (används inte).</param>
        static void Main(string[] args)
    {
        //Local variables.
      int count;
      int[] frequencyTable;

        // Reads the amount of die toss which will be simulated, as a
        // frequency table will of die toss is created and presented.
      count = ReadNumberOfRolls();

      frequencyTable = CreateDieRollsFrequencyTable(count);

      ViewFrequencyTable(frequencyTable);
    }

/// <summary>
    /// Simulerar tärningskast, skapar och returnerar frekvenstabell över utfallet.
    /// </summary>
    /// <param name="count">Antal tärningskast att simulera.</param>
    /// <returns>Array innehållande frekvenstabell över simulerade tärningskast.</returns>
    private static int[] CreateDieRollsFrequencyTable(int count)
    {
      int[] frequencyTable = new int[6];
      Random die = new Random();

      for (int i = 0; i < count; i++)
      {
        frequencyTable[die.Next(6)]++;
      }

      return frequencyTable;
    }

    private static int ReadNumberOfRolls()
    {
        int count;

        while(true)
        {
            try{
                Console.Write("Ange antal tärningskast [100-1000]: ");
                count = int.Parse(Console.ReadLine());
                
                if (!(count >= 100 && count <= 1000))
                {
                    throw new ApplicationException();
                }

                return count;
            }
        
        catch (Exception)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nFEL! Ange ett heltal mellan 100 och 1000.\n");
            Console.ResetColor();
        }
        }
    }

    private static void ViewFrequencyTable(int[] frequencyTable)
    {
      string[] faces = { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor" };

      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\n----------------");
      Console.WriteLine(" Frekvenstabell ");
      Console.WriteLine("----------------");
      Console.ResetColor();

      for (int i = 0; i < faces.Length; i++)
      {
        Console.WriteLine($" {faces[i],-7} | {frequencyTable[i],4}");
        Console.WriteLine("----------------");
      }
    }
  }
}