using MineGame.Game.Models;
using MineGame.Game.Settings;

namespace MineGame.Game
{
    public class Minelayer
    {
        private readonly GameSettings settings;
        private readonly Random random;

        public Minelayer(Random random, GameSettings settings)
        {
            this.settings = settings;
            this.random = random;
        }

        public IEnumerable<Location> GenerateField()
        {
            var mineCount = random.Next(settings.MineCountRange!.Minimum, settings.MineCountRange.Maximum + 1);
            var mines = new HashSet<Location>();
            while (mines.Count < mineCount)
            {
                var mine = new Location(random.Next(settings.Dimensions!.Width), random.Next(settings.Dimensions.Height));
                if (!mines.Contains(mine))
                {
                    mines.Add(mine);
                }
            }

            return mines;
        }
    }
}