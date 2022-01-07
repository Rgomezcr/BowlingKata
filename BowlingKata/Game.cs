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
            if (pins is < 0 or > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));
            if(pins +_pins > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));
            _pins += pins;
        }
    }
}