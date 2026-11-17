using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Dictionary
{
    /// <summary>
    /// The Dictionary class that contains the properties of the dictionary.json file.
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// The letter property.
        /// </summary>
        /// <value>
        /// The letter.
        /// </value>
        [JsonPropertyName("letter")]
        public string? Letter { get; set; }

        /// <summary>
        /// The list of words property.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        [JsonPropertyName("words")]
        public List<string>? Words { get; set; }
    }
}
