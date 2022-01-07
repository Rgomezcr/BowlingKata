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
    }
}