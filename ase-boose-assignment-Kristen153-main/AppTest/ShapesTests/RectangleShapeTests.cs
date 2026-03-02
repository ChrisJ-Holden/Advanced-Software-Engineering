using System.Drawing;
using BOOSEGraphicsEnvironment.Shapes;

namespace AppTest.ShapesTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="RectangleShape"/> class.
    /// </summary>
    [TestClass]
    public sealed class RectangleShapeTests
    {
        /// <summary>
        /// Verifies that the constructor correctly sets the width and height of the rectangle.
        /// </summary>
        [TestMethod]
        public void Constructor_SetDimensions()
        {
            int width = 10;
            int height = 20;
            RectangleShape rect = new(width, height);

            Assert.AreEqual(width, rect.Width);
            Assert.AreEqual(height, rect.Height);
        }

        /// <summary>
        /// Ensures that the <see cref="RectangleShape.Draw(Graphics, Pen, int, int)"/> method executes without throwing an exception.
        /// </summary>
        [TestMethod]
        public void Draw_ExecutesWithoutException()
        {
            int width = 30;
            int height = 30;
            RectangleShape rect = new(width, height);

            using Bitmap b = new(100, 100);
            using Graphics g = Graphics.FromImage(b);
            using Pen p = new(Color.Black);

            rect.Draw(g, p, 10, 10);
        }
    }
}
