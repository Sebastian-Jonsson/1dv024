using System;
using System.IO;

namespace LastMessageFromTitanic
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var reader = new StreamReader("LastMessage.txt"))
                {
                    var morseCode = new MorseCode();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"--> {line}");
                        morseCode.Play(line);
                        Console.WriteLine(Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
