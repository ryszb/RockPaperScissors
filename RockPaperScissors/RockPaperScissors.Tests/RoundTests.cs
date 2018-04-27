using System.Collections;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;
using static RockPaperScissors.Logic.RoundResult;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class RoundTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Paper, Scissors).Returns(PlayerTwoWins);
                yield return new TestCaseData(Paper, Rock).Returns(PlayerOneWins);
                yield return new TestCaseData(Rock, Rock).Returns(Draw);
            }
        }

        [Test]
        [TestCaseSource(typeof(RoundTests), nameof(TestCases))]
        public RoundResult FinishRound_Should_CorreclyReturnResult(Gesture gestureA, Gesture gestureB)
        {
            return new Round(gestureA, gestureB).FinishRound();
        }
    }
}
