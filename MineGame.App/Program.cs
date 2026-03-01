using Microsoft.Extensions.DependencyInjection;

using MineGame.Game.Settings;
using MineGame.Hosting;

var settings = new GameSettings
{
    Dimensions = new Dimensions(Width: 8, Height: 8),
    MineCountRange = new MineCountRange(Minimum: 15, Maximum: 20),
    Lives = 3
};

var serviceProviderOptions = new ServiceProviderOptions
{
    ValidateScopes = true,
    ValidateOnBuild = true
};

using var serviceProvider = new ServiceCollection()
    .AddMineGame(settings)
    .BuildServiceProvider(serviceProviderOptions);

var host = serviceProvider.GetRequiredService<ConsoleHost>();
try
{
    host.Run();
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
    Environment.ExitCode = 1;
}
