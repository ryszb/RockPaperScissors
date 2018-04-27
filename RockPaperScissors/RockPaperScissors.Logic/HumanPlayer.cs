using System;

namespace RockPaperScissors.Logic
{
    public class HumanPlayer : Player
    {
        public override bool Ready => ChosenGesture != null;

        public Gesture ChosenGesture { get; set; }

        public override Gesture PreviousGesture { get; protected set; }

        public override Gesture MakeAMove()
        {
            if (ChosenGesture == null)
            {
                throw new InvalidOperationException();
            }

            PreviousGesture = ChosenGesture;

            ChosenGesture = null;

            return PreviousGesture;
        }
    }
}
