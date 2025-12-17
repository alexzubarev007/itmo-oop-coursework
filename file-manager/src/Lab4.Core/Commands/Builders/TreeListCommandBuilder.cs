using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class TreeListCommandBuilder : ICommandBuilder
{
    private int? _depth;
    private FormattingTreeParameters? _parameters;
    private IWriter? _writer;

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public TreeListCommandBuilder WithFormatting(FormattingTreeParameters parameters)
    {
        _parameters = parameters;
        return this;
    }

    public TreeListCommandBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if ((_depth is null) ||
            (_parameters is null) ||
            (_writer is null))
        {
            return new CommandBuilderResult.Failure();
        }

        return new CommandBuilderResult.Success(new TreeListCommand(_depth.Value, _writer, _parameters));
    }
}
