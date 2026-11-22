using CarolineLoveProject2.LINQController;
using CarolineLoveProject2.Model;
using CarolineLoveProject2.View;
using CarolineLoveProject2.Word;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Linq;
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
        private int _startTime;
        private int _currentTime;
        private int _roundNumber;

        private readonly LetterGenerator _letterGenerator;
        private readonly Validator _validator;

        private readonly List<Round> _rounds;
        private List<HighestScoreRound> _highScoreBoard;

        private bool _inPlay;

        private readonly List<Button> _letterButtons;

        /// <summary>
        /// Initializes a new instance of a TextTwistForm.
        /// </summary>
        public TextTwistForm()
        {
            InitializeComponent();

            leaderboardHeaderTextBox.Text = "Player\t\tScore\t\tMaximum Time";

            _letterGenerator = new LetterGenerator();
            _letterButtons =
            [
                letter1Button, letter2Button, letter3Button, letter4Button,
                letter5Button, letter6Button, letter7Button
            ];

            _validator = new();

            _rounds = [];
            _highScoreBoard = [];

            _appTimer = new();
            _appTimer.Interval = 1000;
            _appTimer.Tick += TimerOnTick;

            ResetGameState();

            _inPlay = false;
            _startTime = 60;
            _currentTime = _startTime;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "New")
            {
                _appTimer.Stop();
                var result = MessageBox.Show("Do you want a new puzzle?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    PromptPlayerForRoundTimeAndStart();
                }
                else
                {
                    _appTimer.Start();
                }
            }
            else
            {
                _currentTime = _startTime;
                StartRound(_currentTime);
            }
        }

        private void PromptPlayerForRoundTimeAndStart()
        {
            var chooseTimeForm = new ChooseTimeForm(_letterGenerator);
            chooseTimeForm.ShowDialog();

            _startTime = chooseTimeForm.StartTime;
            if (_startTime > 0)
            {
                AssignLettersToButtons(_letterGenerator.ChosenLetters);

                _currentTime = _startTime;
                StartRound(_currentTime);
            }
        }

        private void SetTimeMenuItem_Click(object sender, EventArgs e)
        {
            PromptPlayerForRoundTimeAndStart();
        }

        private void StartRound(int time)
        {
            startButton.Text = "New";

            _validator.ValidWords.Clear();
            _validator.InvalidWords.Clear();

            if (_roundNumber > 1 || _inPlay)
            {
                _letterGenerator.PopulateChosenLetters();
                AssignLettersToButtons(_letterGenerator.ChosenLetters);
            }

            activeWordTextBox.Text = "";
            pointsEarnedLabel.Text = "";
            notValidWordLabel.Text = "";
            CurrentlyPlayingGame(true);

            timeRemainingLabel.Text = time.ToString();
            _appTimer.Start();
        }

        private void TimerOnTick(object? sender, EventArgs e)
        {
            _currentTime--;
            timeRemainingLabel.Text = _currentTime.ToString();

            if (_currentTime <= 0)
            {
                _appTimer.Stop();
                CurrentlyPlayingGame(false);

                UpdateHighScoreBoard();
                PopulateRoundSummaryTextbox();

                exportStatsMenuItem.Enabled = _rounds.Count > 0;

                _roundNumber++;

                startButton.Text = "Start";
            }
        }

        private void UpdateHighScoreBoard()
        {
            var player = new Round(_validator)
            {
                MaxTime = _startTime,
                Score = CalculateRoundScore(),
                RoundNumber = _roundNumber
            };

            if (IsHighScore(player.Score) && player.Score > 0)
            {
                var nameInput = new NameInputForm();
                nameInput.ShowDialog();

                var name = nameInput.NameInput;
                AddPlayerToLeaderBoard(player, name);
                
                _highScoreBoard.Sort(new RoundTimeAndScoreComparer());

                leaderboardListBox.DataSource = null;
                leaderboardListBox.Items.Clear();
                leaderboardListBox.DataSource = _highScoreBoard;
            }

            _rounds.Add(player);
            player.SaveSubmittedWords();
        }

        private void AddPlayerToLeaderBoard(Round player, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                player = new HighestScoreRound(_validator)
                {
                    PlayerName = name,
                    Score = player.Score,
                    MaxTime = player.MaxTime,
                    RoundNumber = _roundNumber
                };

                _highScoreBoard.Add((HighestScoreRound)player);
            }
        }

        private bool IsHighScore(int scoreToCheck)
        {
            var isHighScore = false;

            var leaderboard = (from player in _highScoreBoard select player.Score).ToList();
            if (leaderboard.Count <= 0 || _rounds.Count <= 0) 
            {
                isHighScore = true;
                return isHighScore;
            }

            foreach (var score in leaderboard)
            {
                if (scoreToCheck > score)
                {
                    isHighScore = true;
                    break;
                }
            }

            return isHighScore;
        }

        private void CurrentlyPlayingGame(bool inPlay)
        {
            undoButton.Enabled = inPlay;
            submitButton.Enabled = inPlay;
            clearTextBoxButton.Enabled = inPlay;
            textTwistButton.Enabled = inPlay;
            ChangeStateOfLetterButtons(inPlay);

            _inPlay = inPlay;
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

        private void TextTwistButton_Click(object sender, EventArgs e)
        {
            _letterGenerator.ChosenLetters = _letterGenerator.TwistLetters();
            AssignLettersToButtons(_letterGenerator.ChosenLetters);

            foreach (var button in _letterButtons)
            {
                button.Enabled = true;
                if (activeWordTextBox.Text.Contains(button.Text))
                {
                    button.Enabled = false;
                }
            }
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
                notValidWordLabel.Text = "Already submitted that word.";
                wordInvalidReason = "Duplicate Word";
            }

            return wordInvalidReason;
        }

        private bool NotEligibleForPoints(string word)
        {
            return !_validator.InDictionary || _validator.WordInSubmittedWords(word) || word.Length < 3;
        }

        private void PopulateRoundSummaryTextbox()
        {
            pointsEarnedLabel.Text = "";
            notValidWordLabel.Text = "";
            activeWordTextBox.Text = "";

            if (!_inPlay)
            {
                var output = "Round Results:" + Environment.NewLine + Environment.NewLine;

                output += SortedWordsToSummary() + Environment.NewLine;
                output += "Total Score: " + CalculateRoundScore();

                roundSummaryTextBox.Text = output + Environment.NewLine;
            }
        }

        private string SortedWordsToSummary()
        {
            List<(string Word, int PointValue)> allWords = [];
            foreach (var word in _validator.ValidWords)
            {
                allWords.Add(new(word.Word, word.PointValue));
            }
            foreach (var word in _validator.InvalidWords)
            {
                allWords.Add(new(word.Word, 0));
            }

            var sortedWordsByPoints = allWords.OrderByDescending(points => points.PointValue)
                .ThenBy(word => word.Word);

            var output = "Word\tPoints Earned" + Environment.NewLine;
            foreach (var currentWord in sortedWordsByPoints)
            {
                output += $"{currentWord.Word}\t\t{currentWord.PointValue}" + Environment.NewLine;
            }

            return output;
        }

        private int CalculateRoundScore()
        {
            var score = 0;
            foreach (var word in _validator.ValidWords)
            {
                score += word.PointValue;
            }

            return score;
        }

        private void ExportStatsMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = saveFileDialog.FileName;
                var json = JsonSerializer.Serialize(_rounds, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                File.WriteAllText(filePath, json);

                var message = $"Successfully exported {_rounds.Count} ";
                if (_rounds.Count == 1)
                {
                    message += "round";
                }
                else
                {
                    message += "rounds";
                }

                MessageBox.Show(message, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AssignLettersToButtons(string chosenLetters)
        {
            for (var i = 0; i < _letterButtons.Count; i++)
            {
                var button = _letterButtons[i];
                var letter = chosenLetters[i];
                button.Text = letter.ToString();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to start a new game? Your data from previous rounds will be lost.",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetGameState();
                _rounds.Clear();
            }
        }

        private void ResetGameState()
        {
            _startTime = 60;
            _currentTime = _startTime;

            startButton.Text = "Start";

            _appTimer.Stop();

            _roundNumber = 1;

            _letterGenerator.PopulateChosenLetters();
            AssignLettersToButtons(_letterGenerator.ChosenLetters);

            timeRemainingLabel.Text = "60";

            notValidWordLabel.Text = "";
            pointsEarnedLabel.Text = "";
            roundSummaryTextBox.Text = "";

            CurrentlyPlayingGame(false);

            _highScoreBoard = [];
        }
    }
}
