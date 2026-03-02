using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Shapes
{
    /// <summary>
    /// Represents an ellipse shape with a specified radius.
    /// Inherits from <see cref="Shape"/> and implements the Draw nethod.
    /// </summary>
    public class EllipseShape : Shape
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EllipseShape"/> class with the specified radius.
        /// </summary>
        
        /// <param name="radius">The radius of the ellipse.</param>
        public EllipseShape(int radius) : base(radius * 2, radius * 2)
        {
            Radius = radius;
            Debug.WriteLine($"EllipseShape created with radius {Radius}");
        }

        /// <summary>
        /// Gets the radius of the ellipse.
        /// </summary>
        public int Radius { get; }

        /// <summary>
        /// Draws the ellipse on the specified graphics object at the given position using the provided pen object.
        /// </summary>
        
        /// <param name="g">The graphics object to draw on.</param>
        /// <param name="pen">The pen object used for drawing the ellipse.</param>
        /// <param name="xPos">The X-coordinate of the ellipse's top-left corner.</param>
        /// <param name="yPos">The Y-coordinate of the ellipse's top-left corner.</param>
        public override void Draw(Graphics g, Pen pen, int xPos, int yPos)
        {
            g.DrawEllipse(pen, xPos, yPos, Width, Height);
            Debug.WriteLine($"Ellipse drawn at X={xPos}, Y={yPos} with Width={Width}, Height={Height}");
        }
    }
}
