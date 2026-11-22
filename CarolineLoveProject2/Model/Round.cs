using System.Text.Json.Serialization;
using CarolineLoveProject2.Word;

namespace CarolineLoveProject2.Model
{
    /// <summary>
    /// The Round class that stores information about a plyer's attempt.
    /// </summary>
    public class Round 
    {
        /// <summary>
        /// The Validator property, only accessible to Round and its derived class.
        /// </summary>
        /// <value>
        /// The validator.
        /// </value>
        protected Validator Validator { get; set; }

        /// <summary>
        /// The RoundNumber property.
        /// </summary>
        /// <value>
        /// The round number.
        /// </value>
        [JsonPropertyName("Round Number")]
        public int RoundNumber { get; set; }

        /// <summary>
        /// The Score property.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        [JsonPropertyName("Score")]
        public int Score { get; set; }

        /// <summary>
        /// The MaxTime property
        /// </summary>
        /// <value>
        /// The maximum time.
        /// </value>
        [JsonPropertyName("Maximum Time")]
        public int MaxTime { get; set; }

        /// <summary>
        /// The SubmittedValidWords property.
        /// </summary>
        /// <value>
        /// The submitted valid words.
        /// </value>
        [JsonPropertyName("Valid Words")]
        public List<ValidWordTracker> SubmittedValidWords { get; set; }

        /// <summary>
        /// The SubmittedInvalidWords property.
        /// </summary>
        /// <value>
        /// The submitted invalid words.
        /// </value>
        [JsonPropertyName("Invalid Words")]
        public List<InvalidWordTracker> SubmittedInvalidWords { get; set; }

        /// <summary>
        /// Starts a new Round.
        /// </summary>
        /// <param name="validator">The validator.</param>
        public Round(Validator validator)
        {
            Validator = validator;

            SubmittedValidWords = [];
            SubmittedInvalidWords = [];
        }

        /// <summary>
        /// Saves the submitted words into the round.
        /// </summary>
        public void SaveSubmittedWords()
        {
            SubmittedValidWords.AddRange(Validator.ValidWords);
            SubmittedInvalidWords.AddRange(Validator.InvalidWords);
        }
    }
}
