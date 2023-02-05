using MineGame.Game.Models;
using MineGame.Hosting;

using Xunit;

namespace MineGame.Tests
{
    public class ChessCoordinatesConverterTests
    {
        [Theory]
        [InlineData(0, 0, "A1")]
        [InlineData(2, 1, "C2")]
        [InlineData(25, 999, "Z1000")]
        public void ValidLocation_Returns_ChessCoordinate(int column, int row, string expected)
        {
            var sut = new ChessCoordinateConverter();
            var actual = sut.Convert(new Location(column, row));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InvalidLocation_Throws_ArgumentException()
        {
            var sut = new ChessCoordinateConverter();

            Assert.Throws<ArgumentException>(() => sut.Convert(new Location(26, 0)));
        }
    }
}