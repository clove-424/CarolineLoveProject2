namespace CarolineLoveProject2.Model
{
    /// <summary>
    /// The letter generator class that handles the list of chosen letters and chooses which
    /// letters go into the chosen letters.
    /// </summary>
    public class LetterGenerator
    {
        private const int MaxWordLength = 7;

        private readonly Random _rand;

        private string _letters;

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
        public string ChosenLetters { get; set; }

        /// <summary>
        /// Creates an instance of a letter generator and populates LetterBag with 
        /// </summary>
        public LetterGenerator()
        {
            _rand = new();
            _letters = "";
            ChosenLetters = "";

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
        /// The value set for ChosenLetters guarantees the player gets at least one vowel.
        /// </summary>
        public void PopulateChosenLetters()
        {
            var letters = "";
            while (letters.Length < MaxWordLength)
            {
                var index = _rand.Next(LetterBag.Count);
                var currentLetter = LetterBag[index];
                if (!letters.Contains(currentLetter))
                {
                    letters += currentLetter;
                }
                LetterBag.Remove(currentLetter);
            }

            _letters = letters;
            ChosenLetters = GetLettersSetWithVowels(_letters);
        }

        private string GetLettersSetWithVowels(string letters)
        {
            const string vowels = "aeiou";
            var vowelsFound = false;
            foreach (var ch in letters.ToLower())
            {
                foreach (var v in vowels)
                {
                    vowelsFound = ch.Equals(v);
                    if (vowelsFound)
                    {
                        break;
                    }
                }

                if (vowelsFound)
                {
                    break;
                }
            }

            if (vowelsFound)
            {
                return letters;
            }

            var lettersSeed = _rand.Next(letters.Length);
            var vowelSeed = _rand.Next(vowels.Length);

            var newString = letters.Replace(letters[lettersSeed], vowels[vowelSeed]);

            return newString;
        }

        /// <summary>
        /// Twists the letters.
        /// </summary>
        /// <returns>The reordered letters</returns>
        public string TwistLetters()
        {
            var prevOrder = _letters.ToList();
            var reorderedLetters = "";
            while (reorderedLetters.Length < MaxWordLength)
            {
                var index = _rand.Next(prevOrder.Count);
                var currentLetter = prevOrder[index];
                reorderedLetters += currentLetter;
                prevOrder.Remove(currentLetter);
            }

            return reorderedLetters;
        }
    }
}
