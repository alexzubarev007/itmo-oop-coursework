using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class AppRunner
{
    private readonly Parser _parser;

    public AppRunner(Parser parser)
    {
        _parser = parser;
    }

    public void Run()
    {
        FileSystemController controller = new();

        string? commandLine;

        while ((commandLine = Console.ReadLine()) != null)
        {
            ParsingResult result = _parser.Parse(commandLine);

            switch (result)
            {
                case ParsingResult.Success success:
                    ICommand command = success.Command;

                    CommandResult commandResult = command.Execute(controller);

                    if (commandResult is CommandResult.Success)
                    {
                        Console.WriteLine("Command successfully executed");
                    }
                    else if (commandResult is CommandResult.Failure commandFailure)
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