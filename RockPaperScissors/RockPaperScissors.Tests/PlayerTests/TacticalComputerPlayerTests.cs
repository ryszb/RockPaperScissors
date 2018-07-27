using System.Collections.Generic;
using NUnit.Framework;
using RockPaperScissors.Logic;
using RockPaperScissors.Logic.Core;
using RockPaperScissors.Logic.Players;

namespace RockPaperScissors.Tests.PlayerTests
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
                    Gesture.Rock,
                    Gesture.Paper,
                    Gesture.Scissors
                },
                new FakeRandomNumberGenerator());

            Assert.AreEqual(Gesture.Rock, tacticalComputerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_ReturnGestureThatBeatsPreviousGesture_When_ItsNotAFirstMove()
        {
            var tacticalComputerPlayer = new TacticalComputerPlayer(
                new List<Gesture>
                {
                    Gesture.Rock,
                    Gesture.Paper,
                    Gesture.Scissors
                },
                new FakeRandomNumberGenerator());

            tacticalComputerPlayer.MakeAMove();

            Assert.AreEqual(Gesture.Paper, tacticalComputerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_UpdatePreviousGesture()
        {
            var tacticalComputerPlayer = new TacticalComputerPlayer(
                new List<Gesture>
                {
                    Gesture.Rock,
                    Gesture.Paper
                },
                new FakeRandomNumberGenerator());

            tacticalComputerPlayer.MakeAMove();
            tacticalComputerPlayer.MakeAMove();

            Assert.AreEqual(tacticalComputerPlayer.PreviousGesture, Gesture.Paper);
        }
    }
}
