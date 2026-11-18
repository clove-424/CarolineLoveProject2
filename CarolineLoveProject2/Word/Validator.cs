using System.Text.Json;

namespace CarolineLoveProject2.Word
{
    public class Validator
    {
        private const string DictionaryJson = "Dictionary/dictionary.json";

        /// <summary>
        /// The letter word pairs list property.
        /// </summary>
        /// <value>
        /// The letter word pairs.
        /// </value>
        public List<Dictionary.Dictionary>? LetterWordPairs { get; set; }

        /// <summary>
        /// The submitted valid words list property.
        /// </summary>
        /// <value>
        /// The submitted valid words.
        /// </value>
        public List<string> SubmittedValidWords { get; set; }

        /// <summary>
        /// The property indicating whether a word is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a word is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidWord { get; set; }

        public List<string> AllSubmittedWords { get; set; }

        /// <summary>
        /// Initializes a new instance of a word validator.
        /// </summary>
        public Validator()
        {
            SubmittedValidWords = [];
            AllSubmittedWords = [];

            try
            {
                using StreamReader reader = new(DictionaryJson);
                var json = reader.ReadToEnd();
                LetterWordPairs = JsonSerializer.Deserialize<List<Dictionary.Dictionary>>(json) ?? [];
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
                var firstLetter = word[0].ToString();
                if (letter.Equals(firstLetter))
                {
                    IterateOverWordsUnderLetter(pair, word.ToLower());
                }

                if (IsValidWord)
                {
                    break;
                }
            }

        }

        private void IterateOverWordsUnderLetter(Dictionary.Dictionary pair, string wordToCheck)
        {
            foreach (var word in pair.Words)
            {
                if (WordIsValid(word.ToLower(), wordToCheck.ToLower()))
                {
                    SubmittedValidWords.Add(word);
                    IsValidWord = true;

                    break;
                }
            }
        }

        private bool WordIsValid(string wordInList, string wordToCheck)
        {
            const int minimumWordLength = 3;
            return wordInList.Equals(wordToCheck) && wordInList.Length >= minimumWordLength 
                                                  && !WordInSubmittedWords(wordToCheck);
        }

        /// <summary>
        /// Checks if a word is in the list of submitted words.
        /// </summary>
        /// <param name="wordToCheck">The word to check.</param>
        /// <returns>true if a value is in SubmittedValidWords; otherwise false</returns>
        public bool WordInSubmittedWords(string wordToCheck)
        {
            var inSubmittedWords = false;
            foreach (var word in SubmittedValidWords)
            {
                if (word.ToLower().Equals(wordToCheck.ToLower()))
                {
                    inSubmittedWords = true;
                    break;
                }
            }
            return inSubmittedWords;
        }
    }
}
