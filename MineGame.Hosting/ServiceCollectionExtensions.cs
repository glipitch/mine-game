using Microsoft.Extensions.DependencyInjection;
using MineGame.Game;
using MineGame.Game.Settings;
namespace MineGame.Hosting;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMineGame(this IServiceCollection services, GameSettings settings)
    {
        return services
            .AddSingleton(settings)
            .AddSingleton(Random.Shared)
            .AddSingleton<Minelayer>()
            .AddSingleton<PositionChecker>()
            .AddSingleton<GameEngine>()
            .AddSingleton<ChessCoordinateConverter>()
            .AddSingleton<MinimalConsoleTextOutput>()
            .AddSingleton<StandardKeyMap>()
            .AddSingleton<ConsoleHost>();
    }
}
