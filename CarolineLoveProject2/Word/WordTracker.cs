using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Word
{
    /// <summary>
    /// The generic word tracker class.
    /// </summary>
    public abstract class WordTracker
    {
        /// <summary>
        /// The Word property.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        [JsonPropertyName("Word")]
        [JsonPropertyOrder(1)]
        public string Word { get; set; }

        /// <summary>
        /// The time the word was added property.
        /// </summary>
        /// <value>
        /// The time added.
        /// </value>
        [JsonPropertyName("Time Word was Added")]
        [JsonPropertyOrder(3)]
        public int TimeAdded { get; set; }

        /// <summary>
        /// Initializes a new instance of a WordTracker.
        /// </summary>
        /// <param name="word">The word.</param>
        protected WordTracker(string word)
        {
            Word = word;
        }

        public override string ToString()
        {
            return $"Word: {Word}";
        }
    }
}
