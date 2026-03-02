using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    public partial class AppCanvas
    {
        /// <summary>
        /// Clears the canvas to a white background.
        /// </summary>
        public void Clear()
        {
            CanvasGraphics.Clear(Color.White);
            Debug.WriteLine("Canvas cleared");
        }

        /// <summary>
        /// Resets the drawing cursor to the default position.
        /// </summary>
        public void Reset()
        {
            Xpos = DefaultX;
            Ypos = DefaultY;
            Debug.WriteLine("Canvas position reset to default");
        }

        /// <summary>
        /// Resizes the canvas to the specified dimensions.
        /// </summary>

        /// <param name="width">The new width of the canvas.</param>
        /// <param name="height">The new height of the canvas.</param>
        public void Set(int width, int height)
        {
            _bitmapManager.Resize(width, height);
            Debug.WriteLine($"Canvas resized to {width}x{height}");
        }
    }
}
