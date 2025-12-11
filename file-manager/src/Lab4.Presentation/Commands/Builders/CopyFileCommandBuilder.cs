using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class CopyFileCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public CopyFileCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public CopyFileCommandBuilder WithDestinationPath(string destinationPath)
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

        return new CopyFileCommand(_sourcePath, _destinationPath);
    }
}