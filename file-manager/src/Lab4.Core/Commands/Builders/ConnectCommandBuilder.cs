using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class ConnectCommandBuilder : ICommandBuilder
{
    private string? _connectionPath;
    private IFileSystemFactory? _fileSystemFactory;

    public ConnectCommandBuilder WithConnectionPath(string connectionPath)
    {
        _connectionPath = connectionPath;
        return this;
    }

    public ConnectCommandBuilder WithFileSystemFactory(IFileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_connectionPath is null
            || _fileSystemFactory is null)
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new ConnectCommand(_connectionPath, _fileSystemFactory));
    }
}