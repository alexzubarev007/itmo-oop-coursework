using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        FileSystemController controller = new();
        var parser = new Parser(new DefaultCommandChainFactory()
                                .Create());
        IWriterLink writerRegimeChain = new ConsoleWriterLink();
        IWriter writer = new ConsoleWriter();
        string? commandLine;

        while ((commandLine = Console.ReadLine()) != null)
        {
            ParsingResult result = parser.Parse(commandLine);

            switch (result)
            {
                case ParsingResult.Success success:
                    ICommand command = success.Command;

                    if (command is TreeListCommand treeListCommand)
                    {
                        var parameters = new FormattingTreeParameters("*", "$", "|||");
                        treeListCommand.Parameters = parameters;
                        treeListCommand.Writer = writer;
                    }

                    if (command is ShowFileCommand showFileCommand)
                    {
                        showFileCommand.WritingRegimeChain = writerRegimeChain;
                    }

                    OperationResult commandResult = success.Command.Execute(controller);

                    if (commandResult is OperationResult.Success commandSuccess)
                    {
                        Console.WriteLine("Command successfully executed");
                    }
                    else if (commandResult is OperationResult.Failure commandFailure)
                    {
                        Console.WriteLine(commandFailure.Error.Message());
                    }
                    else
                    {
                        Console.WriteLine("Unknown command result");
                    }

                    break;
                case ParsingResult.Failure failure:
                    Console.WriteLine(failure.Error.Message());
                    break;
                default:
                    Console.WriteLine("Unknown parsing result");
                    break;
            }
        }
    }
}