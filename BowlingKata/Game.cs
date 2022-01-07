using System;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private const int FramesPerGame = 10;

        private readonly int[] _scorePerFrame = new int[FramesPerGame];
        private int _currentFrame;
        private bool _isSecondRoll;

        public int Score()
        {
            return _scorePerFrame.Sum();
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins + _scorePerFrame[_currentFrame] > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));

            _scorePerFrame[_currentFrame] += pins;

            if (_isSecondRoll)
            {
                _currentFrame++;
                _isSecondRoll = false;
            }
            else
            {
                _isSecondRoll = true;
                if (_currentFrame > 0 && _scorePerFrame[_currentFrame - 1] == 10)
                    _scorePerFrame[_currentFrame - 1] += pins;
            }
        }
    }
}