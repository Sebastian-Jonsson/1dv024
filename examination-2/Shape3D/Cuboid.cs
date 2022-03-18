using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class Cuboid that inherits from Shape3D.
    /// </summary>
    class Cuboid : Shape3D
    {
        /// <summary>
        /// Constructor of the class Cuboid.
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Cuboid(double length, double width, double height)
        : base(ShapeType.Cuboid, new Rectangle(length, width), height)
        {
            
        }
    }
}