namespace CarolineLoveProject2
{
    partial class TextTwistForm
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
            chosenLettersLabel = new Label();
            SuspendLayout();
            // 
            // chosenLettersLabel
            // 
            chosenLettersLabel.AutoSize = true;
            chosenLettersLabel.Location = new Point(213, 215);
            chosenLettersLabel.Name = "chosenLettersLabel";
            chosenLettersLabel.Size = new Size(50, 20);
            chosenLettersLabel.TabIndex = 0;
            chosenLettersLabel.Text = "label1";
            // 
            // TextTwistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chosenLettersLabel);
            Name = "TextTwistForm";
            Text = "Text Twist by Love";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label chosenLettersLabel;
    }
}
