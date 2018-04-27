using System.Collections.Generic;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class TacticalComputerPlayerTests
    {
        [Test]
        public void MakeAMove_Should_ReturnRandomGesture_When_ItsAFirstMove()
        {
            var tacticalComputerPlayer = new TacticalComputerPlayer(
                new List<Gesture>
                {
                    Rock,
                    Paper,
                    Scissors
                },
                new FakeRandomNumberGenerator());

            Assert.AreEqual(Rock, tacticalComputerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_ReturnGestureThatBeatsPreviousGesture_When_ItsNotAFirstMove()
        {
            var tacticalComputerPlayer = new TacticalComputerPlayer(
                new List<Gesture>
                {
                    Rock,
                    Paper,
                    Scissors
                },
                new FakeRandomNumberGenerator());

            tacticalComputerPlayer.MakeAMove();

            Assert.AreEqual(Paper, tacticalComputerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_UpdatePreviousGesture()
        {
            var tacticalComputerPlayer = new TacticalComputerPlayer(
                new List<Gesture>
                {
                    Rock,
                    Paper
                },
                new FakeRandomNumberGenerator());

            tacticalComputerPlayer.MakeAMove();
            tacticalComputerPlayer.MakeAMove();

            Assert.AreEqual(tacticalComputerPlayer.PreviousGesture, Paper);
        }
    }
}
