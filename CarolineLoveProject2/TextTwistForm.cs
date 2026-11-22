using CarolineLoveProject2.LINQController;
using CarolineLoveProject2.Model;
using CarolineLoveProject2.View;
using CarolineLoveProject2.Word;
using System.Text.Encodings.Web;
using System.Text.Json;
using Timer = System.Windows.Forms.Timer;

namespace CarolineLoveProject2
{
    /// <summary>
    /// The TextTwistForm that is the main form of the project and handles the logic for it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TextTwistForm : Form
    {
        private const int DefaultTime = 60;

        private readonly Timer _appTimer;
        private int _startTime;
        private int _currentTime;
        private int _roundNumber;

        private readonly LetterGenerator _letterGenerator;
        private readonly Validator _validator;
        private ChooseTimeForm? _chooseTimeForm;

        private List<Round> _rounds;
        private readonly List<HighestScoreRound> _highScoreBoard;

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
            _chooseTimeForm = null;

            _rounds = [];
            _highScoreBoard = [];

            _appTimer = new();
            _appTimer.Interval = 1000;
            _appTimer.Tick += TimerOnTick;

            ResetGameState();

            _inPlay = false;
            _startTime = DefaultTime;
            _currentTime = _startTime;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            CurrentlyPlayingGame(true);
            if (startButton.Text == "New")
            {
                _appTimer.Stop();
                var result = MessageBox.Show("Do you want a new puzzle?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AssignLettersToButtons(_letterGenerator.ChosenLetters);

                    _currentTime = _startTime;
                    StartRound(_currentTime);
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

        private void SetTimeMenuItem_Click(object sender, EventArgs e)
        {
            PromptPlayerForRoundTimeAndChangeStartTime();
        }

        private void PromptPlayerForRoundTimeAndChangeStartTime()
        {
            _chooseTimeForm = new ChooseTimeForm(_letterGenerator);
            _chooseTimeForm.ShowDialog();

            _startTime = _chooseTimeForm.StartTime;
            if (_startTime > 0)
            {
                AssignLettersToButtons(_letterGenerator.ChosenLetters);

                _appTimer.Stop();
                _currentTime = _startTime;
                timeRemainingLabel.Text = _currentTime.ToString();

                startButton.Text = "Start";
                pointsEarnedLabel.Text = "";
                notValidWordLabel.Text = "";

                CurrentlyPlayingGame(false);
            }
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

            timeRemainingLabel.Text = time.ToString();
            _appTimer.Start();
        }

        private void TimerOnTick(object? sender, EventArgs e)
        {
            importDataMenuItem.Enabled = false;
            exportStatsMenuItem.Enabled = false;

            _currentTime--;
            timeRemainingLabel.Text = _currentTime.ToString();

            if (_currentTime <= 0)
            {
                importDataMenuItem.Enabled = true;
                exportStatsMenuItem.Enabled = true;
                _appTimer.Stop();
                CurrentlyPlayingGame(false);

                UpdateHighScoreBoard();
                PopulateRoundSummaryTextbox();

                exportStatsMenuItem.Enabled = _rounds.Count > 0;

                _roundNumber++;

                startButton.Text = "Start";
                _startTime = _chooseTimeForm.StartTime;
                timeRemainingLabel.Text = _startTime.ToString();
            }
        }

        private void UpdateHighScoreBoard()
        {
            var player = new Round
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
            player.SaveSubmittedWords(_validator);
        }

        private void AddPlayerToLeaderBoard(Round player, string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                player = new HighestScoreRound
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
            activeWordTextBox.Text += _letterGenerator.ChosenLetters[index].ToString();
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
            ClearTextFields();

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
            var allWords = CombineAllWordsToOneList();
            
            var sortedWordsByPoints = allWords.OrderByDescending(points => points.PointValue)
                .ThenBy(word => word.Word);

            var output = "Word\t\tPoints" + Environment.NewLine;
            foreach (var currentWord in sortedWordsByPoints)
            {
                output += $"{currentWord.Word}\t\t{currentWord.PointValue}" + Environment.NewLine;
            }

            return output;
        }

        private List<(string Word, int PointValue)> CombineAllWordsToOneList()
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

            return allWords;
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
                _appTimer.Stop();
            }
        }

        private void ResetGameState()
        {
            _startTime = DefaultTime;
            _currentTime = _startTime;

            startButton.Text = "Start";

            _roundNumber = 1;

            _letterGenerator.PopulateChosenLetters();
            AssignLettersToButtons(_letterGenerator.ChosenLetters);

            timeRemainingLabel.Text = DefaultTime.ToString();

            ClearTextFields();

            CurrentlyPlayingGame(false);

            _highScoreBoard.Clear();

            leaderboardListBox.DataSource = null;
            leaderboardListBox.Items.Clear();
            leaderboardListBox.DataSource = _highScoreBoard;
        }

        private void ResetLeaderboardMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset the leaderboard?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _highScoreBoard.Clear();

                leaderboardListBox.DataSource = null;
                leaderboardListBox.Items.Clear();
                leaderboardListBox.DataSource = _highScoreBoard;
            }
        }

        private void ImportDataMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;
                    var json = File.ReadAllText(filePath);
                    _rounds = JsonSerializer.Deserialize<List<Round>>(json) ?? [];

                    var message = $"Successfully imported {_rounds.Count} ";
                    if (_rounds.Count == 1)
                    {
                        message += "round";
                    }
                    else
                    {
                        message += "rounds";
                    }
                    MessageBox.Show(message, "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    SetRecentGameState();
                }
                catch (Exception)
                {
                    MessageBox.Show("Failure Reading File. \nCreating a new game instead.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    timeRemainingLabel.Text = DefaultTime.ToString();
                }
            }
        }

        private void SetRecentGameState()
        {
            ClearTextFields();

            var roundNumber = (from round in _rounds select round.RoundNumber).Last();
            _roundNumber = roundNumber + 1;

            _startTime = (from round in _rounds select round.MaxTime).Last();
            timeRemainingLabel.Text = _startTime.ToString();

            var validWords = (from round in _rounds select round.SubmittedValidWords).Last().OrderByDescending(score => score.PointValue).ThenBy(word => word.Word);
            var invalidWords = (from round in _rounds select round.SubmittedInvalidWords).Last().OrderBy(word => word.Word);
            var points = (from score in _rounds select score.Score).Last();

            var roundSummary = "Word\t\tPoints" + Environment.NewLine + Environment.NewLine;

            foreach (var currentWord in validWords)
            {
                roundSummary += $"{currentWord.Word}\t\t{currentWord.PointValue}" + Environment.NewLine;
            }

            foreach (var currentWord in invalidWords)
            {
                roundSummary += $"{currentWord.Word}\t\t0" + Environment.NewLine;
            }

            roundSummary += Environment.NewLine + $"Total Score: {points}";

            roundSummaryTextBox.Text = roundSummary;

            exportStatsMenuItem.Enabled = true;
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

        private void ClearTextFields()
        {
            notValidWordLabel.Text = "";
            pointsEarnedLabel.Text = "";
            roundSummaryTextBox.Text = "";
        }
    }
}
