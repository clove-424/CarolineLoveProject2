using CarolineLoveProject2.Model;

namespace CarolineLoveProject2.LINQController
{
    /// <summary>
    /// The class that compares the scores and maximum times of two rounds.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer<"CarolineLoveProject2.Model.HighestScoreRound">>
    public class RoundTimeAndScoreComparer : IComparer<HighestScoreRound>
    {
        /// <summary>
        /// Compares player 1 and player 2 scores and time.
        /// </summary>
        /// <param name="player1">Player 1.</param>
        /// <param name="player2">Player 2</param>
        /// <returns></returns>
        public int Compare(HighestScoreRound? player1, HighestScoreRound? player2)
        { 
            return player2.MaxTime > player1.MaxTime
                    ? player1.MaxTime.CompareTo(player2.MaxTime)
                    : player2.Score.CompareTo(player1.Score);
        }
    }
}
