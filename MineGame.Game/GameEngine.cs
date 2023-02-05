using MineGame.Game.Enums;
using MineGame.Game.Models;
using MineGame.Game.Settings;

namespace MineGame.Game;

public class GameEngine
{
    private readonly Minelayer minelayer;
    private readonly GameSettings settings;
    private readonly PositionChecker positionChecker;
    private readonly Random random;
    private int moves;
    private int livesRemaining;

    private Location? location;
    private IEnumerable<Location>? mines;
    private bool gameOver;

    public GameEngine(Random random, Minelayer minelayer, GameSettings settings, PositionChecker positionChecker)
    {
        this.random = random;
        this.minelayer = minelayer;
        this.settings = settings;
        this.positionChecker = positionChecker;
    }

    public event EventHandler<OutputEventArgs>? OutputEmmited;

    public void ReceiveInput(Input input)
    {
        switch (input)
        {
            case Input.Reset:
                Start();
                return;

            case Input.None:
                return;

            case Input.Exit:
                EmitOutput(Output.Exited);
                return;

            default:

                if (gameOver)
                {
                    return;
                }
                var newPosition = CalculateNewPosition(input);

                if (!positionChecker.IsLegal(newPosition))
                {
                    EmitOutput(Output.Invalid);
                    return;
                }

                Move(newPosition);
                return;
        }
    }

    private void Move(Location newPosition)
    {
        moves++;
        location = newPosition;
        if (mines!.Contains(location))
        {
            livesRemaining--;

            EmitOutput(Output.Hit);
            if (livesRemaining < 0)
            {
                EmitOutput(Output.Lost);
                gameOver = true;
                return;
            }
        }
        else
        {
            EmitOutput(Output.Miss);
        }
        if (location.Column == settings.Dimensions!.Width - 1)
        {
            EmitOutput(Output.Won);
            gameOver = true;
        }
    }

    private Location CalculateNewPosition(Input input) => input switch
    {
        Input.Left => new Location(location!.Column - 1, location.Row),
        Input.Right => new Location(location!.Column + 1, location.Row),
        Input.Up => new Location(location!.Column, location.Row + 1),
        Input.Down => new Location(location!.Column, location.Row - 1),
        _ => throw new ArgumentException("Invalid location"),
    };

    public void Start()
    {
        gameOver = false;
        moves = 0;
        livesRemaining = settings.Lives;
        //generate initial position on column 0
        location = new Location(0, random.Next(settings.Dimensions!.Height + 1));

        EmitOutput(Output.Started);

        mines = minelayer.GenerateField();
    }

    private void EmitOutput(Output output)
    {
        switch (output)
        {
            case Output.Started:
                OutputEmmited?.Invoke(this, new OutputEventArgs(output, location, settings.Lives, settings.Dimensions));
                return;

            case Output.Hit:
            case Output.Miss:
                OutputEmmited?.Invoke(this, new OutputEventArgs(output, location, livesRemaining, moves: moves));
                return;

            case Output.Exited:
            case Output.Invalid:
            case Output.Won:
            case Output.Lost:
                OutputEmmited?.Invoke(this, new OutputEventArgs(output));
                return;
        }
    }
}