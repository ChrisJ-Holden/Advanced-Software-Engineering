namespace BOOSEGraphicsEnvironment
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            CommandPrompt = new TextBox();
            RunButton = new Button();
            CommandLog = new RichTextBox();
            CanvasDisplay = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CanvasDisplay).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(CanvasDisplay);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(CommandLog);
            splitContainer2.Size = new Size(266, 450);
            splitContainer2.SplitterDistance = 88;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(CommandPrompt);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(RunButton);
            splitContainer3.Size = new Size(266, 88);
            splitContainer3.SplitterDistance = 59;
            splitContainer3.TabIndex = 0;
            // 
            // CommandPrompt
            // 
            CommandPrompt.Dock = DockStyle.Fill;
            CommandPrompt.Location = new Point(0, 0);
            CommandPrompt.Multiline = true;
            CommandPrompt.Name = "CommandPrompt";
            CommandPrompt.Size = new Size(266, 59);
            CommandPrompt.TabIndex = 0;
            // 
            // RunButton
            // 
            RunButton.Dock = DockStyle.Fill;
            RunButton.Location = new Point(0, 0);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(266, 25);
            RunButton.TabIndex = 0;
            RunButton.Text = "Run Command";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // CommandLog
            // 
            CommandLog.Dock = DockStyle.Fill;
            CommandLog.Location = new Point(0, 0);
            CommandLog.Name = "CommandLog";
            CommandLog.ReadOnly = true;
            CommandLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            CommandLog.Size = new Size(266, 358);
            CommandLog.TabIndex = 0;
            CommandLog.Text = "";
            // 
            // CanvasDisplay
            // 
            CanvasDisplay.Dock = DockStyle.Fill;
            CanvasDisplay.Location = new Point(0, 0);
            CanvasDisplay.Name = "CanvasDisplay";
            CanvasDisplay.Size = new Size(530, 450);
            CanvasDisplay.TabIndex = 0;
            CanvasDisplay.TabStop = false;
            CanvasDisplay.Paint += CanvasDisplay_Paint;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            DoubleBuffered = true;
            Name = "AppForm";
            Load += GraphicsForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CanvasDisplay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private PictureBox CanvasDisplay;
        private RichTextBox CommandLog;
        private SplitContainer splitContainer3;
        private TextBox CommandPrompt;
        private Button RunButton;
    }
}
