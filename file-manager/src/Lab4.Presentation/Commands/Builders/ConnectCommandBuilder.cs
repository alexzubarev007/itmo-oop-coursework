using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class ConnectCommandBuilder : ICommandBuilder
{
    private string? _connectionPath;
    private string _mode = "local";

    public ConnectCommandBuilder WithConnectionPath(string connectionPath)
    {
        _connectionPath = connectionPath;
        return this;
    }

    public ConnectCommandBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _connectionPath is not null;
    }

    public ICommand Build()
    {
        if (_connectionPath is null || _mode is null)
        {
            throw new ArgumentException("Impossible to create connect command");
        }

        return new ConnectCommand(_connectionPath, _mode);
    }
}