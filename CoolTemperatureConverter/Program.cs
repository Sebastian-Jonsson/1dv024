using System;

namespace CoolTemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius;
            double fahrenheit;

            Console.Write("Write the temperature in Fahrenheit: ");

            fahrenheit = double.Parse(Console.ReadLine());
            celsius = (fahrenheit - 32) * 5 / 9;

            Console.WriteLine($"Temperature {fahrenheit} °F is {celsius:f2} °C.");
        }
    }
}
