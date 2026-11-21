namespace CarolineLoveProject2.View
{
    public partial class ChooseTimeForm : Form
    {
        public int CurrentTime { get; private set; }

        public ChooseTimeForm()
        {
            InitializeComponent();
        }

        private void OneMinuteButton_Click(object sender, EventArgs e)
        {
            CurrentTime = 60;
            Close();
        }

        private void TwoMinuteButton_Click(object sender, EventArgs e)
        {
            CurrentTime = 120;
            Close();
        }

        private void ThreeMinuteButton_Click(object sender, EventArgs e)
        {
            CurrentTime = 180;
            Close();
        }
    }
}
