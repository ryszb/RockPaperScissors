using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Logic
{
    public class ComputerPlayer : Player
    {
        protected readonly IReadOnlyCollection<Gesture> Gestures;
        protected readonly IRandomNumberGenerator RandomNumberGenerator;

        public override bool Ready => true;

        public override Gesture PreviousGesture { get; protected set; }

        public ComputerPlayer(IReadOnlyCollection<Gesture> gestures, IRandomNumberGenerator randomNumberGenerator)
        {
            Gestures = gestures;
            RandomNumberGenerator = randomNumberGenerator;
        }

        public override Gesture MakeAMove()
        {
            var randomIdx = RandomNumberGenerator.GenerateRandomNumber(1, Gestures.Count + 1);

            PreviousGesture = Gestures.First(g => g.Idx == randomIdx);

            return PreviousGesture;
        }
    }
}
