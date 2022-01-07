using System;
using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingShould
    {
        [Fact]
        public void NotScoreAnyPointsWhenNoPinsAreKnocked()
        {
            Game game = new();

            game.Roll(0);
            
            Assert.Equal(0,game.Score());
        }

        [Fact]
        public void ScoreAsManyPointsAsPinsAreKnockedDown()
        {
            Game game = new();

            game.Roll(1);
            
            Assert.Equal(1,game.Score());
        }

        [Fact]
        public void FailIfAttemptingToScoreNegativePins()
        {
            Game game = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(-1));
        }
        
        [Fact]
        public void FailIfAttemptingToScoreMoreThanTenPins()
        {
            Game game = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(11));
        }

        [Fact]
        public void AddScoresFromMultipleRolls()
        {
            Game game = new();

            game.Roll(1);
            game.Roll(2);
            
            Assert.Equal(3,game.Score());

        }

        [Fact]
        public void NotKnockMoreThanTenPinsWithinASingleFrame()
        {
            Game game = new();
            
            game.Roll(9);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(9));
        }

        [Fact]
        public void ResetPinsWhenChangingFrame()
        {
            Game game = new();
            
            game.Roll(3);
            game.Roll(6);
            game.Roll(2);
            
            Assert.Equal(11, game.Score());
        }
        
        [Fact]
        public void AddSpareBonusAsValueOfNextRoll()
        {
            Game game = new();
            
            game.Roll(3);
            game.Roll(7);
            game.Roll(5);
            
            Assert.Equal(20, game.Score());
        }
        
        [Fact]
        public void AddStrikeBonusAsValueOfNextTwoRoll()
        {
            Game game = new();
            
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            
            Assert.Equal(28, game.Score());
        }

    }
}