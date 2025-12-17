using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.TreeListFlagAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class TreeListParserFactory : ICommandParserFactory
{
    private readonly FormattingTreeParameters _parameters;
    private readonly IWriter _writer;

    public TreeListParserFactory(
        FormattingTreeParameters parameters,
        IWriter writer)
    {
        _parameters = parameters;
        _writer = writer;
    }

    public ICommandParser Create()
    {
        IPositionalApplierLink<TreeListCommandBuilder>? positionalChain = null;

        var flagChain = new DepthFlagApplier();

        TreeListCommandBuilder builder = new TreeListCommandBuilder()
                                             .WithFormatting(_parameters)
                                             .WithWriter(_writer);

        return new CommandParser<TreeListCommandBuilder>(builder, positionalChain, flagChain);
    }
}