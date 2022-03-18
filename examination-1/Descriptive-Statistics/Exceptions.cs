using System;

/// <summary>
///  The gathering point for the application.
/// </summary>
namespace Descriptive_Statistics
{
    /// <summary>
    /// The class that handles exceptions.
    /// </summary>
public class Exception_Manager
        {
            /// <summary>
            ///  Method that handles the exceptions if the data source is null or empty.
            /// </summary>
            /// <param name="source">Source of data to be checked.</param>
            public static void Exceptions(int[] source)
            {                   
                if (source == null)
                {
                    throw new ArgumentNullException();
                }

                if (source.Length == 0)
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }     
            }
        }

}