using MineGame.Game;
using MineGame.Game.Enums;
using MineGame.Game.Models;

using static System.Console;

namespace MineGame.Hosting
{
    public class ConsoleHost
    {
        private readonly GameEngine gameEngine;
        private readonly StandardKeyMap keyMap;
        private readonly MinimalConsoleTextOutput consoleTextOutput;
        private bool exit;

        public ConsoleHost(GameEngine gameEngine, StandardKeyMap keyMap, MinimalConsoleTextOutput consoleTextOutput)
        {
            this.gameEngine = gameEngine;
            this.keyMap = keyMap;
            this.consoleTextOutput = consoleTextOutput;
            this.gameEngine.OutputEmmited += HandleOutput!;
        }

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
            WriteLine(keyMap);
            gameEngine.Start();
            while (!exit)
            {
                gameEngine.ReceiveInput(keyMap.Convert(ReadKey().Key));
            }
        }
    }
}