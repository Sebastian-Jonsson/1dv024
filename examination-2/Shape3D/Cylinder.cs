using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class Cylinder that inherits from Shape3D.
    /// </summary>
    class Cylinder : Shape3D
    {
        /// <summary>
        /// Constructor of the Cylinder class.
        /// </summary>
        /// <param name="hdiameter">Horizontal Diameter</param>
        /// <param name="vdiameter">Vertical Diameter</param>
        /// <param name="height">Height</param>
        public Cylinder(double hdiameter, double vdiameter, double height)
        : base(ShapeType.Cylinder, new Ellipse(hdiameter, vdiameter), height)
        {
            
        }
    }
}