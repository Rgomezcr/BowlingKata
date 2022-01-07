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

            AddScoreToCurrentFrame(pins);

            if (IsFirstRoll && pins == 10)
            {
                Strike();
            }
            else if (IsFirstRoll)
            {
                FirstRoll(pins);
            }
            else
            {
                SecondRoll(pins);
            }
        }

        private void AddScoreToCurrentFrame(int pins)
        {
            _scorePerFrame[_currentFrame] += pins;
        }

        private void SecondRoll(int pins)
        {
            if (_wasStrike)
                AddBonusToPreviousFrame(pins);

            _isSecondRoll = false;
            _wasStrike = false;
            _wasSpare = _scorePerFrame[_currentFrame] == 10;
            _currentFrame++;
        }

        private void FirstRoll(int pins)
        {
            _isSecondRoll = true;
            if (_wasSpare || _wasStrike)
                AddBonusToPreviousFrame(pins);
        }

        private void AddBonusToPreviousFrame(int pins)
        {
            _bonusPerFrame[_currentFrame - 1] += pins;
        }

        private void Strike()
        {
            _currentFrame++;
            _wasStrike = true;
        }

        private bool IsFirstRoll => !_isSecondRoll;
    }
}