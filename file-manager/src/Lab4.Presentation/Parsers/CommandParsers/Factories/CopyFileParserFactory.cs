using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.CopyFileArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class CopyFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IPositionalApplierLink<CopyFileCommandBuilder> positionalChain = new CopyFileSourcePathApplier()
            .AddNext(new CopyFileDestinationPathApplier());

        IFlagApplierLink<CopyFileCommandBuilder>? flagChain = null;

        var builder = new CopyFileCommandBuilder();

        return new CommandParser<CopyFileCommandBuilder>(builder, positionalChain, flagChain);
    }
}