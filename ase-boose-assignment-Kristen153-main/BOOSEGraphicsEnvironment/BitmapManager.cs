using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    /// <summary>
    /// Manages a bitmap and its associated graphics context.
    /// Provides functionality to create, copy, resize, and dispose of the bitmap.
    /// </summary>
    public class BitmapManager : IDisposable
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BitmapManager"/> class
        /// with the specified width and height.
        /// </summary>
        
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        public BitmapManager(int width, int height)
        {
            CreateBitmap(width, height);
            Debug.WriteLine($"BitmapManager created with size {width}x{height}");
        }

        /// <summary>
        /// Gets or sets the current bitmap.
        /// </summary>
        public Bitmap Bitmap { get; private set; }

        /// <summary>
        /// Gets or sets the graphics context for drawing on the bitmap.
        /// </summary>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// Creates a new bitmap and initializes the graphics context.
        /// Disposes of any existing bitmap or graphics.
        /// </summary>
        
        /// <param name="width">The width of the new bitmap.</param>
        /// <param name="height">The height of the new bitmap.</param>
        public void CreateBitmap(int width, int height)
        {
            Bitmap newBitmap = new Bitmap(width, height);

            Graphics?.Dispose();
            Bitmap?.Dispose();

            Bitmap = newBitmap;
            Graphics = Graphics.FromImage(Bitmap);

            Debug.WriteLine($"Bitmap created with size {width}x{height}");
        }

        /// <summary>
        /// Copies the contents of another bitmap onto the current bitmap.
        /// </summary>
        
        /// <param name="oldBitmap">The bitmap to copy from.</param>
        public void CopyBitmap(Bitmap oldBitmap)
        {
            if (oldBitmap == null) return;

            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                g.DrawImage(oldBitmap, 0, 0);
            }

            Debug.WriteLine("Bitmap copied from old bitmap");
        }

        /// <summary>
        /// Resizes the current bitmap to the specified dimensions.
        /// Preserves the content of the original bitmap.
        /// </summary>
        
        /// <param name="width">The new width of the bitmap.</param>
        /// <param name="height">The new height of the bitmap.</param>
        public void Resize(int width, int height)
        {
            Bitmap newBitmap = new Bitmap(width, height);

            CopyBitmap(newBitmap);

            Graphics newGraphics = Graphics.FromImage(newBitmap);

            Graphics?.Dispose();
            Bitmap?.Dispose();

            Bitmap = newBitmap;
            Graphics = newGraphics;

            Debug.WriteLine($"Bitmap resized to {width}x{height}");
        }

        /// <summary>
        /// Disposes the bitmap and graphics resources.
        /// </summary>
        public void Dispose()
        {
            Graphics?.Dispose();
            Bitmap?.Dispose();
            Debug.WriteLine("BitmapManager disposed");
        }
    }
}
