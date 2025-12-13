using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class DisconnectCommand : ICommand
{
    public CommandResult Execute(FileSystemController controller)
    {
        if (controller.FileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        controller.Disconnect();

        return new CommandResult.Success();
    }
}