using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class DeleteFileCommand : ICommand
{
    public DeleteFileCommand(string path)
    {
        FilePath = path;
    }

    public string FilePath { get; }

    public OperationResult Execute(FileSystemController controller)
    {
        return controller.FileSystem.DeleteFile(FilePath);
    }
}