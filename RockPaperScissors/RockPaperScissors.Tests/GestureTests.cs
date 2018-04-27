using System.Collections;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class GestureTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Scissors, Paper).Returns(true);
                yield return new TestCaseData(Paper, Rock).Returns(true);
                yield return new TestCaseData(Rock, Lizard).Returns(true);
                yield return new TestCaseData(Lizard, Spock).Returns(true);
                yield return new TestCaseData(Spock, Scissors).Returns(true);
                yield return new TestCaseData(Scissors, Lizard).Returns(true);
                yield return new TestCaseData(Lizard, Paper).Returns(true);
                yield return new TestCaseData(Paper, Spock).Returns(true);
                yield return new TestCaseData(Spock, Rock).Returns(true);
                yield return new TestCaseData(Rock, Scissors).Returns(true);
            }
        }

        [Test]
        [TestCaseSource(typeof(GestureTests), nameof(TestCases))]
        public bool GreaterThanOperator_Should_CorreclyCompareGestures_When_GesturesArentEqual(
            Gesture gestureA,
            Gesture gestureB)
        {
            return gestureA > gestureB;
        }

        [Test]
        [TestCaseSource(typeof(GestureTests), nameof(TestCases))]
        public bool LessThanOperator_Should_CorreclyCompareGestures_When_GesturesArentEqual(
            Gesture gestureA,
            Gesture gestureB)
        {
            return !(gestureA < gestureB);
        }
    }
}
