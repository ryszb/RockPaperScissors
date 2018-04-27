using RockPaperScissors.Logic;

namespace RockPaperScissors.Tests
{
    public class FakeRandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            return minValue;
        }
    }
}
