using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    ///  Class Ellipse that inherits from Shape2D.
    /// </summary>
    class Ellipse : Shape2D
    {
        /// <summary>
        /// Constructor for Ellipse class.
        /// </summary>
        /// <param name="hdiameter">Horizontal Diameter</param>
        /// <param name="vdiameter">Vertical Diameter</param>
        public Ellipse(double hdiameter, double vdiameter)
        : base(ShapeType.Ellipse, hdiameter, vdiameter) 
        {
            Length = hdiameter;
            Width = vdiameter;

        }

        /// <summary>
        /// Gets the Area value of the Length and Width.
        /// </summary>
        /// <value>Area</value>
        public override double Area {
            get
            { 
                return Math.PI * (Length / 2) * (Width / 2); 
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
                double l = Length / 2;
                double w = Width / 2;
                var perimeter = Math.PI * (3 * (l + w) - Math.Sqrt((3 * l + w) * (l + 3 * w)));
                return perimeter;
            } 
        }

 
    }
}