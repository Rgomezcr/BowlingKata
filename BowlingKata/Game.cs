using System;

namespace BowlingKata
{
    public class Game
    {
        private int _pins;


        public int Score()
        {
            return _pins;
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));
            _pins = pins;
        }
    }
}