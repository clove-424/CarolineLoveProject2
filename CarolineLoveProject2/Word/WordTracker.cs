namespace CarolineLoveProject2.Word
{
    public class WordTracker
    {
        /// <summary>
        /// The Word property.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        public string Word { get; set; }

        /// <summary>
        /// The ReasonInvalid property.
        /// </summary>
        /// <value>
        /// The reason a word may be invalid, if it is.
        /// </value>
        public string? ReasonInvalid { get; set; }

        /// <summary>
        /// The PointsEarned property.
        /// </summary>
        /// <value>
        /// The points earned per word.
        /// </value>
        public int PointsEarned { get; set; }

        /// <summary>
        /// Initializes a new instance of a WordTracker.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="reasonInvalid">The reason the word is invalid invalid.</param>
        public WordTracker(string word, string reasonInvalid)
        {
            Word = word;
            ReasonInvalid = reasonInvalid;

            var pointsPerLetter = word.Length * 10;
            if (word.Length < 3)
            {
                PointsEarned = 0;
            }
            else
            {
                PointsEarned = pointsPerLetter * word.Length;
            }
        }

        public override string ToString()
        {
            var output = $"Word: {Word}";
            if (!string.IsNullOrEmpty(ReasonInvalid))
            {
                output += $" - Reason it's invalid: {ReasonInvalid}";
            }
            return output;
        }
    }
}
