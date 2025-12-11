using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class RenameFileCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _newName;

    public RenameFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public RenameFileCommandBuilder WithNewName(string newName)
    {
        _newName = newName;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _path is not null && _newName is not null;
    }

    public ICommand Build()
    {
        if ((_path == null) ||
            (_newName == null))
        {
            throw new ArgumentException("Impossible to create rename file command");
        }

        return new RenameFileCommand(_path, _newName);
    }
}