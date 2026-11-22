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
            pointsEarnedLabel = new Label();
            timeRemainingLabel = new Label();
            roundSummaryTextBox = new RichTextBox();
            textTwistMainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importDataMenuItem = new ToolStripMenuItem();
            exportStatsMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            changeTimeMenuItem = new ToolStripMenuItem();
            resetLeaderboardToolStripMenuItem = new ToolStripMenuItem();
            newGameMenuItem = new ToolStripMenuItem();
            startButton = new Button();
            textTwistButton = new Button();
            leaderboardLabel = new Label();
            summaryLabel = new Label();
            leaderboardListBox = new ListBox();
            leaderboardHeaderTextBox = new TextBox();
            textTwistMainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // letter1Button
            // 
            letter1Button.Location = new Point(96, 142);
            letter1Button.Name = "letter1Button";
            letter1Button.Size = new Size(26, 23);
            letter1Button.TabIndex = 8;
            letter1Button.UseVisualStyleBackColor = true;
            letter1Button.Click += Letter1Button_Click;
            // 
            // letter2Button
            // 
            letter2Button.Location = new Point(128, 142);
            letter2Button.Name = "letter2Button";
            letter2Button.Size = new Size(26, 23);
            letter2Button.TabIndex = 9;
            letter2Button.UseVisualStyleBackColor = true;
            letter2Button.Click += Letter2Button_Click;
            // 
            // letter3Button
            // 
            letter3Button.Location = new Point(160, 142);
            letter3Button.Name = "letter3Button";
            letter3Button.Size = new Size(26, 23);
            letter3Button.TabIndex = 10;
            letter3Button.UseVisualStyleBackColor = true;
            letter3Button.Click += Letter3Button_Click;
            // 
            // letter4Button
            // 
            letter4Button.Location = new Point(192, 142);
            letter4Button.Name = "letter4Button";
            letter4Button.Size = new Size(26, 23);
            letter4Button.TabIndex = 11;
            letter4Button.UseVisualStyleBackColor = true;
            letter4Button.Click += Letter4Button_Click;
            // 
            // letter5Button
            // 
            letter5Button.Location = new Point(224, 142);
            letter5Button.Name = "letter5Button";
            letter5Button.Size = new Size(26, 23);
            letter5Button.TabIndex = 12;
            letter5Button.UseVisualStyleBackColor = true;
            letter5Button.Click += Letter5Button_Click;
            // 
            // letter6Button
            // 
            letter6Button.Location = new Point(255, 142);
            letter6Button.Name = "letter6Button";
            letter6Button.Size = new Size(26, 23);
            letter6Button.TabIndex = 13;
            letter6Button.UseVisualStyleBackColor = true;
            letter6Button.Click += Letter6Button_Click;
            // 
            // letter7Button
            // 
            letter7Button.Location = new Point(288, 142);
            letter7Button.Name = "letter7Button";
            letter7Button.Size = new Size(26, 23);
            letter7Button.TabIndex = 14;
            letter7Button.UseVisualStyleBackColor = true;
            letter7Button.Click += Letter7Button_Click;
            // 
            // activeWordTextBox
            // 
            activeWordTextBox.Location = new Point(94, 117);
            activeWordTextBox.Name = "activeWordTextBox";
            activeWordTextBox.ReadOnly = true;
            activeWordTextBox.Size = new Size(154, 23);
            activeWordTextBox.TabIndex = 5;
            activeWordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // clearTextBoxButton
            // 
            clearTextBoxButton.Location = new Point(128, 186);
            clearTextBoxButton.Name = "clearTextBoxButton";
            clearTextBoxButton.Size = new Size(66, 23);
            clearTextBoxButton.TabIndex = 15;
            clearTextBoxButton.Text = "Clear";
            clearTextBoxButton.UseVisualStyleBackColor = true;
            clearTextBoxButton.Click += ClearTextBoxButton_Click;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(217, 186);
            submitButton.Margin = new Padding(3, 2, 3, 2);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(66, 22);
            submitButton.TabIndex = 16;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;
            // 
            // notValidWordLabel
            // 
            notValidWordLabel.ForeColor = Color.Red;
            notValidWordLabel.Location = new Point(94, 90);
            notValidWordLabel.Name = "notValidWordLabel";
            notValidWordLabel.Size = new Size(172, 24);
            notValidWordLabel.TabIndex = 3;
            notValidWordLabel.Text = "Not a valid word.";
            notValidWordLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // undoButton
            // 
            undoButton.Location = new Point(255, 114);
            undoButton.Margin = new Padding(3, 2, 3, 2);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(58, 22);
            undoButton.TabIndex = 6;
            undoButton.Text = "Undo";
            undoButton.UseVisualStyleBackColor = true;
            undoButton.Click += UndoButton_Click;
            // 
            // pointsEarnedLabel
            // 
            pointsEarnedLabel.ForeColor = Color.FromArgb(0, 192, 0);
            pointsEarnedLabel.Location = new Point(271, 90);
            pointsEarnedLabel.Name = "pointsEarnedLabel";
            pointsEarnedLabel.Size = new Size(42, 19);
            pointsEarnedLabel.TabIndex = 4;
            pointsEarnedLabel.Text = "\r\n";
            pointsEarnedLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeRemainingLabel
            // 
            timeRemainingLabel.Location = new Point(271, 64);
            timeRemainingLabel.Name = "timeRemainingLabel";
            timeRemainingLabel.Size = new Size(42, 19);
            timeRemainingLabel.TabIndex = 2;
            timeRemainingLabel.Text = "60";
            timeRemainingLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // roundSummaryTextBox
            // 
            roundSummaryTextBox.Location = new Point(376, 48);
            roundSummaryTextBox.Margin = new Padding(3, 2, 3, 2);
            roundSummaryTextBox.Name = "roundSummaryTextBox";
            roundSummaryTextBox.ReadOnly = true;
            roundSummaryTextBox.Size = new Size(170, 182);
            roundSummaryTextBox.TabIndex = 18;
            roundSummaryTextBox.Text = "";
            // 
            // textTwistMainMenuStrip
            // 
            textTwistMainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem });
            textTwistMainMenuStrip.Location = new Point(0, 0);
            textTwistMainMenuStrip.Name = "textTwistMainMenuStrip";
            textTwistMainMenuStrip.Size = new Size(645, 24);
            textTwistMainMenuStrip.TabIndex = 0;
            textTwistMainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importDataMenuItem, exportStatsMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importDataMenuItem
            // 
            importDataMenuItem.Name = "importDataMenuItem";
            importDataMenuItem.Size = new Size(137, 22);
            importDataMenuItem.Text = "Import Data";
            importDataMenuItem.Click += ImportDataMenuItem_Click;
            // 
            // exportStatsMenuItem
            // 
            exportStatsMenuItem.Enabled = false;
            exportStatsMenuItem.Name = "exportStatsMenuItem";
            exportStatsMenuItem.Size = new Size(137, 22);
            exportStatsMenuItem.Text = "Export Stats";
            exportStatsMenuItem.Click += ExportStatsMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(137, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeTimeMenuItem, resetLeaderboardToolStripMenuItem, newGameMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // changeTimeMenuItem
            // 
            changeTimeMenuItem.Name = "changeTimeMenuItem";
            changeTimeMenuItem.Size = new Size(186, 22);
            changeTimeMenuItem.Text = "Set Countdown Time";
            changeTimeMenuItem.Click += SetTimeMenuItem_Click;
            // 
            // resetLeaderboardToolStripMenuItem
            // 
            resetLeaderboardToolStripMenuItem.Name = "resetLeaderboardToolStripMenuItem";
            resetLeaderboardToolStripMenuItem.Size = new Size(186, 22);
            resetLeaderboardToolStripMenuItem.Text = "Reset Leaderboard";
            resetLeaderboardToolStripMenuItem.Click += ResetLeaderboardMenuItem_Click;
            // 
            // newGameMenuItem
            // 
            newGameMenuItem.Name = "newGameMenuItem";
            newGameMenuItem.Size = new Size(186, 22);
            newGameMenuItem.Text = "New Game";
            newGameMenuItem.Click += NewGameMenuItem_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(217, 62);
            startButton.Name = "startButton";
            startButton.Size = new Size(48, 23);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // textTwistButton
            // 
            textTwistButton.Location = new Point(94, 62);
            textTwistButton.Name = "textTwistButton";
            textTwistButton.Size = new Size(120, 23);
            textTwistButton.TabIndex = 7;
            textTwistButton.Text = "Text Twist";
            textTwistButton.UseVisualStyleBackColor = true;
            textTwistButton.Click += TextTwistButton_Click;
            // 
            // leaderboardLabel
            // 
            leaderboardLabel.AutoSize = true;
            leaderboardLabel.Location = new Point(288, 240);
            leaderboardLabel.Name = "leaderboardLabel";
            leaderboardLabel.Size = new Size(73, 15);
            leaderboardLabel.TabIndex = 19;
            leaderboardLabel.Text = "Leaderboard";
            // 
            // summaryLabel
            // 
            summaryLabel.AutoSize = true;
            summaryLabel.Location = new Point(376, 31);
            summaryLabel.Name = "summaryLabel";
            summaryLabel.Size = new Size(36, 15);
            summaryLabel.TabIndex = 17;
            summaryLabel.Text = "Score";
            // 
            // leaderboardListBox
            // 
            leaderboardListBox.FormattingEnabled = true;
            leaderboardListBox.Location = new Point(160, 279);
            leaderboardListBox.Name = "leaderboardListBox";
            leaderboardListBox.Size = new Size(326, 169);
            leaderboardListBox.TabIndex = 21;
            // 
            // leaderboardHeaderTextBox
            // 
            leaderboardHeaderTextBox.Location = new Point(160, 255);
            leaderboardHeaderTextBox.Name = "leaderboardHeaderTextBox";
            leaderboardHeaderTextBox.ReadOnly = true;
            leaderboardHeaderTextBox.Size = new Size(326, 23);
            leaderboardHeaderTextBox.TabIndex = 20;
            // 
            // TextTwistForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 460);
            Controls.Add(leaderboardHeaderTextBox);
            Controls.Add(leaderboardListBox);
            Controls.Add(summaryLabel);
            Controls.Add(leaderboardLabel);
            Controls.Add(textTwistButton);
            Controls.Add(startButton);
            Controls.Add(roundSummaryTextBox);
            Controls.Add(timeRemainingLabel);
            Controls.Add(pointsEarnedLabel);
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
            Controls.Add(textTwistMainMenuStrip);
            MainMenuStrip = textTwistMainMenuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "TextTwistForm";
            Text = "Text Twist by Love";
            textTwistMainMenuStrip.ResumeLayout(false);
            textTwistMainMenuStrip.PerformLayout();
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
        private Label pointsEarnedLabel;
        private Label timeRemainingLabel;
        private RichTextBox roundSummaryTextBox;
        private MenuStrip textTwistMainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private Button startButton;
        private ToolStripMenuItem changeTimeMenuItem;
        private ToolStripMenuItem exportStatsMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button textTwistButton;
        private ToolStripMenuItem newGameMenuItem;
        private Label leaderboardLabel;
        private Label summaryLabel;
        private ListBox leaderboardListBox;
        private TextBox leaderboardHeaderTextBox;
        private ToolStripMenuItem resetLeaderboardToolStripMenuItem;
        private ToolStripMenuItem importDataMenuItem;
    }
}
