using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Shapes
{
    /// <summary>
    /// Represents a regular polygon shape with a specified number of sides and dimensions.
    /// Inherits from <see cref="Shape"/> and implements the drawing logic.
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PolygonShape"/> class.
        /// </summary>
        
        /// <param name="sides">The number of sides of the polygon.</param>
        /// <param name="width">The width of the polygon's bounding box.</param>
        /// <param name="height">The height of the polygon's bounding box.</param>
        public PolygonShape(int sides, int width, int height) : base(width, height)
        {
            Sides = sides;
            Debug.WriteLine($"PolygonShape created with {Sides} sides, Width={Width}, Height={Height}");
        }

        /// <summary>
        /// Gets the number of sides of the polygon.
        /// </summary>
        public int Sides { get; }

        /// <summary>
        /// Gets the angular step between each vertex in radians.
        /// </summary>
        private double AngleStep => 2 * Math.PI / Sides;

        /// <summary>
        /// Gets the starting angle for the first vertex in radians.
        /// </summary>
        private double AngleStart => -Math.PI / 2;

        /// <summary>
        /// Calculates the angle for a specific vertex index.
        /// </summary>
        
        /// <param name="vertexIndex">The index of the vertex (0-based).</param>
        
        /// <returns>The angle in radians for the given vertex.</returns>
        private double CalcAngle(int vertexIndex) => AngleStart + vertexIndex * AngleStep;

        /// <summary>
        /// Calculates the X-coordinate of a vertex given the center X and angle.
        /// </summary>

        /// <param name="centerX">The X-coordinate of the polygon center.</param>
        /// <param name="angle">The angle of the vertex in radians.</param>

        /// <returns>The X-coordinate of the vertex.</returns>
        private float VertexX(float centerX, double angle) => (float)(centerX + (Width / 2) * Math.Cos(angle));

        /// <summary>
        /// Calculates the Y-coordinate of a vertex given the center Y and angle.
        /// </summary>

        /// <param name="centerY">The Y-coordinate of the polygon center.</param>
        /// <param name="angle">The angle of the vertex in radians.</param>

        /// <returns>The Y-coordinate of the vertex.</returns>
        private float VertexY(float centerY, double angle) => (float)(centerY + (Height / 2) * Math.Sin(angle));

        /// <summary>
        /// Creates an array of points representing the vertices of the polygon.
        /// </summary>

        /// <param name="centerX">The X-coordinate of the polygon center.</param>
        /// <param name="centerY">The Y-coordinate of the polygon center.</param>

        /// <returns>An array of <see cref="PointF"/> representing the polygon vertices.</returns>
        public PointF[] CreatePoints(float centerX, float centerY)
        {
            PointF[] points = new PointF[Sides];

            for (int i = 0; i < Sides; i++)
            {
                double angle = CalcAngle(i);
                float x = VertexX(centerX, angle);
                float y = VertexY(centerY, angle);
                points[i] = new PointF(x, y);
            }

            Debug.WriteLine($"PolygonShape points created at center X={centerX}, Y={centerY}");
            return points;
        }

        /// <summary>
        /// Draws the polygon on the specified graphics object using the provided pen object.
        /// </summary>
        
        /// <param name="g">The graphics object to draw on.</param>
        /// <param name="pen">The pen object used for drawing the polygon.</param>
        /// <param name="xPos">The X-coordinate of the polygon center.</param>
        /// <param name="yPos">The Y-coordinate of the polygon center.</param>
        public override void Draw(Graphics g, Pen pen, int xPos, int yPos)
        {
            PointF[] points = CreatePoints(xPos, yPos);
            g.DrawPolygon(pen, points);
            Debug.WriteLine($"PolygonShape drawn at X={xPos}, Y={yPos} with {Sides} sides");
        }
    }
}
