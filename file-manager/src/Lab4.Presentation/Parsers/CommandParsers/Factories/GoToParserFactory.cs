using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.GoToArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class GoToParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<GoToCommandBuilder>>()
        {
            new GoToPathApplier(),
        };

        IFlagApplierLink<GoToCommandBuilder>? flagChain = null;

        return new GoToCommandParser(positional, flagChain);
    }
}