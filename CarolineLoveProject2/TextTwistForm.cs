using CarolineLoveProject2.Model;
using CarolineLoveProject2.Word;
using Timer = System.Windows.Forms.Timer;

namespace CarolineLoveProject2
{
    /// <summary>
    /// The TextTwistForm that is the main form of the project and handles the logic for it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TextTwistForm : Form
    {
        private readonly Timer _appTimer;
        private int _currentTime;

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

            _appTimer = new();
            _appTimer.Interval = 1000;
            _appTimer.Tick += TimerOnTick;

            StartRound();
        }

        private void StartRound()
        {
            _validator.ValidWords.Clear();
            validWordsListBox.DataSource = null;
            validWordsListBox.Items.Clear();

            _validator.InvalidWords.Clear();
            invalidWordsListBox.DataSource = null;
            invalidWordsListBox.Items.Clear();

            CurrentlyPlayingGame(true);

            ResetTimer();
            _appTimer.Start();
        }

        private void ResetTimer()
        {
            _currentTime = 60;  //TODO: dynamically set time to whatever player chooses
            timeRemainingLabel.Text = _currentTime.ToString();
        }

        private void TimerOnTick(object? sender, EventArgs e)
        {
            _currentTime--;
            timeRemainingLabel.Text = _currentTime.ToString();

            if (_currentTime <= 0)
            {
                _appTimer.Stop();
                CurrentlyPlayingGame(false);
                UpdateWordListBox();
            }
        }

        private void CurrentlyPlayingGame(bool inPlay)
        {
            undoButton.Enabled = inPlay;
            submitButton.Enabled = inPlay;
            clearTextBoxButton.Enabled = inPlay;
            ChangeStateOfLetterButtons(inPlay);
        }

        private void ChangeStateOfLetterButtons(bool enabled)
        {
            foreach (var button in _letterButtons)
            {
                button.Enabled = enabled;
            }
        }

        private void Letter1Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 0;
            AddToTextBox(buttonIdx);
        }

        private void Letter2Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 1;
            AddToTextBox(buttonIdx);
        }

        private void Letter3Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 2;
            AddToTextBox(buttonIdx);
        }

        private void Letter4Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 3;
            AddToTextBox(buttonIdx);
        }

        private void Letter5Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 4;
            AddToTextBox(buttonIdx);
        }

        private void Letter6Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 5;
            AddToTextBox(buttonIdx);
        }

        private void Letter7Button_Click(object sender, EventArgs e)
        {
            const int buttonIdx = 6;
            AddToTextBox(buttonIdx);
        }

        private void AddToTextBox(int index)
        {
            activeWordTextBox.Text += _letterGenerator.ChosenLetters?[index].ToString();
            _letterButtons[index].Enabled = false;
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

        private void ClearTextBoxButton_Click(object sender, EventArgs e)
        {
            activeWordTextBox.Text = "";
            ChangeStateOfLetterButtons(true);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var displayedWord = activeWordTextBox.Text;

                if (!string.IsNullOrEmpty(displayedWord))
                {
                    ProcessWordData(displayedWord);
                }
            }
            catch (Exception)
            {
                notValidWordLabel.Text = "Please enter a valid word.";
                notValidWordLabel.Visible = true;
            }

            activeWordTextBox.Text = "";
            ChangeStateOfLetterButtons(true);
            UpdateWordListBox();
        }

        private void ProcessWordData(string word)
        {
            _validator.IterateOverLettersInDictionary(word);
            _validator.Validate(word);

            WordTracker wordToAdd;

            var wordInvalidReason = GetReasonWordInvalid(word);
            if (NotEligibleForPoints(word))
            {
                wordToAdd = new InvalidWordTracker(word, wordInvalidReason);
                _validator.InvalidWords.Add((InvalidWordTracker)wordToAdd);

                pointsEarnedLabel.Text = "";
            }
            else
            {
                wordToAdd = new ValidWordTracker(word);
                _validator.ValidWords.Add((ValidWordTracker)wordToAdd);

                var validWord = (ValidWordTracker)wordToAdd;
                pointsEarnedLabel.Text = $"+{(validWord.PointValue)}";
            }

            wordToAdd.TimeAdded = _currentTime;

            notValidWordLabel.Visible = !_validator.IsValidWord;
        }

        private string GetReasonWordInvalid(string word)
        {
            var wordInvalidReason = "";

            if (word.Length < 3)
            {
                notValidWordLabel.Text = "Word is not long enough.";
                wordInvalidReason = "Not Long Enough";
            }
            else if (!_validator.InDictionary)
            {
                notValidWordLabel.Text = "Not a valid word.";
                wordInvalidReason = "Not Found in Dictionary";
            }
            else if (_validator.WordInSubmittedWords(word))
            {
                notValidWordLabel.Text = "Already submitted that word, \nsubmit another one.";
                wordInvalidReason = "Duplicate Word";
            }

            return wordInvalidReason;
        }

        private bool NotEligibleForPoints(string word)
        {
            return !_validator.InDictionary || _validator.WordInSubmittedWords(word) || word.Length < 3;
        }

        private void UpdateWordListBox()
        {
            validWordsListBox.DataSource = null;
            validWordsListBox.Items.Clear();
            validWordsListBox.DataSource = _validator.ValidWords;

            invalidWordsListBox.DataSource = null;
            invalidWordsListBox.Items.Clear();
            invalidWordsListBox.DataSource = _validator.InvalidWords;
        }
    }
}
