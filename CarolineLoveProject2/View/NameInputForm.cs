namespace CarolineLoveProject2.View
{
    /// <summary>
    /// The NameInputForm class that has properties for player's names to be entered.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NameInputForm : Form
    {
        /// <summary>
        /// The NameInput property.
        /// </summary>
        /// <value>
        /// The name the player enters.
        /// </value>
        public string? NameInput { get; private set; }

        /// <summary>
        /// Initializes a new instance of a NameInputForm.
        /// </summary>
        public NameInputForm()
        {
            InitializeComponent();

            nameLabel.Text = "Congratulations! \nYou got the high score! \nEnter your name to appear on the leaderboard.";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            NameInput = nameTextBox.Text;

            if (string.IsNullOrEmpty(NameInput))
            {
                var result = MessageBox.Show("Are you sure? You won't appear on the leaderboard, but your stats can still be saved.", "Warning", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    NameInput = "";
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}
