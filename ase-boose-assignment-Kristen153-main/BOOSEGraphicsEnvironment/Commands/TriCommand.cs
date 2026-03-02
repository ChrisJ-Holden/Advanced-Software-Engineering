using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Commands
{
    /// <summary>
    /// Represents a command to draw a triangle on the canvas.
    /// Validates the width and height parameters and executes the drawing action.
    /// </summary>
    public class TriCommand : CommandTwoParameters
    {
        /// <summary>
        /// Initialises a new blank instance of the <see cref="TriCommand"/> class with no parameters for factory instantiation.
        /// </summary>
        public TriCommand() : base()
        {
            Debug.WriteLine("TriCommand default constructor called.");
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="TriCommand"/> class with a canvas and triangle dimensions.
        /// </summary>
        
        /// <param name="canvas">The canvas on which to draw the triangle.</param>
        /// <param name="width">The width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public TriCommand(Canvas canvas, int width, int height) : base(canvas)
        {
            Width = width;
            Height = height;
            Debug.WriteLine($"TriCommand initialized with Width={Width}, Height={Height}");
        }

        /// <summary>
        /// Gets or sets the width of the triangle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the triangle.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Checks and parses the parameters for the Tri command.
        /// Expects exactly two integer parameters representing width and height.
        /// </summary>
        
        /// <param name="parameterList">The array of parameters passed to the command.</param>
        
        /// <exception cref="CommandException">
        /// Thrown if the parameter list is invalid or parsing fails.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine("Checking parameters for TriCommand...");

            try
            {
                if (parameterList.Length != 2)
                {
                    throw new CommandException("Tri requires exactly two parameters: Width and Height.");
                }

                string widthParam = parameterList[0].Trim();
                string heightParam = parameterList[1].Trim();
                Debug.WriteLine($"Received parameters: Width='{widthParam}', Height='{heightParam}'");

                if (!int.TryParse(widthParam, out int w))
                {
                    throw new CommandException("Tri first parameter must be an integer representing the Width.");
                }

                if (!int.TryParse(heightParam, out int h))
                {
                    throw new CommandException("Tri second parameter must be an integer representing the Height.");
                }

                Width = w;
                Height = h;
                Debug.WriteLine($"Parameters parsed successfully. Width={Width}, Height={Height}");
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is IndexOutOfRangeException)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("Tri requires exactly two parameters: Width and Height.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("An unexpected error occurred while checking parameters.");
            }
        }

        /// <summary>
        /// Executes the Tri command by drawing a triangle on the canvas with the specified dimensions.
        /// </summary>
        
        /// <exception cref="CommandException">Thrown if the canvas is null or drawing fails.</exception>
        public override void Execute()
        {
            if (canvas == null)
            {
                throw new CommandException("Canvas is null. Cannot execute Tri command.");
            };
            Debug.WriteLine($"Executing TriCommand with Width={Width}, Height={Height}");
            base.Execute();
            canvas.Tri(Width, Height);
            Debug.WriteLine("TriCommand executed successfully.");
        }
    }
}
