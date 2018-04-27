using System.Collections.Generic;

using static RockPaperScissors.Logic.RoundResult;

namespace RockPaperScissors.Logic
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
                return PlayerOneWins;
            }

            if (PlayerOneGesture < PlayerTwoGesture)
            {
                return PlayerTwoWins;
            }

            return Draw;
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