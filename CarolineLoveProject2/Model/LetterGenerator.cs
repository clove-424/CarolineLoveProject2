namespace CarolineLoveProject2.Model
{
    public class LetterGenerator
    {
        private Random? _rand;

        public List<string> LetterBag { get; set; }

        public string? ChosenLetters { get; set; }

        /// <summary>
        /// Creates an instance of a letter generator and populates LetterBag with 
        /// </summary>
        public LetterGenerator()
        {
            LetterBag = ["j","k","q","x","z", "b", "b","c","c","f",
                "f","g","g","m","m","p","p","v","v","d","d","d","u",
                "u","u","w","w","w","y","y","y","l","l","l","l","h",
                "h","h","h","h","r","r","r","r","r","a","a","a","a",
                "a","a","i","i","i","i","i","i","n","n","n","n","n",
                "n","s","s","s","s","s","s","o","o","o","o","o", "o",
                "o","o","t","t","t","t","t","t","t","t","t","e","e",
                "e","e","e","e","e","e","e","e","e"];
        }

        public void PopulateChosenLetters()
        {
            _rand = new();

            var letters = "";
            while (letters.Length < 7)
            {
                var index = _rand.Next(LetterBag.Count);
                if (!letters.Contains(LetterBag[index]))
                {
                    letters += LetterBag[index];
                }
                LetterBag.RemoveAt(index);
            }

            ChosenLetters = letters;
        }
    }
}
