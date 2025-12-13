using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

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

    public CommandBuilderResult Build()
    {
        if ((_sourcePath == null) ||
            (_destinationPath == null))
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new MoveFileCommand(_sourcePath, _destinationPath));
    }
}