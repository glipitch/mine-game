using MineGame.Game.Models;
using MineGame.Hosting;
namespace MineGame.Tests;

public class ChessCoordinatesConverterTests
{
    [Test]
    [Arguments(0, 0, "A1")]
    [Arguments(2, 1, "C2")]
    [Arguments(25, 999, "Z1000")]
    public async Task ValidLocation_Returns_ChessCoordinate(int column, int row, string expected)
    {
        var actual = ChessCoordinateConverter.Convert(new Location(column, row));
        await Assert.That(actual).IsEqualTo(expected);
    }
    [Test]
    public async Task InvalidLocation_Throws_ArgumentException()
    {
        await Assert.That(() => ChessCoordinateConverter.Convert(new Location(26, 0))).ThrowsExactly<ArgumentException>();
    }
}
