using System.Text.Json.Serialization;
namespace CarolineLoveProject2.Model
{
    /// <summary>
    /// The class that tracks a player's stats including their name or initials in the leaderboard.
    /// </summary>
    /// <seealso cref="CarolineLoveProject2.Model.Round" />
    public class HighestScoreRound : Round
    {
        /// <summary>
        /// The PlayerName property.
        /// </summary>
        /// <value>
        /// The name of the player.
        /// </value>
        [JsonIgnore]
        public string PlayerName { get; set; } = "";

        public override string ToString()
        {
            return $"{PlayerName}\t\t{Score}\t\t{MaxTime}";
        }
    }
}
