using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class DisconnectParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IPositionalApplierLink<DisconnectCommandBuilder>? positionalChain = null;

        IFlagApplierLink<DisconnectCommandBuilder>? flagChain = null;

        var builder = new DisconnectCommandBuilder();

        return new CommandParser<DisconnectCommandBuilder>(builder, positionalChain, flagChain);
    }
}