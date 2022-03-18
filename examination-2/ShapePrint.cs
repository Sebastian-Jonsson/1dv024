using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class that manages sorting and printing of information from the shapes.
    /// </summary>
    class ShapePrint
    {
        /// <summary>
        /// Sets the DecidedShape.
        /// </summary>
        public static int DecidedShape;

        /// <summary>
        /// Sets the Amount of Shapes to be printed.
        /// </summary>
        public static int AmountOfShapes = 5;

        /// <summary>
        /// A List for 2D Shapes.
        /// </summary>
        /// <typeparam name="Shape2D">Shape2D</typeparam>
        /// <returns>A List</returns>
        public static List<Shape2D> Shape2DContainer = new List<Shape2D>();

        /// <summary>
        /// A List of 3D Shapes.
        /// </summary>
        /// <typeparam name="Shape3D">Shape3D</typeparam>
        /// <returns>A List</returns>
        public static List<Shape3D> Shape3DContainer = new List<Shape3D>();
       
        /// <summary>
        /// The Minimum measurement for any surface.
        /// </summary>
        public static int MinMeasurement = 1;

        /// <summary>
        /// The Maximum measurement for any surface.
        /// </summary>
        public static int MaxMeasurement = 100;

        /// <summary>
        /// Sets the formatting type.
        /// </summary>
        public static string Format = "R";

        /// <summary>
        /// Presents the menu and calls the supporting methods to determine the shapes.
        /// </summary>
        public static void ShapeMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an alternative:");
            Console.WriteLine("1: 2D Shape");
            Console.WriteLine("2: 3D Shape");
            Console.WriteLine("3: Exit");

            MenuInterpreter();
            PrintSorter();
        }

        /// <summary>
        /// Interprets the menu choices and sends the request to give an x Amount of Random Shapes based on the menu choice.
        /// </summary>
        public static void MenuInterpreter()
        {            
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 1; i <= AmountOfShapes; i++)
                    {
                    DecidedShape = (int)(ShapeType)new Random().Next(0, 2);
                    ShapeInterpretation(DecidedShape);
                    }
                    break;
                case "2":
                for (int i = 1; i <= AmountOfShapes; i++)
                    {
                    DecidedShape = (int)(ShapeType)new Random().Next(2, 5);
                    ShapeInterpretation(DecidedShape);
                    }
                    break;
                    
                case "3":
                    break;

                default:
                    // ShapeMenu();
                    // break;
                    throw new InvalidOperationException("Choose a valid command.");
            }
        }

        /// <summary>
        /// Method that creates the random shapes, depending on which shape becomes the randomized one.
        /// </summary>
        /// <param name="shapeCase">shapeNumber</param>
        public static void ShapeInterpretation(int shapeCase)
        {
            

            switch (shapeCase)
            {
                case 0:
                        Shape2D rectangle = new Rectangle(MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement));
                        Shape2DContainer.Add(rectangle); 
                    break;
                
                case 1:
                        Shape2D ellipse = new Ellipse(MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement));
                        Shape2DContainer.Add(ellipse);
                    break;
                
                case 2:
                        Shape3D cuboid = new Cuboid(MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement));
                        Shape3DContainer.Add(cuboid);
                    break;
                
                case 3:
                        Shape3D cylinder = new Cylinder(MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement), MeasurementsRandomizer(MinMeasurement, MaxMeasurement));
                        Shape3DContainer.Add(cylinder);
                    break;

                case 4:
                        Shape3D sphere = new Sphere(MeasurementsRandomizer(MinMeasurement, MaxMeasurement));
                        Shape3DContainer.Add(sphere);
                    break;                

                default:
                    break;
            }
        }

        /// <summary>
        /// Method that checks which Container has contents, sorts them accordingly to Type of Shape
        /// and Area(Or Volume if it is a 3D shape) and prints the appropriate amount.
        /// </summary>
        public static void PrintSorter()
        {
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.BackgroundColor = ConsoleColor.White;

            // This part determines the 2D part.
            if (Shape2DContainer.Count > 0) 
            {
                Console.WriteLine($"{"2D Shape", 10}{"Length", 10} {"Width", 10} {"Perimeter", 30} {"Area", 30}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue; 
                for (int i = 0; i < Shape2DContainer.Count; i++)
                    {
                        List<Shape2D> SortedList = Shape2DContainer
                                                    .OrderByDescending(o => o.ShapeType)
                                                    .ThenBy(i => i.Area)
                                                    .ToList();
                        Console.WriteLine(SortedList[i].ToString(Format));
                    }
            }

            // This part determines the 3D part.
            if (Shape3DContainer.Count > 0)
            {
                Console.WriteLine($"{"3D Shape", 10}{"Length", 20} {"Width", 10} {"Height", 10} {"MantelArea", 25} {"TotalSurfaceArea", 25} {"Volume", 25}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue; 
                for (int i = 0; i < Shape3DContainer.Count; i++)
                    {
                        List<Shape3D> SortedList = Shape3DContainer
                                                    .OrderByDescending(o => o.ShapeType)
                                                    .ThenBy(i => i.Volume)
                                                    .ToList();
                        Console.WriteLine(SortedList[i].ToString(Format)); // Lägg till radavstånd inne i tostring metoderna och gör en förklaringsrad ovan här
                    }
            }
        }

        /// <summary>
        /// Method that brings random measurements, based on the minimum and maximum measures allowed.
        /// </summary>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// <returns></returns>
        public static int MeasurementsRandomizer(int min, int max)
        {
            Random rnd = new Random(); 
            
            return rnd.Next(min, max);
        }
    }
}