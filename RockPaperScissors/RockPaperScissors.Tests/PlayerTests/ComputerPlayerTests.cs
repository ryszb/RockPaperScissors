using System.Collections.Generic;
using NUnit.Framework;
using RockPaperScissors.Logic;
using RockPaperScissors.Logic.Core;
using RockPaperScissors.Logic.Players;

namespace RockPaperScissors.Tests.PlayerTests
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
                    Gesture.Rock,
                    Gesture.Paper
                },
                new FakeRandomNumberGenerator());

            Assert.AreEqual(Gesture.Rock, computerPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_UpdatePreviousGesture()
        {
            var computerPlayer = new ComputerPlayer(
                new List<Gesture>
                {
                    Gesture.Rock,
                    Gesture.Paper
                },
                new FakeRandomNumberGenerator());

            computerPlayer.MakeAMove();

            Assert.AreEqual(computerPlayer.PreviousGesture, Gesture.Rock);
        }
    }
}
