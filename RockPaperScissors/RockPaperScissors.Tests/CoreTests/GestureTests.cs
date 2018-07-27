using System.Collections;
using NUnit.Framework;
using RockPaperScissors.Logic.Core;

namespace RockPaperScissors.Tests.CoreTests
{
    [TestFixture]
    public class GestureTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Gesture.Scissors, Gesture.Paper).Returns(true);
                yield return new TestCaseData(Gesture.Paper, Gesture.Rock).Returns(true);
                yield return new TestCaseData(Gesture.Rock, Gesture.Lizard).Returns(true);
                yield return new TestCaseData(Gesture.Lizard, Gesture.Spock).Returns(true);
                yield return new TestCaseData(Gesture.Spock, Gesture.Scissors).Returns(true);
                yield return new TestCaseData(Gesture.Scissors, Gesture.Lizard).Returns(true);
                yield return new TestCaseData(Gesture.Lizard, Gesture.Paper).Returns(true);
                yield return new TestCaseData(Gesture.Paper, Gesture.Spock).Returns(true);
                yield return new TestCaseData(Gesture.Spock, Gesture.Rock).Returns(true);
                yield return new TestCaseData(Gesture.Rock, Gesture.Scissors).Returns(true);
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
