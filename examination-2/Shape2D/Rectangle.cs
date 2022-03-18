/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class Rectangle that inherits from Shape2D.
    /// </summary>
    class Rectangle : Shape2D
    {
        /// <summary>
        /// Constructor for the Rectangle class.
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        public Rectangle(double length, double width)
        : base(ShapeType.Rectangle, length, width)
        {
            Length = length;
            Width = width;
    
        }

        /// <summary>
        /// Gets the Area value of the Length and Width.
        /// </summary>
        /// <value>Area</value>
        public override double Area {
            get
            { 
                return (Length * 2) * (Width * 2); 
            }
        }

        /// <summary>
        /// Gets the Perimeter value.
        /// </summary>
        /// <value>Perimeter</value>
        public override double Perimeter
        {
            get
            {
                return (Length * 2) + (Width * 2);
            } 
        }

 
    }
}