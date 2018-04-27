namespace RockPaperScissors.Logic
{
    public abstract class Player : Entity
    {
        public abstract bool Ready { get; }

        public abstract Gesture PreviousGesture { get; protected set; }

        public abstract Gesture MakeAMove();
    }
}