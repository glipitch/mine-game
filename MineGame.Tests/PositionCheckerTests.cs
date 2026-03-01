using MineGame.Game;
using MineGame.Game.Models;
using MineGame.Game.Settings;
namespace MineGame.Tests;

public class PositionCheckerTests
{
    [Test]
    [Arguments(2, 2, 0, 0)]
    [Arguments(2, 2, 0, 1)]
    [Arguments(2, 2, 1, 0)]
    [Arguments(2, 2, 1, 1)]
    public async Task ValidPosition_Returns_Valid(int width, int height, int column, int row)
    {
        var sut = new PositionChecker(new GameSettings { Dimensions = new Dimensions(width, height) });
        var actual = sut.IsLegal(new Location(column, row));
        await Assert.That(actual).IsTrue();
    }
    [Test]
    [Arguments(2, 2, -1, 0)]
    [Arguments(2, 2, 2, 0)]
    [Arguments(2, 2, 0, -1)]
    [Arguments(2, 2, 0, 2)]
    public async Task InvalidPosition_Returns_Invalid(int width, int height, int column, int row)
    {
        var sut = new PositionChecker(new GameSettings { Dimensions = new Dimensions(width, height) });
        var actual = sut.IsLegal(new Location(column, row));
        await Assert.That(actual).IsFalse();
    }
}
