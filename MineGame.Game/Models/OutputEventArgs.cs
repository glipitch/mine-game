using MineGame.Game.Enums;
using MineGame.Game.Settings;

namespace MineGame.Game.Models
{
    public class OutputEventArgs : EventArgs
    {
        internal OutputEventArgs(
            Output output,
            Location location = null,
            int? lives = null,
            Dimensions dimensions = null,
            int? moves = null)
        {
            Output = output;
            Location = location;
            Lives = lives;
            Dimensions = dimensions;
            Moves = moves;
        }

        public Location Location { get; }
        public int? Lives { get; }
        public Dimensions Dimensions { get; }
        public int? Moves { get; }
        public Output Output { get; }
    }
}