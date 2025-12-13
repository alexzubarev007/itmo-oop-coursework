using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class ShowFileCommandBuilder : ICommandBuilder
{
    private string? _path;
    private IWriter? _writer;

    public ShowFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ShowFileCommandBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if ((_path is null) ||
            (_writer is null))
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new ShowFileCommand(_path, _writer));
    }
}