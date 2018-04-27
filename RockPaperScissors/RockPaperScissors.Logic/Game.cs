using System;

using static RockPaperScissors.Logic.RoundResult;

namespace RockPaperScissors.Logic
{
    public class Game : Entity
    {
        public Player PlayerOne { get; }

        public Player PlayerTwo { get; }

        public int MaxNumberOfRounds { get; }

        public int PlayerOneScore { get; private set; }

        public int PlayerTwoScore { get; private set; }

        public bool PlayerOneIsAWinner => PlayerOneScore > MaxNumberOfRounds / 2;

        public bool PlayerTwoIsAWinner => PlayerTwoScore > MaxNumberOfRounds / 2;

        public bool CanThrow => PlayerOne.Ready && PlayerTwo.Ready && !PlayerOneIsAWinner && !PlayerTwoIsAWinner;

        public Game(Player playerOne, Player playerTwo, int maxNumberOfRounds)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            MaxNumberOfRounds = maxNumberOfRounds;
        }

        public void Throw()
        {
            if (!CanThrow)
            {
                throw new InvalidOperationException();
            }

            var currentRound = new Round(PlayerOne.MakeAMove(), PlayerTwo.MakeAMove());

            UpdateScore(currentRound.FinishRound());
        }

        public void SetPlayerGesture(Gesture gesture)
        {
            if (CanThrow)
            {
                throw new InvalidOperationException();
            }

            if (PlayerOne is HumanPlayer playerOne && !PlayerOne.Ready)
            {
                playerOne.ChosenGesture = gesture;
            }
            else if (PlayerTwo is HumanPlayer playerTwo && !PlayerTwo.Ready)
            {
                playerTwo.ChosenGesture = gesture;
            }
        }

        private void UpdateScore(RoundResult result)
        {
            if (result == PlayerOneWins)
            {
                PlayerOneScore += 1;
            }
            else if (result == PlayerTwoWins)
            {
                PlayerTwoScore += 1;
            }
        }
    }
}
