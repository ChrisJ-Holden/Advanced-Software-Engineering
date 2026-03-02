using BOOSE;
using BOOSEGraphicsEnvironment.Commands;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    /// <summary>
    /// Factory class responsible for creating Command instances based on command type strings.
    /// Validates the command type and throws a <see cref="FactoryException"/> for invalid commands.
    /// </summary>
    public class AppCommandFactory : CommandFactory
    {
        /// <summary>
        /// Creates a command object corresponding to the given command type.
        /// </summary>
        
        /// <param name="commandType">The type of command to create (e.g., "circle", "moveto").</param>
        
        /// <returns>An instance of <see cref="ICommand"/> corresponding to the command type.</returns>

        /// <exception cref="FactoryException">
        /// Thrown when the command type is null, empty, or invalid.
        /// </exception>
        public override ICommand MakeCommand(string commandType)
        {
            if (string.IsNullOrWhiteSpace(commandType))
            {
                throw new FactoryException("Command type cannot be null or empty.");
            }

            // Normalise the command string
            commandType = commandType.Trim().ToLower();
            Debug.WriteLine($"Attempting to create command: '{commandType}'");

            try
            {
                return commandType switch
                {
                    "moveto" => new MoveToCommand(),
                    "drawto" => new DrawToCommand(),
                    "circle" => new CircleCommand(),
                    "tri" => new TriCommand(),
                    "rect" => new RectCommand(),
                    "pen" => new PenColourCommand(),
                    _ => base.MakeCommand(commandType),
                };
            }
            catch (FactoryException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new FactoryException($"Invalid command: '{commandType}'.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new FactoryException("An unexpected error occurred while creating the command.");
            }
        }
    }
}
