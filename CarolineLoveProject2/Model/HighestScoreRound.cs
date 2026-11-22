using CarolineLoveProject2.Word;
using System.Numerics;

namespace CarolineLoveProject2.Model
{
    public class HighestScoreRound : Round
    {
        public string PlayerName { get; set; }

        public HighestScoreRound(Validator validator) : base(validator)
        {
            Validator = validator;

            PlayerName = "";
        }

        public HighestScoreRound(Validator validator, string playerName) : this(validator)
        {
            PlayerName = playerName;
        }

        public override string ToString()
        {
            return $"{PlayerName}\t\t{Score}\t\t{MaxTime}";
        }
    }
}
