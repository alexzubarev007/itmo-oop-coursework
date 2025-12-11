using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class DeleteFileCommandBuilder : ICommandBuilder
{
    private string? _path;

    public DeleteFileCommandBuilder WithPath(string path)
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
        if (_path is null)
        {
            throw new ArgumentException("Impossible to create delete file command");
        }

        return new DeleteFileCommand(_path);
    }
}