using MineGame.Game;
using MineGame.Game.Enums;
using MineGame.Game.Models;
using static System.Console;
namespace MineGame.Hosting;

public class ConsoleHost(GameEngine gameEngine, StandardKeyMap keyMap, MinimalConsoleTextOutput consoleTextOutput)
{
    private bool exit;
    private void HandleOutput(object sender, OutputEventArgs e)
    {
        Write(consoleTextOutput.Convert(e));
        if (e.Output == Output.Exited)
        {
            exit = true;
        }
    }
    public void Run()
    {
        gameEngine.OutputEmitted += HandleOutput!;
        WriteLine(keyMap);
        gameEngine.Start();
        while (!exit)
        {
            gameEngine.ReceiveInput(StandardKeyMap.Convert(ReadKey(intercept: true).Key));
        }
    }
}
