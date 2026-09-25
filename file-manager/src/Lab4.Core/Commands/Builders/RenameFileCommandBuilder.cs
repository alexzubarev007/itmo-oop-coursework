using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

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

    public CommandBuilderResult Build()
    {
        if ((_path == null) ||
            (_newName == null))
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new RenameFileCommand(_path, _newName));
    }
}