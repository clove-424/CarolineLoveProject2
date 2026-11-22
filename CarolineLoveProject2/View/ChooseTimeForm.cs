using CarolineLoveProject2.Model;

namespace CarolineLoveProject2.View
{
    /// <summary>
    /// The class for the ChooseTimeForm that decides how long a round goes on.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ChooseTimeForm : Form
    {
        private readonly LetterGenerator _letterGenerator;

        /// <summary>
        /// The StartTime property.
        /// </summary>
        /// <value>
        /// The current time.
        /// </value>
        public int StartTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of a ChooseTimeForm.
        /// </summary>
        /// <param name="letterGenerator">The letter generator.</param>
        public ChooseTimeForm(LetterGenerator letterGenerator)
        {
            InitializeComponent();

            _letterGenerator = letterGenerator;
        }

        private void OneMinuteButton_Click(object sender, EventArgs e)
        {
            StartTime = 60;
            PopulateThenClose();
        }

        private void TwoMinuteButton_Click(object sender, EventArgs e)
        {
            StartTime = 120;
            PopulateThenClose();
        }

        private void ThreeMinuteButton_Click(object sender, EventArgs e)
        {
            StartTime = 180;
            PopulateThenClose();
        }

        private void PopulateThenClose()
        {
            _letterGenerator.PopulateChosenLetters();

            Close();
        }
    }
}
