namespace CarolineLoveProject2.Model
{
    /// <summary>
    /// The letter generator class that handles the list of chosen letters and chooses which
    /// letters go into the chosen letters.
    /// </summary>
    public class LetterGenerator
    {
        private Random? _rand;

        /// <summary>
        /// The letter bag property.
        /// </summary>
        /// <value>
        /// The letter bag.
        /// </value>
        public List<string> LetterBag { get; set; }

        /// <summary>
        /// The chosen letters property.
        /// </summary>
        /// <value>
        /// The chosen letters.
        /// </value>
        public string? ChosenLetters { get; set; }

        /// <summary>
        /// Creates an instance of a letter generator and populates LetterBag with 
        /// </summary>
        public LetterGenerator()
        {
            LetterBag = ["j","k","q","x","z","b","b","c","c","f",
                "f","g","g","m","m","p","p","v","v","d","d","d","u",
                "u","u","w","w","w","y","y","y","l","l","l","l","h",
                "h","h","h","h","r","r","r","r","r","a","a","a","a",
                "a","a","i","i","i","i","i","i","n","n","n","n","n",
                "n","s","s","s","s","s","s","o","o","o","o","o", "o",
                "o","o","t","t","t","t","t","t","t","t","t","e","e",
                "e","e","e","e","e","e","e","e","e"];
        }

        /// <summary>
        /// Populates the list of chosen letters from the letter bag.
        /// </summary>
        public void PopulateChosenLetters()
        {
            const int maxWordLength = 7;
            _rand = new();

            var letters = "";
            while (letters.Length < maxWordLength)
            {
                var index = _rand.Next(LetterBag.Count);
                var currentLetter = LetterBag[index];
                if (!letters.Contains(currentLetter))
                {
                    letters += currentLetter;
                }
                LetterBag.Remove(currentLetter);
            }

            ChosenLetters = letters;
        }
    }
}
