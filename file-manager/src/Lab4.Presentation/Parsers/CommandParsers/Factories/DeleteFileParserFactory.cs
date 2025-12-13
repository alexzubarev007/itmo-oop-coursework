using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.DeleteFileArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class DeleteFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positionalChain = new DeleteFilePathApplierLink();

        IFlagApplierLink<DeleteFileCommandBuilder>? flagChain = null;

        return new CommandParser<DeleteFileCommandBuilder>(positionalChain, flagChain);
    }
}