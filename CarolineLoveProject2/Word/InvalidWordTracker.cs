using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Word
{
    /// <summary>
    /// The invalid word tracker that is a type of word tracker.
    /// </summary>
    /// <seealso cref="CarolineLoveProject2.Word.WordTracker" />
    public class InvalidWordTracker : WordTracker
    {
        /// <summary>
        /// The ReasonInvalid property.
        /// </summary>
        /// <value>
        /// The reason a word is invalid.
        /// </value>
        [JsonPropertyName("Reason")]
        [JsonPropertyOrder(2)]
        public string? ReasonInvalid { get; set; }

        /// <summary>
        /// The default constructor that is not meant to be called.
        /// </summary>
        public InvalidWordTracker()
        {
        }

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
