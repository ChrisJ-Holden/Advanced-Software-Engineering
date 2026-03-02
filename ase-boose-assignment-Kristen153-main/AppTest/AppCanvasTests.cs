using System.Drawing;
using BOOSEGraphicsEnvironment;

namespace AppTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="AppCanvas"/> class.
    /// </summary>
    [TestClass]
    public sealed class AppCanvasTests
    {
        private const int InitialWidth = 20;
        private const int InitialHeight = 10;
        private const int ResizedWidth = 30;
        private const int ResizedHeight = 40;

        private const int ColourR = 7;
        private const int ColourG = 11;
        private const int ColourB = 13;

        private const int StartX = 1;
        private const int StartY = 2;
        private const int EndX = 9;
        private const int EndY = 12;

        private const int Radius = 6;
        private const int RectWidth = 8;
        private const int RectHeight = 5;
        private const int TriWidth = 14;
        private const int TriHeight = 9;

        /// <summary>
        /// Verifies that the constructor initializes the bitmap and default positions.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesBitmapAndDefaultPosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);

            var bitmap = canvas.getBitmap() as Bitmap;
            Assert.IsNotNull(bitmap);
            Assert.AreEqual(InitialWidth, bitmap.Width);
            Assert.AreEqual(InitialHeight, bitmap.Height);

            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.Set(int, int)"/> resizes the bitmap correctly.
        /// </summary>
        [TestMethod]
        public void Set_ResizesBitmap()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.Set(ResizedWidth, ResizedHeight);

            Bitmap bitmap = canvas.getBitmap() as Bitmap;
            Assert.IsNotNull(bitmap);
            Assert.AreEqual(ResizedWidth, bitmap.Width);
            Assert.AreEqual(ResizedHeight, bitmap.Height);
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.SetColour(int, int, int)"/> updates the pen colour property.
        /// </summary>
        [TestMethod]
        public void SetColour_UpdatesPenColourProperty()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.SetColour(ColourR, ColourG, ColourB);

            Color penColour = (Color)canvas.PenColour;
            Assert.AreEqual(ColourR, penColour.R);
            Assert.AreEqual(ColourG, penColour.G);
            Assert.AreEqual(ColourB, penColour.B);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.MoveTo(int, int)"/> updates the position correctly.
        /// </summary>
        [TestMethod]
        public void MoveTo_UpdatesPosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(StartX, StartY);

            Assert.AreEqual(StartX, canvas.Xpos);
            Assert.AreEqual(StartY, canvas.Ypos);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.DrawTo(int, int)"/> updates the position correctly.
        /// </summary>
        [TestMethod]
        public void DrawTo_UpdatesPosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(StartX, StartY);
            canvas.DrawTo(EndX, EndY);

            Assert.AreEqual(EndX, canvas.Xpos);
            Assert.AreEqual(EndY, canvas.Ypos);
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.Reset"/> sets the position to default (0,0).
        /// </summary>
        [TestMethod]
        public void Reset_SetsPositionToDefaults()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(5, 6);
            canvas.Reset();

            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.Circle(int, bool)"/> does not change the current position.
        /// </summary>
        [TestMethod]
        public void Circle_DoesNotChangePosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(StartX, StartY);
            canvas.Circle(Radius, false);

            Assert.AreEqual(StartX, canvas.Xpos);
            Assert.AreEqual(StartY, canvas.Ypos);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.Rect(int, int, bool)"/> does not change the current position.
        /// </summary>
        [TestMethod]
        public void Rect_DoesNotChangePosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(StartX, StartY);
            canvas.Rect(RectWidth, RectHeight, false);

            Assert.AreEqual(StartX, canvas.Xpos);
            Assert.AreEqual(StartY, canvas.Ypos);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.Tri(int, int)"/> does not change the current position.
        /// </summary>
        [TestMethod]
        public void Tri_DoesNotChangePosition()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.MoveTo(StartX, StartY);
            canvas.Tri(TriWidth, TriHeight);

            Assert.AreEqual(StartX, canvas.Xpos);
            Assert.AreEqual(StartY, canvas.Ypos);
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.WriteText(string)"/> executes without throwing an exception.
        /// </summary>
        [TestMethod]
        public void WriteText_DoesNotThrow()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.WriteText("Unit test text");
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.WriteText(string)"/> can handle null input without throwing.
        /// </summary>
        [TestMethod]
        public void WriteText_NullInput_DoesNotThrow()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.WriteText(null);
        }

        /// <summary>
        /// Verifies that <see cref="AppCanvas.Clear"/> executes without throwing an exception.
        /// </summary>
        [TestMethod]
        public void Clear_DoesNotThrow()
        {
            using AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.Clear();
        }

        /// <summary>
        /// Ensures that <see cref="AppCanvas.Dispose"/> can be called safely multiple times.
        /// </summary>
        [TestMethod]
        public void Dispose_CanBeCalledSafely()
        {
            AppCanvas canvas = new(InitialWidth, InitialHeight);
            canvas.Dispose();
            canvas.Dispose(); // should not throw
        }
        
    }
}
