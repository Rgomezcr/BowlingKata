using System;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private const int FramesPerGame = 10;

        private readonly int[] _scorePerFrame = new int[FramesPerGame];
        private readonly int[] _bonusPerFrame = new int[FramesPerGame];
        private int _currentFrame;
        private bool _isSecondRoll;
        private bool _wasStrike;
        private bool _wasSpare;

        public int Score()
        {
            return _scorePerFrame.Sum() + _bonusPerFrame.Sum();
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins + _scorePerFrame[_currentFrame] > 10)
                throw new ArgumentOutOfRangeException(nameof(pins));

            _scorePerFrame[_currentFrame] += pins;

            if (_isSecondRoll)
            {
                if (_wasStrike)
                    _bonusPerFrame[_currentFrame - 1] += pins;
                
                _isSecondRoll = false;   
                _wasStrike = false;
                _wasSpare = _scorePerFrame[_currentFrame] == 10;
                _currentFrame++;
            }
            else
            {
                if (pins == 10)
                {
                    _currentFrame++;
                    _wasStrike = true;
                }
                else
                {
                    _isSecondRoll = true;
                    if (_wasSpare || _wasStrike)
                        _bonusPerFrame[_currentFrame - 1] += pins;
                }
            }
        }
    }
}