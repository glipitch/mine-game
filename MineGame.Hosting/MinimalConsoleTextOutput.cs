using MineGame.Game.Enums;
using MineGame.Game.Models;

namespace MineGame.Hosting;

public class MinimalConsoleTextOutput
{
    private readonly ChessCoordinateConverter? coordinateConverter;

    public MinimalConsoleTextOutput(ChessCoordinateConverter? coordinateConverter = null)
    {
        this.coordinateConverter = coordinateConverter;
    }

    public string Convert(OutputEventArgs e) =>
        e.Output switch
        {
            Output.Started => $"Game started\n{e.Dimensions}\nInitial position: {ConvertCoordinates(e.Location!)}\nLives: {e.Lives}\n",
            Output.Exited => "Game exiting\n",
            Output.Hit => $"Hit {ConvertCoordinates(e.Location!)} Moves: {e.Moves} Lives: {e.Lives}\n",
            Output.Miss => $"Miss {ConvertCoordinates(e.Location!)} Moves: {e.Moves} Lives: {e.Lives}\n",
            Output.Won => $"Won\n",
            Output.Lost => $"Lost\n",
            Output.Invalid => string.Empty,
            _ => throw new NotImplementedException(),
        };

    public string ConvertCoordinates(Location location)
        => coordinateConverter == null
        ? location.ToString()
        : coordinateConverter.Convert(location);
}