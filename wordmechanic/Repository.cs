using System.Collections.Generic;
using System.IO;

namespace WordMechanic
{
    /// <summary>
    /// Represents percitent data.
    /// </summary>
    public static class Repository
    {
        /// <summary>
        /// Reads all lines of the file into a string array.
        /// </summary>
        /// <returns>A string array containing all lines of the file.</returns>
        public static string[] All => File.ReadAllLines(Source);

        /// <summary>
        /// The file to read from.
        /// </summary>
        public static string Source { get; set; }

        /// <summary>
        /// The file to write to.
        /// </summary>
        public static string Destination { get; set; }

        /// <summary>
        /// Writes a collection of strings to a file.
        /// </summary>
        /// <param name="contents">The lines to write to the file</param>
        public static void SaveAll(IEnumerable<string> contents) =>
            File.WriteAllLines(Destination, contents);
    }
}