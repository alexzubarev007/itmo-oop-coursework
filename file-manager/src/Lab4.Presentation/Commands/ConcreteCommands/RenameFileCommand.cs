using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class RenameFileCommand : ICommand
{
    public RenameFileCommand(string path, string newName)
    {
        FilePath = path;
        NewName = newName;
    }

    public string FilePath { get; }

    public string NewName { get; }

    public OperationResult Execute(FileSystemController controller)
    {
        return controller.FileSystem.RenameFile(FilePath, NewName);
    }
}