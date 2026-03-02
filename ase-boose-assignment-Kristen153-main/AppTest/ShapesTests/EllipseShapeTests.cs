using System.Drawing;
using BOOSEGraphicsEnvironment.Shapes;

namespace AppTest.ShapesTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="EllipseShape"/> class.
    /// </summary>
    [TestClass]
    public sealed class EllipseShapeTests
    {
        /// <summary>
        /// Verifies that the constructor correctly sets the radius and calculates width and height.
        /// </summary>
        [TestMethod]
        public void Constructor_SetRadiusAndDimensions()
        {
            int radius = 10;
            EllipseShape ellip = new(radius);

            Assert.AreEqual(radius, ellip.Radius);
            Assert.AreEqual(radius * 2, ellip.Width);
            Assert.AreEqual(radius * 2, ellip.Height);
        }

        /// <summary>
        /// Ensures that the <see cref="EllipseShape.Draw(Graphics, Pen, int, int)"/> method executes without throwing an exception.
        /// </summary>
        [TestMethod]
        public void Draw_ExecutesWithoutException()
        {
            int radius = 10;
            EllipseShape ellip = new(radius);

            using Bitmap b = new(100, 100);
            using Graphics g = Graphics.FromImage(b);
            using Pen p = new(Color.Black);

            ellip.Draw(g, p, 10, 10);
        }
    }
}
