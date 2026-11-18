using CarolineLoveProject2.Model;
using CarolineLoveProject2.Word;

namespace CarolineLoveProject2
{
    /// <summary>
    /// The TextTwistForm that is the main form of the project and handles the logic for it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TextTwistForm : Form
    {
        private readonly LetterGenerator _letterGenerator;

        private readonly Validator _validator;

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
            const int firstButtonIdx = 0;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter2Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 1;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter3Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 2;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter4Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 3;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter5Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 4;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter6Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 5;
            AddToTextBox(firstButtonIdx);
        }

        private void Letter7Button_Click(object sender, EventArgs e)
        {
            const int firstButtonIdx = 6;
            AddToTextBox(firstButtonIdx);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var displayedWord = activeWordTextBox.Text;
            try
            {
                if (_validator.WordInSubmittedWords(displayedWord))
                {
                    notValidWordLabel.Text = "Already submitted that word, submit another.";
                }
                else
                {
                    notValidWordLabel.Text = "Not a valid word.";
                }
                _validator.Validate(displayedWord);
                notValidWordLabel.Visible = !_validator.IsValidWord;
            }
            catch (Exception)
            {
                notValidWordLabel.Text = "Please enter a valid word.";
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
