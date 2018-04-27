namespace RockPaperScissors.Logic
{
    public interface IRandomNumberGenerator
    {
        int GenerateRandomNumber(int minValue, int maxValue);
    }
}