using System.Text.Json.Serialization;

namespace CarolineLoveProject2.Dictionary
{
    public class Dictionary
    {
        [JsonPropertyName("letter")]
        public string? Letter { get; set; }

        [JsonPropertyName("words")]
        public List<string>? Words { get; set; }
    }
}
