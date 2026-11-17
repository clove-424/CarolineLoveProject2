using CarolineLoveProject2.Dictionary;
using CarolineLoveProject2.Model;

namespace CarolineLoveProject2
{
    /// <summary>
    /// The TextTwistForm that is the main form of the project and handles the logic for it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TextTwistForm : Form
    {
        private readonly LetterGenerator _letterGenerator;

        private readonly WordValidator _validator;

        private readonly List<Button> _letterButtons;

        /// <summary>
        /// Initializes a new instance of a TextTwistForm.
        /// </summary>
        public TextTwistForm()
        {
            InitializeComponent();

            _letterGenerator = new LetterGenerator();
            _letterGenerator.PopulateChosenLetters();

            _letterButtons =
            [
                letter1Button, letter2Button, letter3Button, letter4Button, 
                letter5Button, letter6Button, letter7Button
            ];

            for (var i = 0; i < _letterButtons.Count; i++)
            {
                var button = _letterButtons[i];
                var letter = _letterGenerator.ChosenLetters?[i];
                button.Text = letter.ToString();
            }

            _validator = new();
            notValidWordLabel.Visible = false;
        }

        private void AddToTextBox(int index)
        {
            activeWordTextBox.Text += _letterGenerator.ChosenLetters?[index].ToString();
            _letterButtons[index].Enabled = false;
        }

        private void EnableAllLetterButtons()
        {
            foreach (var button in _letterButtons)
            {
                button.Enabled = true;
            }
        }
        private void ClearTextBoxButton_Click(object sender, EventArgs e)
        {
            activeWordTextBox.Text = "";
            EnableAllLetterButtons();
        }

        private void Letter1Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(0);
        }

        private void Letter2Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(1);
        }

        private void Letter3Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(2);
        }

        private void Letter4Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(3);
        }

        private void Letter5Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(4);
        }

        private void Letter6Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(5);
        }

        private void Letter7Button_Click(object sender, EventArgs e)
        {
            AddToTextBox(6);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                _validator.Validate(activeWordTextBox.Text);
                if (!_validator.IsValidWord)
                {
                    notValidWordLabel.Visible = true;
                }
                else
                {
                    notValidWordLabel.Visible = false;
                }

                notValidWordLabel.Text = "Not a valid word";
            }
            catch (Exception)
            {
                notValidWordLabel.Text = "Please enter a valid word";
                notValidWordLabel.Visible = true;
            }

            activeWordTextBox.Text = "";
            EnableAllLetterButtons();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            var displayedText = activeWordTextBox.Text;

            if (!string.IsNullOrEmpty(displayedText))
            {
                var lastChar = displayedText[^1].ToString();
                var newText = displayedText.Replace(lastChar, "");

                activeWordTextBox.Text = newText;
                foreach (var button in _letterButtons)
                {
                    if (lastChar.Equals(button.Text))
                    {
                        button.Enabled = true;
                    }
                }
            }
        }
    }
}
