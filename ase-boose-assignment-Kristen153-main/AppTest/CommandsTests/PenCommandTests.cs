using BOOSE;
using BOOSEGraphicsEnvironment.Commands;

namespace AppTest.CommandsTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="PenColourCommand"/> class.
    /// </summary>
    [TestClass]
    public sealed class PenCommandTests
    {
        /// <summary>
        /// Mock implementation of the <see cref="Canvas"/> class for testing purposes inside <see cref="PenCommandTests"/>.
        /// </summary>
        private class MockCanvas : Canvas
        {
            public int LastR { get; private set; }
            public int LastG { get; private set; }
            public int LastB { get; private set; }
            public bool SetColourCalled { get; private set; }

            /// <summary>
            /// Overrides the <see cref="Canvas.SetColour(int, int, int)"/> method to capture test data.
            /// </summary>

            /// <param name="red">Red component value (0 - 255).</param>
            /// <param name="green">Green component value (0 - 255).</param>
            /// <param name="blue">Blue component value (0 - 255).</param>
            public override void SetColour(int red, int green, int blue)
            {
                SetColourCalled = true;
                LastR = red;
                LastG = green;
                LastB = blue;
            }
        }

        /// <summary>
        /// Verifies that the default constructor does not throw and initializes RGB values to zero.
        /// </summary>
        [TestMethod]
        public void Constructor_Default_DoesNotThrowAndRGBAreZero()
        {
            PenColourCommand cmd = new();
            Assert.IsNotNull(cmd);
            Assert.AreEqual(0, cmd.R);
            Assert.AreEqual(0, cmd.G);
            Assert.AreEqual(0, cmd.B);
        }

        /// <summary>
        /// Verifies that the constructor with a canvas and RGB values sets the properties correctly.
        /// </summary>
        [TestMethod]
        public void Constructor_WithCanvasAndRGB_SetsProperties()
        {
            MockCanvas mock = new();
            PenColourCommand cmd = new(mock, 1, 2, 3);
            Assert.IsNotNull(cmd);
            Assert.AreEqual(1, cmd.R);
            Assert.AreEqual(2, cmd.G);
            Assert.AreEqual(3, cmd.B);
        }

        /// <summary>
        /// Verifies that valid integer parameters correctly set the R, G, and B properties.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ValidIntegers_SetsR_G_B()
        {
            PenColourCommand cmd = new();
            cmd.CheckParameters(new[] { " 10 ", "20", " 30 " });
            Assert.AreEqual(10, cmd.R);
            Assert.AreEqual(20, cmd.G);
            Assert.AreEqual(30, cmd.B);
        }

        /// <summary>
        /// Ensures that incorrect parameter counts cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_WrongParameterCount_ThrowsCommandException()
        {
            PenColourCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(System.Array.Empty<string>()));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { "1" }));
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { "1", "2", "3", "4" }));
        }

        /// <summary>
        /// Ensures that non-integer parameter values cause a <see cref="CommandException"/> to be thrown.
        /// </summary>
        
        /// <param name="a">Red component input value.</param>
        /// <param name="b">Green component input value.</param>
        /// <param name="c">Blue component input value.</param>
        [DataTestMethod]
        [DataRow("", "1", "2")]
        [DataRow("abc", "2", "3")]
        [DataRow("1", "xyz", "3")]
        [DataRow("1", "2", "4,5")]
        public void CheckParameters_NonIntegerValues_ThrowsCommandException(string a, string b, string c)
        {
            PenColourCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(new[] { a, b, c }));
        }

        /// <summary>
        /// Ensures that passing a null parameter array causes a <see cref="CommandException"/> to be thrown.
        /// </summary>
        [TestMethod]
        public void CheckParameters_Null_ThrowsCommandException()
        {
            PenColourCommand cmd = new();
            Assert.ThrowsException<CommandException>(() => cmd.CheckParameters(null));
        }

        /// <summary>
        /// Ensures that executing the command without a canvas throws a <see cref="CommandException"/>.
        /// </summary>
        [TestMethod]
        public void Execute_WithoutCanvas_ThrowsCommandException()
        {
            PenColourCommand cmd = new();
            cmd.R = 5;
            cmd.G = 6;
            cmd.B = 7;
            Assert.ThrowsException<CommandException>(() => cmd.Execute());
        }
    }
}