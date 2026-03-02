using BOOSE;
using BOOSEGraphicsEnvironment.Commands;

namespace AppTest.CommandsTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="CircleCommand"/> class.
    /// </summary>
    [TestClass]
    public sealed class CircleCommandTests
    {
        /// <summary>
        /// A mock implementation of the <see cref="Canvas"/> class for testing purposes.
        /// Implements the Circle method to track calls and parameters.
        /// </summary>
        private class MockCanvas : Canvas
        {
            public int LastRadius { get; private set; }
            public bool CircleCalled { get; private set; }

            /// <summary>
            /// Overrides <see cref="Canvas.Circle(int,bool)"/> to track calls and parameters.
            /// </summary>

            /// <param name="radius">The radius of the circle to draw.</param>
            /// <param name="filled">Specifies whether the circle should be filled.</param>
            public override void Circle(int radius, bool filled)
            {
                CircleCalled = true;
                LastRadius = radius;
            }

            /// <summary>
            /// Initialises a blank new instance of the <see cref="MockCanvas"/> class.
            /// </summary>
            public MockCanvas() : base() { }
        }

        /// <summary>
        /// Verifies that the default constructor does not throw an exception and initializes the radius to zero.
        /// </summary>
        [TestMethod]
        public void Constructor_Default_DoesNotThrowAndRadiusIsZero()
        {
            CircleCommand cmd = new();
            Assert.IsNotNull(cmd);
            Assert.AreEqual(0, cmd.Radius);
        }

        /// <summary>
        /// Verifies that the constructor with a canvas and radius correctly sets the radius.
        /// </summary>
        [TestMethod]
        public void Constructor_WithCanvasAndRadius_SetsRadius()
        {
            CircleCommand cmd = new(null, 5);
            Assert.IsNotNull(cmd);
            Assert.AreEqual(5, cmd.Radius);
        }

        /// <summary>
        /// Verifies that providing a valid integer parameter correctly sets the radius.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ValidInteger_SetsRadius()
        {
            CircleCommand cmd = new();
            cmd.CheckParameters(new string[] { " 10 " });
            Assert.AreEqual(10, cmd.Radius);
        }

        /// <summary>
        /// Tests invalid input scenarios for the <see cref="CircleCommand.CheckParameters(string[])"/> method
        /// and ensures a <see cref="CommandException"/> is thrown.
        /// </summary>

        /// <param name="input">The invalid input string to test.</param>
        [DataTestMethod]
        [DataRow("")]
        [DataRow("abc")]
        [DataRow("1,2")]
        [DataRow(null)]
        public void CheckParameters_InvalidInput_ThrowsCommandException(string input)
        {
            CircleCommand cmd = new();
            Assert.ThrowsException<CommandException>(
                () => cmd.CheckParameters(input == null ? null : new string[] {input})
            );
        }

        /// <summary>
        /// Verifies that whitespace-trimmed valid input correctly sets the radius.
        /// </summary>
        [TestMethod]
        public void CheckParameters_TrimmedInput_SetsRadius()
        {
            CircleCommand cmd = new();
            cmd.CheckParameters(new string[] {" 42 "});
            Assert.AreEqual(42, cmd.Radius);
        }

        /// <summary>
        /// Ensures that executing the command without a canvas throws a <see cref="CommandException"/>.
        /// </summary>
        [TestMethod]
        public void Execute_WithoutCanvas_ThrowsCommandException()
        {
            CircleCommand cmd = new(null, 3);
            Assert.ThrowsException<CommandException>(() => cmd.Execute());
        }
    }
}