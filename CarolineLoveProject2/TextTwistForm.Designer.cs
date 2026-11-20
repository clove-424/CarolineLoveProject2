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
            letter1Button = new Button();
            letter2Button = new Button();
            letter3Button = new Button();
            letter4Button = new Button();
            letter5Button = new Button();
            letter6Button = new Button();
            letter7Button = new Button();
            activeWordTextBox = new TextBox();
            clearTextBoxButton = new Button();
            submitButton = new Button();
            notValidWordLabel = new Label();
            undoButton = new Button();
            wordTrackerListBox = new ListBox();
            validWordsListBox = new ListBox();
            pointsEarnedLabel = new Label();
            timeRemainingLabel = new Label();
            SuspendLayout();
            // 
            // letter1Button
            // 
            letter1Button.Location = new Point(458, 206);
            letter1Button.Margin = new Padding(3, 4, 3, 4);
            letter1Button.Name = "letter1Button";
            letter1Button.Size = new Size(30, 31);
            letter1Button.TabIndex = 2;
            letter1Button.UseVisualStyleBackColor = true;
            letter1Button.Click += Letter1Button_Click;
            // 
            // letter2Button
            // 
            letter2Button.Location = new Point(494, 206);
            letter2Button.Margin = new Padding(3, 4, 3, 4);
            letter2Button.Name = "letter2Button";
            letter2Button.Size = new Size(30, 31);
            letter2Button.TabIndex = 3;
            letter2Button.UseVisualStyleBackColor = true;
            letter2Button.Click += Letter2Button_Click;
            // 
            // letter3Button
            // 
            letter3Button.Location = new Point(531, 206);
            letter3Button.Margin = new Padding(3, 4, 3, 4);
            letter3Button.Name = "letter3Button";
            letter3Button.Size = new Size(30, 31);
            letter3Button.TabIndex = 4;
            letter3Button.UseVisualStyleBackColor = true;
            letter3Button.Click += Letter3Button_Click;
            // 
            // letter4Button
            // 
            letter4Button.Location = new Point(567, 206);
            letter4Button.Margin = new Padding(3, 4, 3, 4);
            letter4Button.Name = "letter4Button";
            letter4Button.Size = new Size(30, 31);
            letter4Button.TabIndex = 5;
            letter4Button.UseVisualStyleBackColor = true;
            letter4Button.Click += Letter4Button_Click;
            // 
            // letter5Button
            // 
            letter5Button.Location = new Point(604, 206);
            letter5Button.Margin = new Padding(3, 4, 3, 4);
            letter5Button.Name = "letter5Button";
            letter5Button.Size = new Size(30, 31);
            letter5Button.TabIndex = 6;
            letter5Button.UseVisualStyleBackColor = true;
            letter5Button.Click += Letter5Button_Click;
            // 
            // letter6Button
            // 
            letter6Button.Location = new Point(640, 206);
            letter6Button.Margin = new Padding(3, 4, 3, 4);
            letter6Button.Name = "letter6Button";
            letter6Button.Size = new Size(30, 31);
            letter6Button.TabIndex = 7;
            letter6Button.UseVisualStyleBackColor = true;
            letter6Button.Click += Letter6Button_Click;
            // 
            // letter7Button
            // 
            letter7Button.Location = new Point(677, 206);
            letter7Button.Margin = new Padding(3, 4, 3, 4);
            letter7Button.Name = "letter7Button";
            letter7Button.Size = new Size(30, 31);
            letter7Button.TabIndex = 8;
            letter7Button.UseVisualStyleBackColor = true;
            letter7Button.Click += Letter7Button_Click;
            // 
            // activeWordTextBox
            // 
            activeWordTextBox.Location = new Point(455, 172);
            activeWordTextBox.Margin = new Padding(3, 4, 3, 4);
            activeWordTextBox.Name = "activeWordTextBox";
            activeWordTextBox.ReadOnly = true;
            activeWordTextBox.Size = new Size(175, 27);
            activeWordTextBox.TabIndex = 1;
            activeWordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // clearTextBoxButton
            // 
            clearTextBoxButton.Location = new Point(494, 265);
            clearTextBoxButton.Margin = new Padding(3, 4, 3, 4);
            clearTextBoxButton.Name = "clearTextBoxButton";
            clearTextBoxButton.Size = new Size(75, 31);
            clearTextBoxButton.TabIndex = 9;
            clearTextBoxButton.Text = "Clear";
            clearTextBoxButton.UseVisualStyleBackColor = true;
            clearTextBoxButton.Click += ClearTextBoxButton_Click;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(596, 265);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 29);
            submitButton.TabIndex = 10;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;
            // 
            // notValidWordLabel
            // 
            notValidWordLabel.ForeColor = Color.Red;
            notValidWordLabel.Location = new Point(455, 101);
            notValidWordLabel.Name = "notValidWordLabel";
            notValidWordLabel.Size = new Size(197, 67);
            notValidWordLabel.TabIndex = 11;
            notValidWordLabel.Text = "Not a valid word.";
            notValidWordLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // undoButton
            // 
            undoButton.Location = new Point(640, 169);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(66, 29);
            undoButton.TabIndex = 12;
            undoButton.Text = "Undo";
            undoButton.UseVisualStyleBackColor = true;
            undoButton.Click += UndoButton_Click;
            // 
            // wordTrackerListBox
            // 
            wordTrackerListBox.FormattingEnabled = true;
            wordTrackerListBox.Location = new Point(747, 71);
            wordTrackerListBox.Name = "wordTrackerListBox";
            wordTrackerListBox.Size = new Size(384, 344);
            wordTrackerListBox.TabIndex = 13;
            // 
            // validWordsListBox
            // 
            validWordsListBox.FormattingEnabled = true;
            validWordsListBox.Location = new Point(33, 71);
            validWordsListBox.Name = "validWordsListBox";
            validWordsListBox.Size = new Size(384, 344);
            validWordsListBox.TabIndex = 14;
            // 
            // pointsEarnedLabel
            // 
            pointsEarnedLabel.ForeColor = Color.FromArgb(0, 192, 0);
            pointsEarnedLabel.Location = new Point(658, 136);
            pointsEarnedLabel.Name = "pointsEarnedLabel";
            pointsEarnedLabel.Size = new Size(48, 25);
            pointsEarnedLabel.TabIndex = 15;
            pointsEarnedLabel.Text = "\r\n";
            pointsEarnedLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeRemainingLabel
            // 
            timeRemainingLabel.Location = new Point(644, 101);
            timeRemainingLabel.Name = "timeRemainingLabel";
            timeRemainingLabel.Size = new Size(62, 25);
            timeRemainingLabel.TabIndex = 16;
            timeRemainingLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TextTwistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 451);
            Controls.Add(timeRemainingLabel);
            Controls.Add(pointsEarnedLabel);
            Controls.Add(validWordsListBox);
            Controls.Add(wordTrackerListBox);
            Controls.Add(undoButton);
            Controls.Add(notValidWordLabel);
            Controls.Add(submitButton);
            Controls.Add(clearTextBoxButton);
            Controls.Add(activeWordTextBox);
            Controls.Add(letter7Button);
            Controls.Add(letter6Button);
            Controls.Add(letter5Button);
            Controls.Add(letter4Button);
            Controls.Add(letter3Button);
            Controls.Add(letter2Button);
            Controls.Add(letter1Button);
            Name = "TextTwistForm";
            Text = "Text Twist by Love";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button letter1Button;
        private Button letter2Button;
        private Button letter3Button;
        private Button letter4Button;
        private Button letter5Button;
        private Button letter6Button;
        private Button letter7Button;
        private TextBox activeWordTextBox;
        private Button clearTextBoxButton;
        private Button submitButton;
        private Label notValidWordLabel;
        private Button undoButton;
        private ListBox wordTrackerListBox;
        private ListBox validWordsListBox;
        private Label pointsEarnedLabel;
        private Label timeRemainingLabel;
    }
}
