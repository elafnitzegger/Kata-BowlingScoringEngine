using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class ScoringTests
    {
        private Game g;

        protected void SetUp()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

        [Fact]
        public void ShouldTestAGutterGame()
        {
            //arrange
            SetUp();

            //act
            RollMany(20, 0);

            //assert
            Assert.Equal(0, g.Score());
        }


        [Fact]
        public void ShouldTestAnAllSinglePinsGame()
        {
            //arrange
            SetUp();

            //act
            RollMany(20, 1);

            //assert
            Assert.Equal(20, g.Score());
        }

        [Fact]
        public void ShouldTedstOneSpare()
        {
            //arrange
            SetUp();

            //act
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);

            //assert
            Assert.Equal(16, g.Score());
        }

        [Fact]
        public void ShouldTestOneStrike()
        {
            //arrange
            SetUp();

            //act
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.Score());
        }

        [Fact]
        public void ShouldTestPerfectGame()
        {
            //arrange
            SetUp();

            //act
            RollMany(12, 10);

            //assert
            Assert.Equal(300, g.Score());
        }
        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
