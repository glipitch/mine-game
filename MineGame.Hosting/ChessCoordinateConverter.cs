using MineGame.Game.Models;

using System.Diagnostics.CodeAnalysis;

namespace MineGame.Hosting
{
    public class ChessCoordinateConverter
    {
        private const int UpperCaseAUnicode = 65;
        private const int HighestColumnAllowed = 25;

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public string Convert(Location location)
        {
            if (location.Column > HighestColumnAllowed)
            {
                throw new ArgumentException($"{location.Column} does not convert to letter");
            }
            var chessColumn = (char)(UpperCaseAUnicode + location.Column);
            var chessRow = (location.Row + 1).ToString();
            return chessColumn + chessRow;
        }
    }
}