using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ShowFileFlagAppliers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.ShowFileArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class ShowFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positionalChain = new ShowFilePathApplier();

        var flagChain = new WritingModeFlagApplier(new ConsoleWriterLink());

        var builder = new ShowFileCommandBuilder();

        return new CommandParser<ShowFileCommandBuilder>(builder, positionalChain, flagChain);
    }
}