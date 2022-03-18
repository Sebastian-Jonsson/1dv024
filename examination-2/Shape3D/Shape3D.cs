using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// The Class Shape3D that inherits from Shape.
    /// </summary>
    abstract class Shape3D : Shape
    {
        /// <summary>
        /// Constructor for the class Shape3D.
        /// </summary>
        /// <param name="shapeType">Shape</param>
        /// <param name="baseShape">Base Shape</param>
        /// <param name="height">Height</param>
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height)
        : base(shapeType)
        {
            Height = height;
            _baseShape = baseShape;
        }

        /// <summary>
        /// The inherited base shape for the 3D Shape.
        /// </summary>
        protected Shape2D _baseShape;

        /// <summary>
        /// The Length of the Base Shape which Shape3D will use.
        /// </summary>
        /// <value>Length</value>
        public double Length { get; set; }

        /// <summary>
        /// The Width of the Base Shape which Shape3D will use.
        /// </summary>
        /// <value>Width</value>
        public double Width { get; set; }

        /// <summary>
        /// The Height which is sent to Shape3D.
        /// </summary>
        private double _height;

        /// <summary>
        /// Checks that the Height sent to Shape3D is more than 0.
        /// </summary>
        /// <value></value>
        public double Height
        { 
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height value can't be smaller than 0.");
                }
                _height = value;
            }
        }

        /// <summary>
        /// Determines the MantelArea of the 3D Shape.
        /// </summary>
        /// <value>MantelArea</value>
        public virtual double MantelArea
        {
            get
            {
                return _baseShape.Perimeter * Height;
            }
        }

        /// <summary>
        /// Determines the TotalSurfaceArea of the 3D Shape.
        /// </summary>
        /// <value>TotalSurfaceArea</value>
        public virtual double TotalSurfaceArea
        {
            get
            {
                return _baseShape.Area * 6;
            }
        }

        /// <summary>
        /// Determines the Volume of the 3D Shape.
        /// </summary>
        /// <value></value>
        public virtual double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }

        /// <summary>
        /// Standard formatting for the 3D shapes.
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
                return $"\nLängd: {_baseShape.Length}\nBredd: {_baseShape.Width}\nHöjd: {Height}\nMantelarea: {MantelArea}\nBegränsningsarea: {TotalSurfaceArea}\nVolym: {Volume}";
            case "R":
                return $"{ShapeType, 10}{_baseShape.Length, 20} {_baseShape.Width, 10} {Height, 10} {MantelArea, 25} {TotalSurfaceArea, 25} {Volume, 25}";
            default:
                throw new FormatException();
            }
        }
    }
}