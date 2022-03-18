using System;

/// <summary>
///  The namespace for the entirety of the examination.
/// </summary>
namespace Shape
{
    /// <summary>
    /// Class Sphere that inherits from Shape3D.
    /// </summary>
    class Sphere : Shape3D
    {
        /// <summary>
        /// Constructor of the Sphere class.
        /// </summary>
        /// <param name="diameter">Diameter</param>
        public Sphere(double diameter)
        : base(ShapeType.Sphere, new Ellipse(diameter, diameter), diameter)
        {
            Diameter = diameter;
        }

        /// <summary>
        /// The Diameter of the Sphere, inherited from Shape3D.
        /// </summary>
        private double _diameter;

        /// <summary>
        /// Checks that the Diameter is not lower than 0.
        /// </summary>
        /// <value></value>
        public double Diameter
        { 
            get { return _diameter; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Diameter value can't be smaller than 0.");
                }
                _diameter = value;
            }
        }

        /// <summary>
        /// Method that overrides the standard MantelArea of Shape3D.
        /// </summary>
        /// <value>MantelArea</value>
        public override double MantelArea {
            get
            { 
                return _baseShape.Area * 4; 
            }
        }

        /// <summary>
        /// Method that overrides the standard TotalSurfaceArea of Shape3D.
        /// </summary>
        /// <value>TotalSurfaceArea</value>
        public override double TotalSurfaceArea {
            get
            { 
                return MantelArea; 
            }
        }

        /// <summary>
        /// Method that overrides the standard Volume of Shape3D.
        /// </summary>
        /// <value></value>
        public override double Volume {
            get
            { 
                double r = Diameter / 2;
                return 4/3 * _baseShape.Area * r; 
            }
        }
    }
}