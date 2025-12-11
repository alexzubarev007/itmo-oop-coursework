using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.DeleteFileArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class DeleteFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<DeleteFileCommandBuilder>>
        {
            new DeleteFilePathApplier(),
        };

        IFlagApplierLink<DeleteFileCommandBuilder>? flagChain = null;

        return new DeleteFileCommandParser(positional, flagChain);
    }
}