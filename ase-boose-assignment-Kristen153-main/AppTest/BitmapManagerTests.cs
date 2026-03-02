using BOOSEGraphicsEnvironment;
using System.Drawing;

namespace AppTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="BitmapManager"/> class.
    /// </summary>
    [TestClass]
    public sealed class BitmapManagerTests
    {
        private const int InitialWidth = 16;
        private const int InitialHeight = 16;
        private const int NewWidth = 32;
        private const int NewHeight = 8;

        private static readonly Color TestColor1 = Color.FromArgb(255, 10, 20, 30);
        private static readonly Color TestColor2 = Color.FromArgb(255, 200, 150, 100);

        /// <summary>
        /// Verifies that the constructor creates a bitmap and graphics object with the requested size.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesBitmapAndGraphics_WithRequestedSize()
        {
            BitmapManager manager = new(InitialWidth, InitialHeight);

            Assert.IsNotNull(manager.Bitmap, "Bitmap should be created by constructor.");
            Assert.IsNotNull(manager.Graphics, "Graphics should be created by constructor.");
            Assert.AreEqual(InitialWidth, manager.Bitmap.Width, "Bitmap width mismatch.");
            Assert.AreEqual(InitialHeight, manager.Bitmap.Height, "Bitmap height mismatch.");

            manager.Dispose();
        }

        /// <summary>
        /// Verifies that <see cref="BitmapManager.CreateBitmap(int, int)"/> replaces the existing bitmap and graphics with new dimensions.
        /// </summary>
        [TestMethod]
        public void CreateBitmap_ReplacesBitmapAndGraphics_WithNewSize()
        {
            BitmapManager manager = new(InitialWidth, InitialHeight);

            manager.CreateBitmap(NewWidth, NewHeight);

            Assert.IsNotNull(manager.Bitmap);
            Assert.IsNotNull(manager.Graphics);
            Assert.AreEqual(NewWidth, manager.Bitmap.Width);
            Assert.AreEqual(NewHeight, manager.Bitmap.Height);

            manager.Dispose();
        }

        /// <summary>
        /// Ensures that calling <see cref="BitmapManager.CopyBitmap(Bitmap)"/> with null does not throw and preserves bitmap and graphics.
        /// </summary>

        [TestMethod]
        public void CopyBitmap_WithNull_DoesNotThrow()
        {
            BitmapManager manager = new BitmapManager(InitialWidth, InitialHeight);

            manager.CopyBitmap(null);

            Assert.IsNotNull(manager.Bitmap, "Bitmap should still exist.");
            Assert.IsNotNull(manager.Graphics, "Graphics should still exist.");

            manager.Dispose();
        }

        /// <summary>
        /// Verifies that copying a source bitmap with <see cref="BitmapManager.CopyBitmap(Bitmap)"/> does not throw and preserves bitmap and graphics.
        /// </summary>
        [TestMethod]
        public void CopyBitmap_WithSource_DoesNotThrow()
        {
            BitmapManager manager = new BitmapManager(InitialWidth, InitialHeight);

            using Bitmap source = new Bitmap(InitialWidth, InitialHeight);

            manager.CopyBitmap(source);

            Assert.IsNotNull(manager.Bitmap, "Bitmap should still exist after copy.");
            Assert.IsNotNull(manager.Graphics, "Graphics should still exist after copy.");

            manager.Dispose();
        }

        /// <summary>
        /// Verifies that <see cref="BitmapManager.Resize(int, int)"/> correctly updates the bitmap dimensions and recreates the graphics object.
        /// </summary>
        [TestMethod]
        public void Resize_ChangesBitmapDimensions_AndCreatesGraphics()
        {
            BitmapManager manager = new(InitialWidth, InitialHeight);

            manager.Resize(NewWidth, NewHeight);

            Assert.IsNotNull(manager.Bitmap, "Bitmap should not be null after resize.");
            Assert.IsNotNull(manager.Graphics, "Graphics should not be null after resize.");
            Assert.AreEqual(NewWidth, manager.Bitmap.Width, "Bitmap width should match requested resize width.");
            Assert.AreEqual(NewHeight, manager.Bitmap.Height, "Bitmap height should match requested resize height.");

            manager.Dispose();
        }

        /// <summary>
        /// Ensures that <see cref="BitmapManager.Dispose"/> can be called multiple times safely (idempotent).
        /// </summary>
        [TestMethod]
        public void Dispose_IsIdempotent_DoesNotThrowWhenCalledMultipleTimes()
        {
            BitmapManager manager = new(InitialWidth, InitialHeight);

            manager.Dispose();
            manager.Dispose(); // second call should be safe

        }
    }
}