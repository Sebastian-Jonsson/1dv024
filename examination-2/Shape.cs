using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class Shape that checks the Shape being sent along the hierarchy.
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// Constructor of the class Shape.
        /// </summary>
        /// <param name="shapeType"></param>
        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }

        /// <summary>
        /// Determines if the Shape sent along is 3D.
        /// </summary>
        /// <value>3D Shape</value>
        public bool Is3D {
            get
            {
                return ShapeType == ShapeType.Cuboid || ShapeType == ShapeType.Cylinder || ShapeType == ShapeType.Sphere;
            }   
        }

        /// <summary>
        /// The ShapeType.
        /// </summary>
        /// <value>ShapeType</value>
        public ShapeType ShapeType { get; private set; }

        /// <summary>
        /// Method that formats the output depending on input.
        /// </summary>
        /// <param name="format">Format</param>
        /// <returns></returns>
        public abstract string ToString(string format);
    }
}
