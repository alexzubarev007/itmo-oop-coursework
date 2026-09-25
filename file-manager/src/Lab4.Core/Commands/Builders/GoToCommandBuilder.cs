using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class GoToCommandBuilder : ICommandBuilder
{
    private string? _path;

    public GoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_path == null)
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new GoToCommand(_path));
    }
}