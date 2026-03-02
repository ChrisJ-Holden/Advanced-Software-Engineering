using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment.Commands
{
    /// <summary>
    /// Represents a command to move to a specified position on the canvas.
    /// Validates the X and Y position parameters and updates the position.
    /// </summary>
    public class MoveToCommand : CommandTwoParameters
    {
        /// <summary>
        /// Initialises a new blank instance of the <see cref="MoveToCommand"/> class with no parameters for factory instantiation.
        /// </summary>
        public MoveToCommand() : base()
        {
            Debug.WriteLine("MoveToCommand default constructor called.");
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MoveToCommand"/> class with a canvas and coordinates.
        /// </summary>
        /// 
        /// <param name="canvas">The canvas on which to move the cursor.</param>
        /// <param name="x">The X-axis position to move to.</param>
        /// <param name="y">The Y-axis position to move to.</param>
        public MoveToCommand(Canvas canvas, int x, int y) : base(canvas)
        {
            Xpos = x;
            Ypos = y;
            Debug.WriteLine($"MoveToCommand initialized with X={Xpos}, Y={Ypos}");
        }

        /// <summary>
        /// Gets or sets the X-axis position for the move command.
        /// </summary>
        public int Xpos { get; set; }

        /// <summary>
        /// Gets or sets the Y-axis position for the move command.
        /// </summary>
        public int Ypos { get; set; }

        /// <summary>
        /// Checks and parses the parameters for the MoveTo command.
        /// Expects exactly two integer parameters representing the X and Y positions.
        /// </summary>
        
        /// <param name="parameterList">The array of parameters passed to the command.</param>
        
        /// <exception cref="CommandException">
        /// Thrown if the parameter list is invalid or parsing fails.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine("Checking parameters for MoveToCommand...");

            try
            {
                if (parameterList.Length != 2)
                {
                    throw new CommandException("Moveto requires exactly two parameters: X axis position and Y axis position.");
                }

                string xParam = parameterList[0].Trim();
                string yParam = parameterList[1].Trim();
                Debug.WriteLine($"Received parameters: X='{xParam}', Y='{yParam}'");

                if (!int.TryParse(xParam, out int x))
                {
                    throw new CommandException("Moveto first parameter must be an integer representing the X axis position.");
                }

                if (!int.TryParse(yParam, out int y))
                {
                    throw new CommandException("Moveto second parameter must be an integer representing the Y axis position.");
                }

                Xpos = x;
                Ypos = y;
                Debug.WriteLine($"Parameters parsed successfully. X={Xpos}, Y={Ypos}");
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is IndexOutOfRangeException)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("Moveto requires exactly two parameters: X axis position and Y axis position.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new CommandException("An unexpected error occurred while checking parameters.");
            }
        }

        /// <summary>
        /// Executes the MoveTo command by moving to the specified position on the canvas.
        /// </summary>
        
        /// <exception cref="CommandException">Thrown if the canvas is null or movement fails.</exception>
        public override void Execute()
        {
            if (canvas == null)
            {
                throw new CommandException("Canvas is null. Cannot execute MoveTo command.");
            };

            Debug.WriteLine($"Executing MoveToCommand with X={Xpos}, Y={Ypos}");
            base.Execute();
            canvas.MoveTo(Xpos, Ypos);
            Debug.WriteLine("MoveTo executed successfully.");
        }
    }
}
