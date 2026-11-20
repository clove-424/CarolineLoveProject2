using System.Runtime.CompilerServices;
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

        private readonly List<WordTracker> _allSubmittedWords;

        private readonly List<Button> _letterButtons;

        /// <summary>
        /// Initializes a new instance of a TextTwistForm.
        /// </summary>
        public TextTwistForm()
        {
            InitializeComponent();

            _appTimer = new();
            _appTimer.Interval = 1000;
            _appTimer.Tick += TimerOnTick;

            StartTimer();

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

            _allSubmittedWords = [];

            _validator = new();
            notValidWordLabel.Visible = false;
        }

        private void StartTimer()
        {
            ResetTimer();
            _appTimer.Start();
        }

        private void ResetTimer()
        {
            _currentTime = 120;
            timeRemainingLabel.Text = _currentTime.ToString();
        }

        private void TimerOnTick(object? sender, EventArgs e)
        {
            _currentTime--;
            timeRemainingLabel.Text = _currentTime.ToString();

            if (_currentTime <= 0)
            {
                _appTimer.Stop();
                ChangeStateOfLetterButtons(false);
            }
        }

        private void AddToTextBox(int index)
        {
            activeWordTextBox.Text += _letterGenerator.ChosenLetters?[index].ToString();
            _letterButtons[index].Enabled = false;
        }

        private void ChangeStateOfLetterButtons(bool state)
        {
            foreach (var button in _letterButtons)
            {
                button.Enabled = state;
            }
        }
        private void ClearTextBoxButton_Click(object sender, EventArgs e)
        {
            activeWordTextBox.Text = "";
            ChangeStateOfLetterButtons(true);
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
            try
            {
                var displayedWord = activeWordTextBox.Text;

                if (!string.IsNullOrEmpty(displayedWord))
                {
                    var wordInvalidReason = GetReasonWordIsInvalid(displayedWord);
                    AddWordToCollections(new WordTracker(displayedWord, wordInvalidReason));
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

        private string GetReasonWordIsInvalid(string word)
        {
            var wordInvalidReason = "";
            _validator.IterateOverLettersInDictionary(word);
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

        private void AddWordToCollections(WordTracker trackedWord)
        {
            _validator.Validate(trackedWord.Word);
            _allSubmittedWords.Add(trackedWord);

            notValidWordLabel.Visible = !_validator.IsValidWord;
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

        private void UpdateWordListBox()
        {
            wordTrackerListBox.DataSource = null;
            wordTrackerListBox.Items.Clear();
            wordTrackerListBox.DataSource = _allSubmittedWords;

            validWordsListBox.DataSource = null;
            validWordsListBox.Items.Clear();
            validWordsListBox.DataSource = _validator.SubmittedValidWords;
        }
    }
}
