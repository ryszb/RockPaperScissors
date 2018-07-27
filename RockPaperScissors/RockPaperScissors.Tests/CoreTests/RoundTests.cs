using System.Collections;
using NUnit.Framework;
using RockPaperScissors.Logic.Core;

namespace RockPaperScissors.Tests.CoreTests
{
    [TestFixture]
    public class RoundTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Gesture.Paper, Gesture.Scissors).Returns(RoundResult.PlayerTwoWins);
                yield return new TestCaseData(Gesture.Paper, Gesture.Rock).Returns(RoundResult.PlayerOneWins);
                yield return new TestCaseData(Gesture.Rock, Gesture.Rock).Returns(RoundResult.Draw);
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
