using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.TreeListFlagAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class TreeListParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IPositionalApplierLink<TreeListCommandBuilder>? positionalChain = null;

        var flagChain = new DepthFlagApplier();

        return new CommandParser<TreeListCommandBuilder>(positionalChain, flagChain);
    }
}