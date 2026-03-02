using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Commands
{
    /// <summary>
    /// Represents a command to draw a circle on a canvas.
    /// Validates the radius parameter and executes the command method of the canvas object.
    /// </summary>
    public sealed class CircleCommand : CommandOneParameter
    {
        /// <summary>
        /// Initialises a new blank instance of the <see cref="CircleCommand"/> class with no parameters for factory instantiation.
        /// </summary>
        public CircleCommand() : base()
        {
            Debug.WriteLine("CircleCommand default constructor called.");
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CircleCommand"/> class with a canvas and radius.
        /// </summary>
        
        /// <param name="canvas">The canvas on which the circle will be drawn.</param>
        /// <param name="radius">The radius of the circle.</param>
        public CircleCommand(Canvas canvas, int radius) : base(canvas)
        {
            Radius = radius;
            Debug.WriteLine($"CircleCommand initialized with radius: {Radius}");
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// Checks and parses the parameters for the circle command.
        /// Expects exactly one integer parameter representing the radius.
        /// </summary>
        
        /// <param name="parameterList">The array of parameters passed to the command.</param>
        
        /// <exception cref="CommandException">
        /// Thrown if the parameter list is invalid or parsing fails.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine("Checking parameters for CircleCommand...");

            try
            {
                if (parameterList.Length != 1)
                {
                    throw new CommandException("Circle requires exactly ONE parameter: RADIUS.");
                }

                string param = parameterList[0].Trim();
                Debug.WriteLine($"Received parameter: '{param}'");

                if (!int.TryParse(param, out int r))
                {
                    throw new CommandException("Circle parameter must be an INTEGER representing the RADIUS.");
                }

                Radius = r;
                Debug.WriteLine($"Parameter parsed successfully. Radius set to: {Radius}");
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is IndexOutOfRangeException)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("Circle requires exactly ONE parameter: RADIUS.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("An unexpected error occurred while checking parameters.");
            }
        }

        /// <summary>
        /// Executes the circle command, drawing a circle on the canvas.
        /// </summary>
        
        /// <exception cref="CommandException">Thrown if the canvas is null or drawing fails.</exception>
        public override void Execute()
        {
            if (canvas == null)
            {
                throw new CommandException("Canvas is null. Cannot execute circle command.");
            };

            Debug.WriteLine($"Executing CircleCommand with radius: {Radius}");
            base.Execute();
            canvas.Circle(Radius, false);
            Debug.WriteLine("Circle drawn successfully.");
        }
    }
}
