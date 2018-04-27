using System;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class HumanPlayerTests
    {
        [Test]
        public void Ready_Should_ReturnFalse_When_ChosenGestureIsNull()
        {
            Assert.IsFalse(new HumanPlayer().Ready);
        }

        [Test]
        public void Ready_Should_ReturnTrue_When_ChosenGestureIsNotNull()
        {
            var humanPlayer = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            Assert.IsTrue(humanPlayer.Ready);
        }

        [Test]
        public void MakeAMove_Should_ThrowException_When_ChosenGestureIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => new HumanPlayer().MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_ReturnChosenGesture_When_ChosenGestureIsNotNull()
        {
            var humanPlayer = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            Assert.AreEqual(humanPlayer.ChosenGesture, humanPlayer.MakeAMove());
        }

        [Test]
        public void MakeAMove_Should_UpdatePreviousGesture_When_ChosenGestureIsNotNull()
        {
            var humanPlayer = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            humanPlayer.MakeAMove();

            Assert.AreEqual(humanPlayer.PreviousGesture, Rock);
        }
    }
}
