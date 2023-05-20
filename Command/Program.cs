using System;

public interface ICommand
{
    void Execute();
}

public class MoveCommand : ICommand
{
    private Unit _unit;
    private int _x, _y;

    public MoveCommand(Unit unit, int x, int y)
    {
        _unit = unit;
        _x = x;
        _y = y;
    }

    public void Execute()
    {
        _unit.Move(_x, _y);
    }
}

public class AttackCommand : ICommand
{
    private Unit _unit;
    private Unit _target;

    public AttackCommand(Unit unit, Unit target)
    {
        _unit = unit;
        _target = target;
    }

    public void Execute()
    {
        _unit.Attack(_target);
    }
}

public class DefendCommand : ICommand
{
    private Unit _unit;

    public DefendCommand(Unit unit)
    {
        _unit = unit;
    }

    public void Execute()
    {
        _unit.Defend();
    }
}

public class Unit
{
    public string Name { get; private set; }

    public Unit(string name)
    {
        Name = name;
    }

    public void Move(int x, int y)
    {
        Console.WriteLine($"{Name} moves to ({x}, {y})");
    }

    public void Attack(Unit target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public void Defend()
    {
        Console.WriteLine($"{Name} defends");
    }
}

public class Game
{
    public void RunCommand(ICommand command)
    {
        command.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create units
        Unit knight = new Unit("Knight");
        Unit archer = new Unit("Archer");

        // Create commands
        ICommand moveCommand = new MoveCommand(knight, 3, 2);
        ICommand attackCommand = new AttackCommand(knight, archer);
        ICommand defendCommand = new DefendCommand(archer);

        // Create game
        Game game = new Game();

        // Execute commands
        game.RunCommand(moveCommand);
        game.RunCommand(attackCommand);
        game.RunCommand(defendCommand);

        Console.ReadKey();
    }
}