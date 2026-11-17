using System.Text.Json;

namespace CarolineLoveProject2.Dictionary
{
    public class WordValidator
    {
        private const string DictionaryJson = "Dictionary/dictionary.json";

        public List<Dictionary>? LetterWordPairs { get; set; }

        public List<string>? SubmittedValidWords { get; set; }

        public bool IsValidWord { get; set; }

        public WordValidator()
        {
            SubmittedValidWords = [];
            try
            {
                using StreamReader reader = new(DictionaryJson);
                var json = reader.ReadToEnd();
                LetterWordPairs = JsonSerializer.Deserialize<List<Dictionary>>(json) ?? [];
            }
            catch (IOException)
            {
                Console.WriteLine("File Not Found.");
            }
        }

        /// <summary>
        /// Validates the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        public void Validate(string word)
        {
            IsValidWord = false;
            foreach (var pair in LetterWordPairs)
            {
                var letter = pair.Letter.ToLower();
                if (letter.Equals(word[0].ToString()))
                {
                    IterateOverWordsUnderLetter(pair, word.ToLower());
                }

                if (IsValidWord)
                {
                    break;
                }
            }

        }

        private void IterateOverWordsUnderLetter(Dictionary pair, string wordToCheck)
        {
            foreach (var word in pair.Words)
            {
                if (word.ToLower().Equals(wordToCheck))
                {
                    IsValidWord = true;
                    break;
                }
            }
        }
    }
}
