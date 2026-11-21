using System.Text.Json.Serialization;
using CarolineLoveProject2.Word;

namespace CarolineLoveProject2.Model
{
    public class Round
    {
        private readonly Validator _validator;

        [JsonPropertyName("Round Number")]
        public int RoundNumber { get; set; }

        [JsonPropertyName("Max Time")]
        public int MaxTime { get; set; }

        [JsonPropertyName("Score")]
        public int Score { get; set; }

        [JsonPropertyName("Valid Words")]
        public List<ValidWordTracker> SubmittedValidWords { get; set; }

        [JsonPropertyName("Invalid Words")]
        public List<InvalidWordTracker> SubmittedInvalidWords { get; set; }

        public Round(Validator validator)
        {
            _validator = validator;

            SubmittedValidWords = [];
            SubmittedInvalidWords = [];
        }

        public void SaveSubmittedWords()
        {
            SubmittedValidWords.AddRange(_validator.ValidWords);
            SubmittedInvalidWords.AddRange(_validator.InvalidWords);
        }
    }
}
