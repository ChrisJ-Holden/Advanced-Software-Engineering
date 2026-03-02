using BOOSE;
using BOOSEGraphicsEnvironment.Commands;

namespace AppTest.CommandsTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="DrawToCommand"/> class.
    /// </summary>
    [TestClass]
    public sealed class DrawToCommandTests
    {
        /// <summary>
        /// A mock implementation of the <see cref="Canvas"/> class for testing purposes.
        /// </summary>
        private class MockCanvas : Canvas
        {
            public int LastX { get; private set; }
            public int LastY { get; private set; }
            public bool DrawToCalled { get; private set; }

            /// <summary>
            /// Overrides the <see cref="Canvas.DrawTo(int, int)"/> method to capture the input coordinates.
            /// </summary>
            
            /// <param name="x">The X-coordinate of the drawing endpoint.</param>
            /// <param name="y">The Y-coordinate of the drawing endpoint.</param>
            public override void DrawTo(int x, int y)
            {
                DrawToCalled = true;
                LastX = x;
                LastY = y;
            }
        }

        /// <summary>
        /// Verifies that the default constructor does not throw and initializes X and Y positions to zero.
        /// </summary>
        [TestMethod]
        public void Constructor_Default_DoesNotThrowAndPositionsAreZero()
        {
            DrawToCommand cmd = new();
            Assert.IsNotNull(cmd);
            Assert.AreEqual(0, cmd.Xpos);
            Assert.AreEqual(0, cmd.Ypos);
        }

        /// <summary>
        /// Verifies that the constructor with a canvas and coordinates correctly sets the X and Y properties.
        /// </summary>
        [TestMethod]
        public void Constructor_WithCanvasAndPositions_SetsProperties()
        {
            MockCanvas mock = new();
            DrawToCommand cmd = new(mock, 4, 6);
            Assert.IsNotNull(cmd);
            Assert.AreEqual(4, cmd.Xpos);
            Assert.AreEqual(6, cmd.Ypos);
        }

        /// <summary>
        /// Verifies that valid integer parameters correctly set the X and Y positions.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ValidIntegers_SetsXAndY()
        {
            DrawToCommand cmd = new();
            cmd.CheckParameters(new string[] { " 15 ", " 20 " });
            Assert.AreEqual(15, cmd.Xpos);
            Assert.AreEqual(20, cmd.Ypos);
        }

        /// <summary>
        /// Ensures that incorrect parameter counts cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_WrongParameterCount_ThrowsCommandException()
        {
            DrawToCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(System.Array.Empty<string>()));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new string[] { "1" }));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new string[] { "1", "2", "3" }));
        }

        /// <summary>
        /// Ensures that non-integer parameter values cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        
        /// <param name="a">The first input value.</param>
        /// <param name="b">The second input value.</param>
        [DataTestMethod]
        [DataRow("", "1")]
        [DataRow("abc", "2")]
        [DataRow("1", "xyz")]
        [DataRow("1,2", "3")]
        public void CheckParameters_NonIntegerValues_ThrowsCommandException(string a, string b)
        {
            DrawToCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new string[] { a, b }));
        }

        /// <summary>
        /// Ensures that a null parameter array causes a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_Null_ThrowsCommandException()
        {
            DrawToCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(null));
        }

        /// <summary>
        /// Ensures that executing the command without a valid canvas throws a <see cref="CommandException"/>.
        /// </summary>
        [TestMethod]
        public void Execute_WithoutCanvas_ThrowsCommandException()
        {
            DrawToCommand cmd = new();
            cmd.Xpos = 3;
            cmd.Ypos = 4;
            Assert.ThrowsException<CommandException>(() => cmd.Execute());
        }
    }
}
