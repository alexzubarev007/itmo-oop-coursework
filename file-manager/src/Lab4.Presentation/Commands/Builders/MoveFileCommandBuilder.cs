using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class MoveFileCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public MoveFileCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public MoveFileCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _sourcePath is not null && _destinationPath is not null;
    }

    public ICommand Build()
    {
        if ((_sourcePath == null) ||
            (_destinationPath == null))
        {
            throw new ArgumentException("Impossible to create copy file command");
        }

        return new MoveFileCommand(_sourcePath, _destinationPath);
    }
}