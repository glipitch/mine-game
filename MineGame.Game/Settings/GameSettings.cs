namespace MineGame.Game.Settings
{
    public record GameSettings
    {
        public Dimensions Dimensions { get; set; }
        public MineCountRange MineCountRange { get; set; }
        public int Lives { get; set; }
    }
}