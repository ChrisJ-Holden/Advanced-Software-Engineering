using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    public partial class AppCanvas
    {

        private readonly StringFormat _stringFormat = new()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near,
            Trimming = StringTrimming.Word
        };

        /// <summary>
        /// Writes text at the top-left corner of the canvas using the current pen color.
        /// </summary>

        /// <param name="text">The text to write.</param>
        public void WriteText(string text)
        {
            using Font font = new Font("Arial", 12);
            using Brush brush = new SolidBrush(_penColour);
            CanvasGraphics.DrawString(text, font, brush, CanvasBorder, _stringFormat);
            Debug.WriteLine($"Wrote text: '{text}'");
        }
    }
}
