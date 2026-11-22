namespace CarolineLoveProject2.View
{
    partial class NameInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            submitButton = new Button();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(125, 128);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 1;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(89, 99);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(145, 23);
            nameTextBox.TabIndex = 0;
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // nameLabel
            // 
            nameLabel.Location = new Point(59, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(212, 87);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Enter your name or initials";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NameInputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 176);
            ControlBox = false;
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(submitButton);
            Name = "NameInputForm";
            Text = "Name Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox nameTextBox;
        private Label nameLabel;
    }
}