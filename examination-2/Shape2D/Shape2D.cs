using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// The Class Shape2D that inherits from Shape.
    /// </summary>
    abstract class Shape2D : Shape
    {

        /// <summary>
        /// Constructor for the class Shape2D.
        /// </summary>
        /// <param name="shapeType">Shape</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
         protected Shape2D(ShapeType shapeType, double length, double width)
         : base(shapeType)
        {
            BaseShape = shapeType;
            Length = length;
            Width = width;
        }

        /// <summary>
        /// The very base shape that is sent to Shape2D.
        /// </summary>
        private ShapeType _baseShape;

        /// <summary>
        /// The Length of the base shape that was sent to Shape2D.
        /// </summary>
        private double _length;

        /// <summary>
        /// The Width of the base shape that was sent to Shape2D.
        /// </summary>
        private double _width;

        /// <summary>
        /// Determines the Area depending on which shape is sent.
        /// </summary>
        /// <value>Area</value>
        public abstract double Area { get; }

        /// <summary>
        /// Determines the Perimeter depending on which shape is sent.
        /// </summary>
        /// <value>Perimeter</value>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Checks what the base shape that is sent along to Shape2D is.
        /// </summary>
        /// <value>_baseShape</value>
        protected ShapeType BaseShape
        { 
            get { return _baseShape; }
            set
            {
                if (value != ShapeType.Ellipse && value != ShapeType.Rectangle)
                {
                    throw new ArgumentOutOfRangeException("Has to be a valid 2D Shape such as Ellipse or Rectangle.");
                }
                _baseShape = value;
            }
        }
        
        /// <summary>
        /// Checks that the Length sent along is not below 0.
        /// </summary>
        /// <value>_length</value>
        public double Length
        { 
            get { return _length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Length value can't be smaller than 0.");
                }
                _length = value;
            }
        }

        /// <summary>
        /// Checks that the Width sent along is not below 0.
        /// </summary>
        /// <value>_width</value>
        public double Width
        { 
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width value can't be smaller than 0.");
                }
                _width = value;
            }
        }

        /// <summary>
        /// Standard formatting for the 2D shapes.
        /// </summary>
        /// <returns>G Format</returns>
        public override string ToString() => ToString("G");

        /// <summary>
        /// Formatting cases depending on which format is sent along.
        /// </summary>
        /// <param name="format">The print format</param>
        /// <returns>A string of information</returns>
        public override string ToString(string format)
        {
            switch (format)
            {
            case null:
            case "":
            case "G":
                return $"\nLängd: {Length}\nBredd: {Width}\nOmkrets: {Perimeter}\nArea: {Area}";
            case "R":
                return $"{ShapeType, 10}{Length, 10} {Width, 10} {Perimeter, 30} {Area, 30}";
            default:
                throw new FormatException();
            }
        }


    }
}