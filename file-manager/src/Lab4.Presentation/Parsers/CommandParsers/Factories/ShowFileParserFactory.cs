using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ShowFileFlagAppliers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.ShowFileArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class ShowFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<ShowFileCommandBuilder>>
        {
            new ShowFilePathApplier(),
        };

        var flagChain = new WritingModeFlagApplier();

        return new ShowFileCommandParser(positional, flagChain);
    }
}