using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Word
{
    public class InvalidWordTracker : WordTracker
    {
        /// <summary>
        /// The ReasonInvalid property.
        /// </summary>
        /// <value>
        /// The reason a word is invalid.
        /// </value>
        [JsonPropertyName("Reason")]
        public string ReasonInvalid { get; set; }

        /// <summary>
        /// Initializes a new instance of an InvalidWordTracker.
        /// </summary>
        /// <param name="word">The word.</param>
        public InvalidWordTracker(string word) : base(word)
        {
            ReasonInvalid = "";
        }

        /// <summary>
        /// Initializes a new instance of an InvalidWordTracker.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="reasonInvalid">The reason invalid.</param>
        public InvalidWordTracker(string word, string reasonInvalid) : this(word)
        {
            ReasonInvalid = reasonInvalid;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Reason it's invalid: {ReasonInvalid}";
        }
    }
}
