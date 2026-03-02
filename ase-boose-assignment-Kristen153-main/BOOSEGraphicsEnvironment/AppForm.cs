using BOOSE;
using System.Diagnostics;

namespace BOOSEGraphicsEnvironment
{
    /// <summary>
    /// Main form for the BOOSE graphics environment application.
    /// Handles front facing user interactions, delegates command parsing and execution to the Factory, and updates the canvas and command log.
    /// </summary>
    public partial class AppForm : Form
    {
        private const int DefaultWidth = 1000;
        private const int DefaultHeight = 1800;

        private AppCanvas formCanvas;
        private Bitmap formBitmap;
        private IParser compiler;
        private StoredProgram runtime;
        private AppCommandFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppForm"/> class,
        /// setting up the canvas, parser, runtime, and command factory.
        /// </summary>
        public AppForm()
        {
            InitializeComponent();

            Debug.WriteLine(AboutBOOSE.about());

            formCanvas = new AppCanvas(DefaultWidth, DefaultHeight);
            formBitmap = (Bitmap)formCanvas.getBitmap();
            Debug.WriteLine($"AppForm initialized with canvas size {DefaultWidth}x{DefaultHeight}");

            factory = new AppCommandFactory();
            runtime = new StoredProgram(formCanvas);
            compiler = new Parser(factory, runtime);
        }

        /// <summary>
        /// Refreshes the canvas display after the form loads.
        /// </summary>
        private void GraphicsForm_Load(object sender, EventArgs e)
        {
            if (CommandLog != null)
                AppendCommandLog(new[] { AboutBOOSE.about() });

            formBitmap = (Bitmap)formCanvas.getBitmap();
            CanvasDisplay.Refresh();
            Debug.WriteLine("GraphicsForm loaded and CanvasDisplay refreshed");
        }

        /// <summary>
        /// Draws the current canvas bitmap.
        /// </summary>
        private void CanvasDisplay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(formBitmap, 0, 0);
        }

        /// <summary>
        /// Handles the Run button click.
        /// Sends the user's input to the Parser, which delegates to the Factory.
        /// Updates the canvas and command log.
        /// </summary>
        private void RunButton_Click(object sender, EventArgs e)
        {
            string input = CommandPrompt?.Text ?? string.Empty;
            string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None); 

            if (lines.Length == 0)
            {
                Debug.WriteLine("RunButton clicked but input is empty");
                return;
            }

            if (compiler == null || runtime == null)
            {
                AppendCommandLog(new[] { "Error: Compiler or Runtime not initialized." });
                Debug.WriteLine("Compiler or Runtime not initialized");
                return;
            }

            try
            {
                runtime = new StoredProgram(formCanvas); //temporary fix until i find solutiom
                compiler = new Parser(factory, runtime); //temporary fix until i find solutiom

                Debug.WriteLine("Parsing program...");
                compiler.ParseProgram(input);

                Debug.WriteLine("Running program...");
                runtime.Run();

                AppendCommandLog(lines);
                Debug.WriteLine("Program executed successfully");
            }
            catch (Exception ex) when (ex is CommandException || ex is FactoryException)
            {
                AppendCommandLog(new[] { $"Error: {ex.Message}" });
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                AppendCommandLog(new[] { $"Unexpected Error: {ex.Message}" });
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                CanvasDisplay.Refresh();            
                Debug.WriteLine("CanvasDisplay refreshed after program run");
            }
        }

        /// <summary>
        /// Appends the specified lines to the command log.
        /// </summary>
        private void AppendCommandLog(string[] lines)
        {
            if (CommandLog == null || lines == null || lines.Length == 0)
                return;

            try
            {
                foreach (string line in lines)
                    CommandLog.AppendText($"> {line}{Environment.NewLine}");

                CommandLog.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error appending to command log: {ex.Message}");
            }
        }
    }
}
