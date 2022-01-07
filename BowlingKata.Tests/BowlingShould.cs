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
    }
}