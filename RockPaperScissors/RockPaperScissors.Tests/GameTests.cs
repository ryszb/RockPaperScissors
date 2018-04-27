using System;

using NUnit.Framework;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Throw_Should_UpdatePlayerOneScore_BasedOn_RoundResult()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Rock
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 1);
            game.Throw();

            Assert.AreEqual(game.PlayerOneScore, 1);
            Assert.AreEqual(game.PlayerTwoScore, 0);
        }

        [Test]
        public void Throw_Should_UpdatePlayerTwoScore_BasedOn_RoundResult()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Scissors
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            var game = new Game(playerOne, playerTwo, 1);
            game.Throw();

            Assert.AreEqual(game.PlayerOneScore, 0);
            Assert.AreEqual(game.PlayerTwoScore, 1);
        }

        [Test]
        public void Throw_ShouldNot_UpdatePlayersScore_When_RoundResultIsADraw()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Rock
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            var game = new Game(playerOne, playerTwo, 1);
            game.Throw();

            Assert.AreEqual(game.PlayerOneScore, 0);
            Assert.AreEqual(game.PlayerTwoScore, 0);
        }

        [Test]
        public void PlayerOneIsAWinner_Should_CorrectlyMarkPlayerOneAsAWinner_When_PlayerOneWonMajorityOfRounds()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Rock
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 3);
            game.Throw();

            playerOne.ChosenGesture = Rock;
            playerTwo.ChosenGesture = Scissors;

            game.Throw();

            Assert.IsTrue(game.PlayerOneIsAWinner);
        }

        [Test]
        public void PlayerTwoIsAWinner_Should_CorrectlyMarkPlayerTwoAsAWinner_When_PlayerTwoWonMajorityOfRounds()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Scissors
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Rock
            };

            var game = new Game(playerOne, playerTwo, 3);
            game.Throw();

            playerOne.ChosenGesture = Scissors;
            playerTwo.ChosenGesture = Rock;

            game.Throw();

            Assert.IsTrue(game.PlayerTwoIsAWinner);
        }

        [Test]
        public void CanThrow_Should_ReturnFalse_When_PlayerOneIsNotReady()
        {
            var playerOne = new HumanPlayer();
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 1);

            Assert.IsFalse(game.CanThrow);
        }

        [Test]
        public void CanThrow_Should_ReturnFalse_When_PlayerTwoIsNotReady()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Scissors
            };
            var playerTwo = new HumanPlayer();

            var game = new Game(playerOne, playerTwo, 1);

            Assert.IsFalse(game.CanThrow);
        }

        [Test]
        public void CanThrow_Should_ReturnFalse_When_PlayerOneIsDeclaredAWinner()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Scissors
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Paper
            };

            var game = new Game(playerOne, playerTwo, 1);
            game.Throw();

            playerOne.ChosenGesture = Scissors;
            playerTwo.ChosenGesture = Paper;

            Assert.IsFalse(game.CanThrow);
        }

        [Test]
        public void CanThrow_Should_ReturnFalse_When_PlayerTwoIsDeclaredAWinner()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Paper
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 1);
            game.Throw();

            playerOne.ChosenGesture = Paper;
            playerTwo.ChosenGesture = Scissors;

            Assert.IsFalse(game.CanThrow);
        }

        [Test]
        public void CanThrow_Should_ReturnTrue_When_NeitherOfPlayersAreDeclaredAsWinners_And_BothPlayersAreReady()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Paper
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 3);

            Assert.IsTrue(game.CanThrow);
        }

        [Test]
        public void Throw_Should_ThrowException_When_CanThrowIsFalse()
        {
            var game = new Game(new HumanPlayer(), new HumanPlayer(), 3);

            Assert.Throws<InvalidOperationException>(() => game.Throw());
        }

        [Test]
        public void SetPlayerGesture_Should_ThrowException_When_CanThrowIsTrue()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Rock
            };
            var playerTwo = new HumanPlayer
            {
                ChosenGesture = Scissors
            };

            var game = new Game(playerOne, playerTwo, 3);

            Assert.Throws<InvalidOperationException>(() => game.SetPlayerGesture(Rock));
        }

        [Test]
        public void SetPlayerGesture_Should_SetPlayerOneGesture_When_PlayerOneIsNotReady()
        {
            var playerOne = new HumanPlayer();

            var game = new Game(playerOne, new HumanPlayer(), 3);
            game.SetPlayerGesture(Rock);

            Assert.AreEqual(playerOne.ChosenGesture, Rock);
        }

        [Test]
        public void SetPlayerGesture_Should_SetPlayerTwoGesture_When_OnlyPlayerTwoIsNotReady()
        {
            var playerOne = new HumanPlayer
            {
                ChosenGesture = Rock
            };
            var playerTwo = new HumanPlayer();

            var game = new Game(playerOne, playerTwo, 3);
            game.SetPlayerGesture(Rock);

            Assert.AreEqual(playerTwo.ChosenGesture, Rock);
        }
    }
}
