using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordMechanic.Dictionary
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
        public static IDictionary<string, int> GetWordFrequency(string[] words)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary[word] = 1;
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Extracts all the words, not containing a number, from a string.
        /// </summary>
        /// <param name="line">The string to extract words from.</param>
        /// <returns></returns>
        public static string[] ExtractWords(string line)
        {
            var words = new List<string>();

            foreach (var word in Rgx.Split(line))
            {
                if (!string.IsNullOrWhiteSpace(word)
                    && !Regex.IsMatch(word, @"\d"))
                {
                    words.Add(word);
                }                
            }

            return words.ToArray();
        }

        /// <summary>
        /// Extracts all the words, not containing a number, from a collection of strings.
        /// </summary>
        /// <param name="lines">Specifies the strings to extract words from.</param>
        /// <returns></returns>
        public static string[] ExtractWords(string[] lines)
        {
            var words = new List<string>();

            foreach (var line in lines)
            {
                words.AddRange(ExtractWords(line));
            }

            return words.ToArray();
        }
    }
}