using System;
using System.Linq;

namespace WordMechanic
{
    /// <summary>
    /// Represents a console application.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// The file to write to.
        /// </summary>
        public static string DestinationPath = "WordFile.txt";
        // { get; set; }

        /// <summary>
        /// The file to read from.
        /// </summary>
        public static string SourcePath = "Regeringsformen, 1 kap och 2 kap.txt";
        // { get; set; }

        /// <summary>
        /// Runs an application.
        /// </summary>
        public static void Run()
        {
            try
            {
                Repository.Source = SourcePath;
                Repository.Destination = DestinationPath;

                Console.WriteLine($"Reads the text file '{SourcePath}'.");
                var lines = Repository.All;

                Console.WriteLine("Analyzes the content.");

                var words = TextAnalyzer.ExtractWords(lines).ToArray();
                Console.WriteLine($"Found {words.Count()} words.");

                var frequencyOrdered = TextAnalyzer.GetWordFrequency(words)
                    .OrderByDescending(kvp => kvp.Value);
                Console.WriteLine($"Found {frequencyOrdered.Count()} unique words.");

                var fifthWordCount = frequencyOrdered.Take(5).Last().Value;
                var mostFrequent = frequencyOrdered
                    .TakeWhile(x => x.Value >= fifthWordCount)
                    .Select(x => x.Key);
                var output = $"The most frequent words are '{string.Join("', '", mostFrequent)}'.";
                var index = output.LastIndexOf(", ", StringComparison.Ordinal);
                output = output.Remove(index, 2).Insert(index, " and ");
                Console.WriteLine(output);

                Console.WriteLine($"Writes the word occurence count to the text file '{DestinationPath}'.");
                var alphabeticallyOrdered = frequencyOrdered
                    .OrderBy(kvp => kvp.Key)
                    .Select(x => x.ToString());
                Repository.SaveAll(alphabeticallyOrdered);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}