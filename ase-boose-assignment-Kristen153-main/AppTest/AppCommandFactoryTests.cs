using BOOSE;
using BOOSEGraphicsEnvironment;
using BOOSEGraphicsEnvironment.Commands;

namespace AppTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="AppCommandFactory"/> class.
    /// </summary>
    [TestClass]
    public sealed class AppCommandFactoryTests
    {
        private AppCommandFactory factory = null!;

        /// <summary>
        /// Initialises the <see cref="AppCommandFactory"/> before each test.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            factory = new AppCommandFactory();
        }

        /// <summary>
        /// Verifies that known command names return instances of the expected command type.
        /// Handles case-insensitive input and trims whitespace.
        /// </summary>
        
        /// <param name="input">The command name to create.</param>
        /// <param name="expectedType">The expected command type.</param>
        [DataTestMethod]
        [DataRow("moveto", typeof(MoveToCommand))]
        [DataRow("drawto", typeof(DrawToCommand))]
        [DataRow("circle", typeof(CircleCommand))]
        [DataRow("tri", typeof(TriCommand))]
        [DataRow("rect", typeof(RectCommand))]
        [DataRow("pen", typeof(PenColourCommand))]
        [DataRow("  MoveTo  ", typeof(MoveToCommand))]  // trims whitespace
        [DataRow("CiRcLe", typeof(CircleCommand))]      // case-insensitive
        public void MakeCommand_KnownCommands_ReturnsExpectedType(string input, Type expectedType)
        {
            var command = factory.MakeCommand(input);
            Assert.IsNotNull(command, $"MakeCommand returned null for input '{input}'");
            Assert.IsInstanceOfType(command, expectedType, $"Unexpected command type for input '{input}'");
        }

        /// <summary>
        /// Verifies that null or whitespace input causes <see cref="FactoryException"/> to be thrown.
        /// </summary>
        
        /// <param name="input">The input string to test.</param>
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void MakeCommand_NullOrWhitespace_ThrowsFactoryException(string input)
        {
            Assert.ThrowsException<FactoryException>(() => factory.MakeCommand(input));
        }

        /// <summary>
        /// Verifies that an unknown command string causes <see cref="FactoryException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void MakeCommand_UnknownCommand_ThrowsFactoryException()
        {
            Assert.ThrowsException<FactoryException>(() => factory.MakeCommand("unknown-command"));
        }
    }
}
