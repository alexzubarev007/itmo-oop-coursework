using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.GoToArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class GoToParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new GoToPathApplier();

        IFlagApplierLink<GoToCommandBuilder>? flagChain = null;

        var builder = new GoToCommandBuilder();

        return new CommandParser<GoToCommandBuilder>(builder, positional, flagChain);
    }
}