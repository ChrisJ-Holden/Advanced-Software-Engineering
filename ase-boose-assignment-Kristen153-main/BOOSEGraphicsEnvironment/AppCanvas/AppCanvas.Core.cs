using BOOSE;
using BOOSEGraphicsEnvironment.Shapes;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    /// <summary>
    /// Represents the drawing canvas for the BOOSE graphics environment.
    /// Provides drawing operations such as lines, shapes, text, and canvas management.
    /// </summary>
    public partial class AppCanvas : ICanvas, IDisposable
    {
        private const int DefaultX = 0;
        private const int DefaultY = 0;
        private const int DefaultPenWidth = 5;
        private static readonly Color DefaultPenColour = Color.Black;

        private BitmapManager _bitmapManager;
        private Pen _pen;
        private Color _penColour;

        /// <summary>
        /// Gets or sets the current X position of the drawing cursor.
        /// </summary>
        public int Xpos { get; set; }

        /// <summary>
        /// Gets or sets the current Y position of the drawing cursor.
        /// </summary>
        public int Ypos { get; set; }

        /// <summary>
        /// Gets or sets the current pen color.
        /// </summary>
        public object PenColour
        {
            get => _penColour;
            set
            {
                _penColour = (Color)value;
                _pen?.Dispose();
                _pen = new Pen(_penColour, DefaultPenWidth);
                Debug.WriteLine($"Pen color set to R={_penColour.R}, G={_penColour.G}, B={_penColour.B}");
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AppCanvas"/> class with the specified width and height.
        /// </summary>
        
        /// <param name="width">The width of the canvas.</param>
        /// <param name="height">The height of the canvas.</param>
        public AppCanvas(int width, int height)
        {
            _bitmapManager = new BitmapManager(width, height);
            _pen = new Pen(DefaultPenColour, DefaultPenWidth);
            Xpos = DefaultX;
            Ypos = DefaultY;
            Debug.WriteLine($"AppCanvas created with size {width}x{height}");
        }

        /// <summary>
        /// Gets the underlying bitmap.
        /// </summary>
        
        /// <returns>The canvas bitmap.</returns>
        public object getBitmap() => CanvasBitmap;

        /// <summary>
        /// Sets the current pen color using RGB values.
        /// </summary>
        
        /// <param name="red">Red component (0–255).</param>
        /// <param name="green">Green component (0–255).</param>
        /// <param name="blue">Blue component (0–255).</param>
        public void SetColour(int red, int green, int blue)
        {
            PenColour = RGB(red, green, blue);
        }

        /// <summary>
        /// Moves the drawing cursor to the specified coordinates.
        /// </summary>
        
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        public void MoveTo(int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Debug.WriteLine($"Moved to position X={Xpos}, Y={Ypos}");
        }

        /// <summary>
        /// Creates a <see cref="Color"/> from the specified RGB components.
        /// </summary>
        private static Color RGB(int r, int g, int b) => Color.FromArgb(r, g, b);

        /// <summary>
        /// Gets the current canvas bitmap.
        /// </summary>
        private Bitmap CanvasBitmap => _bitmapManager.Bitmap;

        /// <summary>
        /// Gets the current graphics context of the canvas.
        /// </summary>
        private Graphics CanvasGraphics => _bitmapManager.Graphics;

        /// <summary>
        /// Gets a rectangle representing the full bounds of the canvas.
        /// </summary>
        private RectangleF CanvasBorder => new(0, 0, CanvasBitmap.Width, CanvasBitmap.Height);

        /// <summary>
        /// Releases resources used by the <see cref="AppCanvas"/> instance.
        /// </summary>
        public void Dispose()
        {
            _bitmapManager?.Dispose();
            _pen?.Dispose();
            Debug.WriteLine("AppCanvas disposed");
        }
    }
}
