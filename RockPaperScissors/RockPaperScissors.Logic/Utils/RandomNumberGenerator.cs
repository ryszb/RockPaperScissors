﻿using System;

namespace RockPaperScissors.Logic.Utils
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            return random.Next(minValue, maxValue);
        }
    }
}