using MineGame.Game.Models;
using MineGame.Game.Settings;

namespace MineGame.Game
{
    public class PositionChecker
    {
        private GameSettings settings;

        public PositionChecker(GameSettings settings)
        {
            this.settings = settings;
        }

        public bool IsLegal(Location position)
        {
            if (position.Column < 0 || position.Column > settings.Dimensions.Width - 1)
            {
                return false;
            }
            if (position.Row < 0 || position.Row > settings.Dimensions.Height - 1)
            {
                return false;
            }
            return true;
        }
    }
}