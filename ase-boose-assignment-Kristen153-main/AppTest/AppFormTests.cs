using BOOSEGraphicsEnvironment;
using System.Windows.Forms;
using System.Reflection;

namespace AppTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="AppForm"/> class.
    /// </summary>
    [TestClass]
    public sealed class AppFormTests
    {
        private static BindingFlags InstanceNonPublic => BindingFlags.Instance | BindingFlags.NonPublic;

        /// <summary>
        /// Helper method to get a private field value from an object.
        /// </summary>
        
        /// <param name="obj">The object containing the field.</param>
        /// <param name="fieldName">The name of the private field.</param>
        
        /// <returns>The value of the private field.</returns>
        private object GetPrivateField(object obj, string fieldName)
        {
            return obj.GetType().GetField(fieldName, InstanceNonPublic)!.GetValue(obj)!;
        }

        /// <summary>
        /// Helper method to get a private method info from an object.
        /// </summary>
        
        /// <param name="obj">The object containing the method.</param>
        /// <param name="methodName">The name of the private method.</param>
        
        /// <returns>The <see cref="MethodInfo"/> for the private method.</returns>
        private MethodInfo GetPrivateMethod(object obj, string methodName)
        {
            return obj.GetType().GetMethod(methodName, InstanceNonPublic)!;
        }

        /// <summary>
        /// Verifies that the constructor initializes internal controls correctly.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesControls()
        {
            AppForm form = new();

            object canvas = GetPrivateField(form, "formCanvas");
            object bitmap = GetPrivateField(form, "formBitmap");
            object commandLogObj = GetPrivateField(form, "CommandLog");

            Assert.IsNotNull(canvas);
            Assert.IsNotNull(bitmap);
            Assert.IsNotNull(commandLogObj);

            RichTextBox commandLog = (RichTextBox)commandLogObj;
            Assert.IsTrue(commandLog.ReadOnly);
            Assert.IsTrue(commandLog.Multiline);
        }

        /// <summary>
        /// Verifies that the private <c>AppendCommandLog</c> method correctly appends lines to the command log.
        /// </summary>
        [TestMethod]
        public void AppendCommandLog_AddsText()
        {
            AppForm form = new();
            MethodInfo appendMethod = GetPrivateMethod(form, "AppendCommandLog");
            RichTextBox commandLog = (RichTextBox)GetPrivateField(form, "CommandLog");

            commandLog.Clear();
            appendMethod.Invoke(form, new object[] { new string[] { "line1", "line2" } });

            string text = commandLog.Text;
            StringAssert.Contains(text, "line1");
            StringAssert.Contains(text, "line2");
        }

        /// <summary>
        /// Ensures that clicking the Run button when the compiler or runtime is null writes an error to the log.
        /// </summary>
        [TestMethod]
        public void RunButton_Click_ShowsError_WhenCompilerOrRuntimeNull()
        {
            AppForm form = new();
            MethodInfo runMethod = GetPrivateMethod(form, "RunButton_Click");
            TextBox commandPrompt = (TextBox)GetPrivateField(form, "CommandPrompt");
            RichTextBox commandLog = (RichTextBox)GetPrivateField(form, "CommandLog");

            commandPrompt.Text = "Some Input";
            commandLog.Clear();

            form.GetType().GetField("compiler", InstanceNonPublic)!.SetValue(form, null);
            form.GetType().GetField("runtime", InstanceNonPublic)!.SetValue(form, null);

            runMethod.Invoke(form, new object[] { null, EventArgs.Empty });

            string text = commandLog.Text;
            StringAssert.Contains(text, "Error: Compiler or Runtime not initialized.");
        }

        /// <summary>
        /// Verifies that executing multiple MoveTo commands via the Run button updates the canvas position correctly.
        /// </summary>
        [TestMethod]
        public void RunButton_Click_MultipleMoveto_UpdatesCanvasPosition()
        {
            AppForm form = new();
            MethodInfo runMethod = GetPrivateMethod(form, "RunButton_Click");
            TextBox commandPrompt = (TextBox)GetPrivateField(form, "CommandPrompt");
            RichTextBox commandLog = (RichTextBox)GetPrivateField(form, "CommandLog");
            AppCanvas canvas = (AppCanvas)GetPrivateField(form, "formCanvas");

            commandPrompt.Text = "moveto 10, 20\r\nmoveto 30, 40";
            commandLog.Clear();

            int initialX = canvas.Xpos;
            int initialY = canvas.Ypos;

            runMethod.Invoke(form, new object[] { null, EventArgs.Empty });

            string text = commandLog.Text;
            Assert.IsFalse(text.Contains("Error:"));

            StringAssert.Contains(text, "> moveto 10, 20");
            StringAssert.Contains(text, "> moveto 30, 40");

            Assert.AreNotEqual(initialX, canvas.Xpos);
            Assert.AreNotEqual(initialY, canvas.Ypos);
            Assert.AreEqual(30, canvas.Xpos);
            Assert.AreEqual(40, canvas.Ypos);
        }
    }
}
