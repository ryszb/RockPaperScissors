using System.Collections.Generic;

namespace RockPaperScissors.Logic
{
    public class TacticalComputerPlayer : ComputerPlayer
    {
        public TacticalComputerPlayer(IReadOnlyCollection<Gesture> gestures, IRandomNumberGenerator randomNumberGenerator)
            : base(gestures, randomNumberGenerator)
        {
        }

        public override Gesture MakeAMove()
        {
            if (PreviousGesture == null)
            {
                PreviousGesture = base.MakeAMove();

                return PreviousGesture;
            }

            foreach (var gesture in Gestures)
            {
                if (gesture > PreviousGesture)
                {
                    PreviousGesture = gesture;

                    return PreviousGesture;
                }
            }

            PreviousGesture = base.MakeAMove();

            return PreviousGesture;
        }
    }
}
