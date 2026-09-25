using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactoryLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ConnectFlagAppliers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.ConnectArgumentApplierLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class ConnectParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positionalChain = new ConnectConnectionPathApplier();
        var flagChain = new FileSystemModeFlagApplier(new LocalFileSystemFactoryLink());

        ConnectCommandBuilder builder = new ConnectCommandBuilder()
                      .WithFileSystemFactory(new LocalFileSystemFactory());

        return new CommandParser<ConnectCommandBuilder>(builder, positionalChain, flagChain);
    }
}