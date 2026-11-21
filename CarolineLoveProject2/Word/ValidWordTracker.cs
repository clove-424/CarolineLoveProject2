using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Word
{
    public class ValidWordTracker : WordTracker
    {
        /// <summary>
        /// The PointValue property.
        /// </summary>
        /// <value>
        /// The points earned per word.
        /// </value>
        [JsonPropertyName("Point Value")]
        public int PointValue { get; set; }

        /// <summary>
        /// Initializes a new instance of a ValidWordTracker.
        /// </summary>
        /// <param name="word">The word.</param>
        public ValidWordTracker(string word) : base(word)
        {
            var pointsPerLetter = word.Length * 10;
            PointValue = pointsPerLetter * word.Length;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Time Entered: {TimeAdded}";
        }
    }
}
