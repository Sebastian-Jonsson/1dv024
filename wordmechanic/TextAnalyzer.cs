using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordMechanic
{
    /// <summary>
    /// Represents a text analyser.
    /// </summary>
    public static class TextAnalyzer
    {
        /// <summary>
        /// Regular expression to split a string into words.
        /// </summary>
        private static readonly Regex Rgx = new Regex(@"\W+");

        /// <summary>
        /// Returns a dictionary containing the word count.
        /// </summary>
        /// <param name="words">Specifies the words to be counted.</param>
        /// <returns></returns>
        public static IDictionary<string, int> GetWordFrequency(string[] words) =>
            words
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

        /// <summary>
        /// Extracts all the words, not containing a number, from a string.
        /// </summary>
        /// <param name="line">The string to extract words from.</param>
        /// <returns></returns>
        public static string[] ExtractWords(string line) => 
            Rgx.Split(line)
                .Where(word => !string.IsNullOrWhiteSpace(word) && !Regex.IsMatch(word, @"\d"))
                .ToArray();

        /// <summary>
        /// Extracts all the words, not containing a number, from a collection of strings.
        /// </summary>
        /// <param name="lines">Specifies the strings to extract words from.</param>
        /// <returns></returns>
        public static string[] ExtractWords(string[] lines) => 
            lines.Select(ExtractWords).SelectMany(x => x).ToArray();
    }
}