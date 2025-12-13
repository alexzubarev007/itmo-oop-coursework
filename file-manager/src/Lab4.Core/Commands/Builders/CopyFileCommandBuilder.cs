using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

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

    public CommandBuilderResult Build()
    {
        if ((_sourcePath == null) ||
            (_destinationPath == null))
        {
            Console.WriteLine("NULLLLLL");
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new CopyFileCommand(_sourcePath, _destinationPath));
    }
}