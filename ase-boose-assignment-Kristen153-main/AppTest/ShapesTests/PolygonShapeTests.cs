using System.Drawing;
using BOOSEGraphicsEnvironment.Shapes;

namespace AppTest.ShapesTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="PolygonShape"/> class.
    /// </summary>
    [TestClass]
    public sealed class PolygonShapeTests
    {
        /// <summary>
        /// Verifies that the constructor correctly sets the number of sides, width, and height.
        /// </summary>
        [TestMethod]
        public void Constructor_SetSidesAndDimensions()
        {
            int sides = 6;
            int width = 10;
            int height = 20;
            PolygonShape poly = new(sides, width, height);

            Assert.AreEqual(sides, poly.Sides);
            Assert.AreEqual(width, poly.Width);
            Assert.AreEqual(height, poly.Height);
        }

        /// <summary>
        /// Ensures that <see cref="PolygonShape.CreatePoints(float, float)"/> returns the correct number of points
        /// and that each point is within the expected bounds.
        /// </summary>
        [TestMethod]
        public void CreatePoints_ReturnsCorrectNumberOfPoints()
        {
            int sides = 5;
            int width = 20;
            int height = 40;
            float centerX = 50;
            float centerY = 50;

            PolygonShape polygon = new(sides, width, height);
            PointF[] points = polygon.CreatePoints(centerX, centerY);

            Assert.AreEqual(sides, points.Length);

            foreach (PointF p in points)
            {
                Assert.IsTrue(p.X >= centerX - width / 2 && p.X <= centerX + width / 2, "Point X is out of bounds");
                Assert.IsTrue(p.Y >= centerY - height / 2 && p.Y <= centerY + height / 2, "Point Y is out of bounds");
            }
        }

        /// <summary>
        /// Ensures that the <see cref="PolygonShape.Draw(Graphics, Pen, int, int)"/> method executes without throwing an exception.
        /// </summary>
        [TestMethod]
        public void Draw_ExecutesWithoutException()
        {
            int sides = 3;
            int width = 20;
            int height = 20;
            PolygonShape poly = new(sides, width, height);

            using Bitmap b = new(100, 100);
            using Graphics g = Graphics.FromImage(b);
            using Pen p = new(Color.Black);

            poly.Draw(g, p, 10, 10);
        }
    }
}
