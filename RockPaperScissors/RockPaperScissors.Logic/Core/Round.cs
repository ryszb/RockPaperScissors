using System.Collections.Generic;
using RockPaperScissors.Logic.Common;

namespace RockPaperScissors.Logic.Core
{
    public class Round : ValueObject<Round>
    {
        public Gesture PlayerOneGesture { get; }

        public Gesture PlayerTwoGesture { get; }

        public Round(Gesture playerOneGesture, Gesture playerTwoGesture)
        {
            PlayerOneGesture = playerOneGesture;
            PlayerTwoGesture = playerTwoGesture;
        }

        public RoundResult FinishRound()
        {
            if (PlayerOneGesture > PlayerTwoGesture)
            {
                return RoundResult.PlayerOneWins;
            }

            if (PlayerOneGesture < PlayerTwoGesture)
            {
                return RoundResult.PlayerTwoWins;
            }

            return RoundResult.Draw;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PlayerOneGesture;
            yield return PlayerTwoGesture;
        }
    }

    public enum RoundResult
    {
        Draw,
        PlayerOneWins,
        PlayerTwoWins
    }
}