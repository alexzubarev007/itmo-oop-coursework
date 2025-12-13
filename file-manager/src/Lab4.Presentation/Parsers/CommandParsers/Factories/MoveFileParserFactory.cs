using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.MoveFileArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class MoveFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IPositionalApplierLink<MoveFileCommandBuilder> positionalChain = new MoveFileSourcePathApplier()
            .AddNext(new MoveFileDestinationPathApplier());

        IFlagApplierLink<MoveFileCommandBuilder>? flagChain = null;

        return new CommandParser<MoveFileCommandBuilder>(positionalChain, flagChain);
    }
}