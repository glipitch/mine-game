using MineGame.Game;
using MineGame.Game.Models;
using MineGame.Game.Settings;

using Xunit;

namespace MineGame.Tests
{
    public class PositionCheckerTests
    {
        [Theory]
        [InlineData(2, 2, 0, 0)]
        [InlineData(2, 2, 0, 1)]
        [InlineData(2, 2, 1, 0)]
        [InlineData(2, 2, 1, 1)]
        public void ValidPosition_Returns_Valid(int width, int height, int column, int row)
        {
            var sut = new PositionChecker(new GameSettings { Dimensions = new Dimensions(width, height) });
            var actual = sut.IsLegal(new Location(column, row));
            Assert.True(actual);
        }

        [Theory]
        [InlineData(2, 2, -1, 0)]
        [InlineData(2, 2, 2, 0)]
        [InlineData(2, 2, 0, -1)]
        [InlineData(2, 2, 0, 2)]
        public void InvalidPosition_Returns_Invalid(int width, int height, int column, int row)
        {
            var sut = new PositionChecker(new GameSettings { Dimensions = new Dimensions(width, height) });
            var actual = sut.IsLegal(new Location(column, row));
            Assert.False(actual);
        }
    }
}