using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

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

    public CommandBuilderResult Build()
    {
        if (_path is null)
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new DeleteFileCommand(_path));
    }
}