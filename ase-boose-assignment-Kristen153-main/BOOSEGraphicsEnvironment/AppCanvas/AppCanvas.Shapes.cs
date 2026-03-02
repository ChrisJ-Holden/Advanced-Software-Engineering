using BOOSEGraphicsEnvironment.Shapes;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    public partial class AppCanvas
    {
        /// <summary>
        /// Draws a line from the current cursor position to the specified coordinates.
        /// </summary>

        /// <param name="x">The X-coordinate of the line endpoint.</param>
        /// <param name="y">The Y-coordinate of the line endpoint.</param>
        public void DrawTo(int x, int y)
        {
            CanvasGraphics.DrawLine(_pen, Xpos, Ypos, x, y);
            Debug.WriteLine($"Drew line from X={Xpos}, Y={Ypos} to X={x}, Y={y}");
            Xpos = x;
            Ypos = y;
        }

        /// <summary>
        /// Draws a circle at the current cursor position with the specified radius.
        /// </summary>

        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Whether the circle should be filled (currently not used).</param>
        public void Circle(int radius, bool filled)
        {
            Shape circle = new EllipseShape(radius);
            circle.Draw(CanvasGraphics, _pen, Xpos, Ypos);
        }

        /// <summary>
        /// Draws a rectangle at the current cursor position with the specified dimensions.
        /// </summary>

        /// <param name="width">The rectangle width.</param>
        /// <param name="height">The rectangle height.</param>
        /// <param name="filled">Whether the rectangle should be filled (currently not used).</param>
        public void Rect(int width, int height, bool filled)
        {
            Shape rect = new RectangleShape(width, height);
            rect.Draw(CanvasGraphics, _pen, Xpos, Ypos);
        }

        /// <summary>
        /// Draws a triangle at the current cursor position with the specified dimensions.
        /// </summary>

        /// <param name="width">The triangle width.</param>
        /// <param name="height">The triangle height.</param>
        public void Tri(int width, int height)
        {
            Shape tri = new PolygonShape(3, width, height);
            tri.Draw(CanvasGraphics, _pen, Xpos, Ypos);
        }

    }
}
