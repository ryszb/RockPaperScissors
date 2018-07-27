using RockPaperScissors.Logic.Common;
using RockPaperScissors.Logic.Core;

namespace RockPaperScissors.Logic.Players
{
    public abstract class Player : Entity
    {
        public abstract bool Ready { get; }

        public abstract Gesture PreviousGesture { get; protected set; }

        public abstract Gesture MakeAMove();
    }
}