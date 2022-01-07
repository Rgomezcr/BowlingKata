using System;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private const int FramesPerGame = 10;

        private int[] _pins = new int[FramesPerGame];
        private int _currentFrame = 0;
        private bool _isSecondRoll = false;

        public int Score()
        {
            return _pins.Sum();
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins + _pins[_currentFrame] > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));

            _pins[_currentFrame] += pins;

            if (_isSecondRoll)
            {
                _currentFrame++;
                _isSecondRoll = false;
            }
            else
            {
                _isSecondRoll = true;
            }
        }
    }
}