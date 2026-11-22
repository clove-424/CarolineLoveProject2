using System.Text.Json;

namespace CarolineLoveProject2.Word
{
    /// <summary>
    /// The word validator class that goes through the dictionary, determines whether a word is in
    /// the dictionary and/or valid, and sorts the word into a designated list.
    /// </summary>
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
        public List<ValidWordTracker> ValidWords { get; set; }

        /// <summary>
        /// The submitted invalid words list property.
        /// </summary>
        /// <value>
        /// The submitted invalid words.
        /// </value>
        public List<InvalidWordTracker> InvalidWords { get; set; }

        /// <summary>
        /// The property indicating whether a word is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a word is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidWord { get; set; }

        /// <summary>
        /// The property indicating whether a word is in the dictionary.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a word is in the dictionary; otherwise, <c>false</c>.
        /// </value>
        public bool InDictionary { get; set; }

        /// <summary>
        /// Initializes a new instance of a word validator.
        /// </summary>
        public Validator()
        {
            ValidWords = [];
            InvalidWords = [];

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
            foreach (var dictionary in LetterWordPairs)
            {
                var letter = dictionary.Letter.ToLower();
                var firstLetter = word[0].ToString();
                if (letter.Equals(firstLetter))
                {
                    CheckIfWordIsValid(dictionary, word);
                }

                if (IsValidWord)
                {
                    break;
                }
            }

        }
        private void CheckIfWordIsValid(Dictionary.Dictionary dictionary, string wordToCheck)
        {
            foreach (var word in dictionary.Words)
            {
                if (WordIsValid(word, wordToCheck))
                {
                    IsValidWord = true;

                    break;
                }
            }
        }

        /// <summary>
        /// Iterates over dictionary.json and determines of a word is found in it.
        /// </summary>
        /// <param name="word">The word to find in the dictionary</param>
        public void IterateOverLettersInDictionary(string word)
        {
            InDictionary = false;
            foreach (var dictionary in LetterWordPairs)
            {
                var letter = dictionary.Letter.ToLower();
                var firstLetter = word[0].ToString();
                if (letter.Equals(firstLetter))
                {
                    CheckIfWordInDictionary(dictionary, word);
                }

                if (InDictionary)
                {
                    break;
                }
            }
        }

        private void CheckIfWordInDictionary(Dictionary.Dictionary dictionary, string wordToCheck)
        {
            foreach (var word in dictionary.Words)
            {
                if (WordsAreEqual(word, wordToCheck))
                {
                    InDictionary = true;
                    break;
                }
            }
        }

        private static bool WordsAreEqual(string word1, string word2)
        {
            return word1.ToLower().Equals(word2.ToLower());
        }

        private bool WordIsValid(string wordInDictionary, string wordToCheck)
        {
            const int minimumWordLength = 3;
            return WordsAreEqual(wordInDictionary, wordToCheck) && wordToCheck.Length >= minimumWordLength 
                                                  && !WordInSubmittedWords(wordToCheck);
        }

        /// <summary>
        /// Checks if a word is in the list of submitted words.
        /// </summary>
        /// <param name="wordToCheck">The word to check.</param>
        /// <returns>true if a value is in ValidWords; otherwise false</returns>
        public bool WordInSubmittedWords(string wordToCheck)
        {
            var inSubmittedWords = false;
            foreach (var word in ValidWords)
            {
                inSubmittedWords = WordsAreEqual(word.Word, wordToCheck);
                if (inSubmittedWords)
                {
                    break;
                }
            }
            return inSubmittedWords;
        }
    }
}
