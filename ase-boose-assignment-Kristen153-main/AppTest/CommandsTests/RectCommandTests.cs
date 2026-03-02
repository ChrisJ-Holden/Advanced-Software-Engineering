using BOOSE;
using BOOSEGraphicsEnvironment.Commands;

namespace AppTest.CommandsTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="RectCommand"/> class.
    /// </summary>
    [TestClass]
    public sealed class RectCommandTests
    {
        /// <summary>
        /// Mock implementation of the <see cref="Canvas"/> class for testing purposes inside <see cref="RectCommandTests"/>.
        /// </summary>
        private class MockCanvas : Canvas
        {
            public int LastWidth { get; private set; }
            public int LastHeight { get; private set; }
            public bool RectCalled { get; private set; }
            public bool LastFilled { get; private set; }

            /// <summary>
            /// Overrides the <see cref="Canvas.Rect(int, int, bool)"/> method to capture test data.
            /// </summary>
            
            /// <param name="width">The width of the rectangle.</param>
            /// <param name="height">The height of the rectangle.</param>
            /// <param name="filled">Specifies whether the rectangle should be filled.</param>
            public override void Rect(int width, int height, bool filled)
            {
                RectCalled = true;
                LastWidth = width;
                LastHeight = height;
            }
        }

        /// <summary>
        /// Verifies that the default constructor does not throw and initializes width and height to zero.
        /// </summary>
        [TestMethod]
        public void Constructor_Default_DoesNotThrowAndWidthHeightAreZero()
        {
            var cmd = new RectCommand();
            Assert.IsNotNull(cmd);
            Assert.AreEqual(0, cmd.Width);
            Assert.AreEqual(0, cmd.Height);
        }

        /// <summary>
        /// Verifies that the constructor with a canvas and dimensions sets the properties correctly.
        /// </summary>
        [TestMethod]
        public void Constructor_WithCanvasAndDimensions_SetsProperties()
        {
            var mock = new MockCanvas();
            var cmd = new RectCommand(mock, 8, 9);
            Assert.IsNotNull(cmd);
            Assert.AreEqual(8, cmd.Width);
            Assert.AreEqual(9, cmd.Height);
        }

        /// <summary>
        /// Verifies that valid integer parameters correctly set the width and height.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ValidIntegers_SetsWidthAndHeight()
        {
            var cmd = new RectCommand();
            cmd.CheckParameters(new[] { " 12 ", "34" });
            Assert.AreEqual(12, cmd.Width);
            Assert.AreEqual(34, cmd.Height);
        }

        /// <summary>
        /// Ensures that incorrect parameter counts cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_WrongParameterCount_ThrowsCommandException()
        {
            var cmd = new RectCommand();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(System.Array.Empty<string>()));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { "1" }));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { "1", "2", "3" }));
        }

        /// <summary>
        /// Ensures that non-integer parameter values cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        
        /// <param name="a">The first input value (width).</param>
        /// <param name="b">The second input value (height).</param>
        [DataTestMethod]
        [DataRow("", "1")]
        [DataRow("abc", "2")]
        [DataRow("1", "xyz")]
        [DataRow("1,2", "3")]
        public void CheckParameters_NonIntegerValues_ThrowsCommandException(string a, string b)
        {
            var cmd = new RectCommand();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { a, b }));
        }

        /// <summary>
        /// Ensures that a null parameter array causes a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_Null_ThrowsCommandException()
        {
            RectCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(null));
        }

        /// <summary>
        /// Ensures that executing the command without a valid canvas throws a <see cref="CommandException"/>.
        /// </summary>
        [TestMethod]
        public void Execute_WithoutCanvas_ThrowsCommandException()
        {
            RectCommand cmd = new();
            cmd.Width = 3;
            cmd.Height = 4;
            Assert.ThrowsException<CommandException>(() => cmd.Execute());
        }
    }
}