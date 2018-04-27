using System;

namespace RockPaperScissors.Logic
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            var random = new Random();

            return random.Next(minValue, maxValue);
        }
    }
}