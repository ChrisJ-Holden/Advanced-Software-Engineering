using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Shapes
{
    /// <summary>
    /// Represents the base class for drawable shapes in the BOOSE graphics environment.
    /// Provides common properties for width and height and defines the abstract Draw method.
    /// </summary>
    public abstract class Shape : IDrawable
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Shape"/> class with specified dimensions.
        /// </summary>
        
        /// <param name="width">The width of the shape.</param>
        /// <param name="height">The height of the shape.</param>
        protected Shape(int width, int height)
        {
            Width = width;
            Height = height;
            Debug.WriteLine($"Shape created with Width={Width}, Height={Height}");
        }

        /// <summary>
        /// Gets the width of the shape.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the shape.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Draws the shape using the specified graphics and pen objects at the given position.
        /// </summary>
        
        /// <param name="g">The graphics object to draw on.</param>
        /// <param name="pen">The pen object used for drawing.</param>
        /// <param name="xPos">The X-coordinate of the shape's position.</param>
        /// <param name="yPos">The Y-coordinate of the shape's position.</param>
        public abstract void Draw(Graphics g, Pen pen, int xPos, int yPos);
    }
}
