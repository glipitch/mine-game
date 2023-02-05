using MineGame.Game.Enums;

namespace MineGame.Hosting
{
    public class StandardKeyMap
    {
        public override string ToString()
        {
            return "Restart: F5\nExit: F4\nMove: arrow keys\n";
        }

        public Input Convert(ConsoleKey key) =>
            key switch
            {
                ConsoleKey.F5 => Input.Reset,
                ConsoleKey.F4 => Input.Exit,
                ConsoleKey.LeftArrow => Input.Left,
                ConsoleKey.RightArrow => Input.Right,
                ConsoleKey.UpArrow => Input.Up,
                ConsoleKey.DownArrow => Input.Down,
                _ => Input.None
            };
    }
}