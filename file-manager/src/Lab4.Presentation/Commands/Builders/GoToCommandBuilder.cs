using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class GoToCommandBuilder : ICommandBuilder
{
    private string? _path;

    public GoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _path is not null;
    }

    public ICommand Build()
    {
        if (_path == null)
        {
            throw new ArgumentException("Impossible to create go to path command");
        }

        return new GoToCommand(_path);
    }
}