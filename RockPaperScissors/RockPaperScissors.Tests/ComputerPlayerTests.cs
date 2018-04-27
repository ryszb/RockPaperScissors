using System.Collections.Generic;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class ComputerPlayerTests
    {
        [Test]
        public void MakeAMove_Should_ReturnRandomGesture()
        {
            var computerPlayer = new ComputerPlayer(
                new List<Gesture>
                {
                    Rock,
                    Paper
                },
                new FakeRandomNumberGenerator());

            Assert.AreEqual(Rock, computerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_UpdatePreviousGesture()
        {
            var computerPlayer = new ComputerPlayer(
                new List<Gesture>
                {
                    Rock,
                    Paper
                },
                new FakeRandomNumberGenerator());

            computerPlayer.MakeAMove();

            Assert.AreEqual(computerPlayer.PreviousGesture, Rock);
        }
    }
}
