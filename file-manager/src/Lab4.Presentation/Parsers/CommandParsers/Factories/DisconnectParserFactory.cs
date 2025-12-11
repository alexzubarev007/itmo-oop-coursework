using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class DisconnectParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IReadOnlyList<IPositionalApplier<DisconnectCommandBuilder>> positional =
            new List<IPositionalApplier<DisconnectCommandBuilder>>();

        IFlagApplierLink<DisconnectCommandBuilder>? flagChain = null;

        return new DisconnectCommandParser(positional, flagChain);
    }
}