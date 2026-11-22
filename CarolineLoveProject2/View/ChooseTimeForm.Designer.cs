namespace CarolineLoveProject2.View
{
    partial class ChooseTimeForm
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
            oneMinuteButton = new Button();
            twoMinuteButton = new Button();
            threeMinuteButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // oneMinuteButton
            // 
            oneMinuteButton.Location = new Point(52, 82);
            oneMinuteButton.Name = "oneMinuteButton";
            oneMinuteButton.Size = new Size(69, 23);
            oneMinuteButton.TabIndex = 0;
            oneMinuteButton.Text = "1 Minute";
            oneMinuteButton.UseVisualStyleBackColor = true;
            oneMinuteButton.Click += OneMinuteButton_Click;
            // 
            // twoMinuteButton
            // 
            twoMinuteButton.Location = new Point(127, 82);
            twoMinuteButton.Name = "twoMinuteButton";
            twoMinuteButton.Size = new Size(69, 23);
            twoMinuteButton.TabIndex = 1;
            twoMinuteButton.Text = "2 Minutes";
            twoMinuteButton.UseVisualStyleBackColor = true;
            twoMinuteButton.Click += TwoMinuteButton_Click;
            // 
            // threeMinuteButton
            // 
            threeMinuteButton.Location = new Point(202, 82);
            threeMinuteButton.Name = "threeMinuteButton";
            threeMinuteButton.Size = new Size(69, 23);
            threeMinuteButton.TabIndex = 2;
            threeMinuteButton.Text = "3 Minutes";
            threeMinuteButton.UseVisualStyleBackColor = true;
            threeMinuteButton.Click += ThreeMinuteButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 50);
            label1.Name = "label1";
            label1.Size = new Size(176, 15);
            label1.TabIndex = 3;
            label1.Text = "How long should this round be?";
            // 
            // ChooseTimeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 160);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(threeMinuteButton);
            Controls.Add(twoMinuteButton);
            Controls.Add(oneMinuteButton);
            Name = "ChooseTimeForm";
            Text = "Choose Starting Time";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button oneMinuteButton;
        private Button twoMinuteButton;
        private Button threeMinuteButton;
        private Label label1;
    }
}