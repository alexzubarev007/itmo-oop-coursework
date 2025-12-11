using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class DisconnectCommand : ICommand
{
    public OperationResult Execute(FileSystemController controller)
    {
        return controller.Disconnect();
    }
}