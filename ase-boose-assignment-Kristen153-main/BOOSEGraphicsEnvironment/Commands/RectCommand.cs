using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Commands
{
    /// <summary>
    /// Represents a command to draw a rectangle on the canvas.
    /// Validates the width and height parameters and executes the drawing action.
    /// </summary>
    public class RectCommand : CommandTwoParameters
    {
        /// <summary>
        /// Initialises a new blank instance of the <see cref="RectCommand"/> class with no parameters for factory instantiation.
        /// </summary>
        public RectCommand() : base()
        {
            Debug.WriteLine("RectCommand default constructor called.");
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RectCommand"/> class with a canvas and rectangle dimensions.
        /// </summary>
        
        /// <param name="canvas">The canvas on which to draw the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public RectCommand(Canvas canvas, int width, int height) : base(canvas)
        {
            Width = width;
            Height = height;
            Debug.WriteLine($"RectCommand initialized with Width={Width}, Height={Height}");
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Checks and parses the parameters for the Rect command.
        /// Expects exactly two integer parameters representing width and height.
        /// </summary>
        
        /// <param name="parameterList">The array of parameters passed to the command.</param>
        
        /// <exception cref="CommandException">
        /// Thrown if the parameter list is invalid or parsing fails.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine("Checking parameters for RectCommand...");

            try
            {
                if (parameterList.Length != 2)
                {
                    throw new CommandException("Rect requires exactly two parameters: Width and Height.");
                }

                string widthParam = parameterList[0].Trim();
                string heightParam = parameterList[1].Trim();
                Debug.WriteLine($"Received parameters: Width='{widthParam}', Height='{heightParam}'");

                if (!int.TryParse(widthParam, out int w))
                {
                    throw new CommandException("Rect first parameter must be an integer representing the Width.");
                }

                if (!int.TryParse(heightParam, out int h))
                {
                    throw new CommandException("Rect second parameter must be an integer representing the Height.");
                }

                Width = w;
                Height = h;
                Debug.WriteLine($"Parameters parsed successfully. Width={Width}, Height={Height}");
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is IndexOutOfRangeException)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("Rect requires exactly two parameters: Width and Height.");
            }
            catch (CommandException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Executes the Rect command by drawing a rectangle on the canvas with the specified dimensions.
        /// </summary>
        
        /// <exception cref="CommandException">Thrown if the canvas is null or drawing fails.</exception>
        public override void Execute()
        {
            if (canvas == null)
            {
                throw new CommandException("Canvas is null. Cannot execute Rect command.");
            };
            Debug.WriteLine($"Executing RectCommand with Width={Width}, Height={Height}");
            base.Execute();
            canvas.Rect(Width, Height, false);
            Debug.WriteLine("RectCommand executed successfully.");
        }
    }
}
