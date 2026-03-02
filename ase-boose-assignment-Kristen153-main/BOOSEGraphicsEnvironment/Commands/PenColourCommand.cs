using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Commands
{
    /// <summary>
    /// Represents a command to set the drawing pen color on the canvas.
    /// Validates the Red, Green, and Blue color values and executes the color change.
    /// </summary>
    public class PenColourCommand : CommandThreeParameters
    {
        /// <summary>
        /// Initialises a new blank instance of the <see cref="PenColourCommand"/> class with no parameters for factory instantiation.
        /// </summary>
        public PenColourCommand() : base()
        {
            Debug.WriteLine("PenCommand default constructor called.");
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PenColourCommand"/> class with a canvas and RGB color values.
        /// </summary>
        
        /// <param name="canvas">The canvas on which to set the pen color.</param>
        /// <param name="r">The red component (0–255) of the color.</param>
        /// <param name="g">The green component (0–255) of the color.</param>
        /// <param name="b">The blue component (0–255) of the color.</param>
        public PenColourCommand(Canvas canvas, int r, int g, int b) : base(canvas)
        {
            R = r;
            G = g;
            B = b;
            Debug.WriteLine($"PenCommand initialized with R={R}, G={G}, B={B}");
        }

        /// <summary>
        /// Gets or sets the red component of the pen color.
        /// </summary>
        public int R { get; set; }

        /// <summary>
        /// Gets or sets the green component of the pen color.
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// Gets or sets the blue component of the pen color.
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// Checks and parses the parameters for the Pen command.
        /// Expects exactly three integer parameters representing the Red, Green, and Blue color components.
        /// </summary>
        
        /// <param name="parameterList">The array of parameters passed to the command.</param>
        
        /// <exception cref="CommandException">
        /// Thrown if the parameter list is invalid or parsing fails.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine("Checking parameters for PenCommand...");

            try
            {
                if (parameterList.Length != 3)
                {
                    throw new CommandException("Pen requires exactly three parameters: Red, Green, and Blue color values.");
                }

                string rParam = parameterList[0].Trim();
                string gParam = parameterList[1].Trim();
                string bParam = parameterList[2].Trim();
                Debug.WriteLine($"Received parameters: R='{rParam}', G='{gParam}', B='{bParam}'");

                if (!int.TryParse(rParam, out int r))
                {
                    throw new CommandException("Pen first parameter must be an integer representing the Red color value.");
                }

                if (!int.TryParse(gParam, out int g))
                {
                    throw new CommandException("Pen second parameter must be an integer representing the Green color value.");
                }

                if (!int.TryParse(bParam, out int b))
                {
                    throw new CommandException("Pen third parameter must be an integer representing the Blue color value.");
                }

                R = r;
                G = g;
                B = b;
                Debug.WriteLine($"Parameters parsed successfully. R={R}, G={G}, B={B}");
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is IndexOutOfRangeException)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("Pen requires exactly three parameters: Red, Green, and Blue color values.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("An unexpected error occurred while checking parameters.");
            }
        }

        /// <summary>
        /// Executes the Pen command by setting the canvas pen color to the specified RGB values.
        /// </summary>
        
        /// <exception cref="CommandException">Thrown if the canvas is null or color setting fails.</exception>
        public override void Execute()
        {
            if (canvas == null)
            {
                throw new CommandException("Canvas is null. Cannot execute PenColour command.");
            };
            Debug.WriteLine($"Executing PenCommand with R={R}, G={G}, B={B}");
            base.Execute();
            Canvas.SetColour(R, G, B);
            Debug.WriteLine("PenCommand executed successfully.");
        }
    }
}
