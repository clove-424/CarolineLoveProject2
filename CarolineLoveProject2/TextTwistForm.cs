using CarolineLoveProject2.Model;

namespace CarolineLoveProject2
{
    public partial class TextTwistForm : Form
    {
        public TextTwistForm()
        {
            InitializeComponent();
            chosenLettersLabel.Text = "";

            var letterGenerator = new LetterGenerator();
            letterGenerator.PopulateChosenLetters();

            chosenLettersLabel.Text = letterGenerator.ChosenLetters;
        }
    }
}
