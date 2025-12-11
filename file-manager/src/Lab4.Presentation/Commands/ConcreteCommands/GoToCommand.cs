using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class GoToCommand : ICommand
{
    public GoToCommand(string path)
    {
        NewPath = path;
    }

    public string NewPath { get; }

    public OperationResult Execute(FileSystemController controller)
    {
        return controller.FileSystem.GoToPath(NewPath);
    }
}