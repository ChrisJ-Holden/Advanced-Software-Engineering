namespace BOOSEGraphicsEnvironment
{
    /// <summary>
    /// Represents an object that can be drawn on a canvas.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws the object using the specified graphics context, pen, and position.
        /// </summary>
        
        /// <param name="g">The graphics context to draw on.</param>
        /// <param name="pen">The pen used for drawing.</param>
        /// <param name="xPos">The X-coordinate where the object should be drawn.</param>
        /// <param name="yPos">The Y-coordinate where the object should be drawn.</param>
        void Draw(Graphics g, Pen pen, int xPos, int yPos);
    }
}
