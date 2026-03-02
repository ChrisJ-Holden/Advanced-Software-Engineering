using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Shapes
{
    /// <summary>
    /// Represents a rectangle shape with specified width and height.
    /// Inherits from <see cref="Shape"/> and implements the drawing logic.
    /// </summary>
    public class RectangleShape : Shape
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RectangleShape"/> class with the specified dimensions.
        /// </summary>
        
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public RectangleShape(int width, int height) : base(width, height)
        {
            Debug.WriteLine($"RectangleShape created with Width={Width}, Height={Height}");
        }

        /// <summary>
        /// Draws the rectangle on the specified graphics object using the provided pen object.
        /// </summary>
        
        /// <param name="g">The graphics object to draw on.</param>
        /// <param name="pen">The pen object used for drawing the rectangle.</param>
        /// <param name="xPos">The X-coordinate of the rectangle's top-left corner.</param>
        /// <param name="yPos">The Y-coordinate of the rectangle's top-left corner.</param>
        public override void Draw(Graphics g, Pen pen, int xPos, int yPos)
        {
            g.DrawRectangle(pen, xPos, yPos, Width, Height);
            Debug.WriteLine($"RectangleShape drawn at X={xPos}, Y={yPos} with Width={Width}, Height={Height}");
        }
    }
}
