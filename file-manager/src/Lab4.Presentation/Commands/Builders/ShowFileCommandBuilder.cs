using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class ShowFileCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _writingMode;

    public ShowFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ShowFileCommandBuilder WithWritingMode(string writingMode)
    {
        _writingMode = writingMode;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _path is not null &&
               _writingMode is not null;
    }

    public ICommand Build()
    {
        if ((_path is null) ||
            (_writingMode is null))
        {
            throw new ArgumentException("Impossible to create get file content command");
        }

        return new ShowFileCommand(_path, _writingMode);
    }
}