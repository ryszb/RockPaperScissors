using System;
using System.Collections.Generic;

namespace RockPaperScissors.Logic
{
    public class Gesture : ValueObject<Gesture>
    {
        public static readonly Gesture Rock = new Gesture(1, "Rock");
        public static readonly Gesture Paper = new Gesture(2, "Paper");
        public static readonly Gesture Scissors = new Gesture(3, "Scissors");
        public static readonly Gesture Lizard = new Gesture(5, "Lizard");
        public static readonly Gesture Spock = new Gesture(4, "Spock");

        public int Idx { get; }

        public string Name { get; }

        private Gesture(int idx, string name)
        {
            Idx = idx;
            Name = name;
        }

        public static bool operator >(Gesture gestureA, Gesture gestureB)
        {
            return gestureA != gestureB && IsBigger(gestureA.Idx, gestureB.Idx);
        }

        public static bool operator <(Gesture gestureA, Gesture gestureB)
        {
            return gestureA != gestureB && !IsBigger(gestureA.Idx, gestureB.Idx);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Idx;
        }

        private static bool IsBigger(int x, int y)
        {
            var maxIdx = Math.Max(x, y);
            var upperBound = IsOdd(maxIdx) ? maxIdx : maxIdx + 1;

            for (var i = 1; i <= upperBound / 2; i++)
            {
                if (y == (x + 2 * i - 1) % upperBound + 1)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}