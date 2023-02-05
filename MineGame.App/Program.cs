using Microsoft.Extensions.DependencyInjection;

using MineGame.Game;
using MineGame.Game.Settings;
using MineGame.Hosting;

var settings = new GameSettings
{
    Dimensions = new Dimensions(Width: 8, Height: 8),
    MineCountRange = new MineCountRange(Minimum: 8, Maximum: 12),
    Lives = 3
};

var serviceProvider = new ServiceCollection()
    .AddSingleton(settings)
    .AddSingleton<Random>()
    .AddSingleton<Minelayer>()
    .AddSingleton<PositionChecker>()
    .AddSingleton<GameEngine>()
    .AddSingleton<ChessCoordinateConverter>()
    .AddSingleton<MinimalConsoleTextOutput>()
    .AddSingleton<StandardKeyMap>()
    .AddSingleton<ConsoleHost>()
    .BuildServiceProvider();

var host = serviceProvider.GetService<ConsoleHost>();

host.Run();