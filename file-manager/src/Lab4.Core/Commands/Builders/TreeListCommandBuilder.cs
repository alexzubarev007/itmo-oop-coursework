using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class TreeListCommandBuilder : ICommandBuilder
{
    private int? _depth;

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_depth is null)
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new TreeListCommand(_depth.Value));
    }
}
