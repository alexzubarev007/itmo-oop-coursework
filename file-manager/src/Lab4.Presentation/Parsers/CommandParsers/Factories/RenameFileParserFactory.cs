using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.RenameFileArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class RenameFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        IPositionalApplierLink<RenameFileCommandBuilder> positionalChain = new RenameFilePathApplier()
            .AddNext(new RenameFileNewNameApplier());

        IFlagApplierLink<RenameFileCommandBuilder>? flagChain = null;

        return new CommandParser<RenameFileCommandBuilder>(positionalChain, flagChain);
    }
}