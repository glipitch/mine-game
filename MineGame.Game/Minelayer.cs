using MineGame.Game.Models;
using MineGame.Game.Settings;

namespace MineGame.Game;

public class Minelayer(Random random, GameSettings settings)
{
    public IEnumerable<Location> GenerateField()
    {
        var mineCount = random.Next(settings.MineCountRange!.Minimum, settings.MineCountRange.Maximum + 1);
        var mines = new HashSet<Location>();
        while (mines.Count < mineCount)
        {
            var mine = new Location(random.Next(settings.Dimensions!.Width), random.Next(settings.Dimensions.Height));
            mines.Add(mine);
        }

        return mines;
    }
}
