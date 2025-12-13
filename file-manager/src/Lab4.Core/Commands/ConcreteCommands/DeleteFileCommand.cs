using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class DeleteFileCommand : ICommand
{
    public DeleteFileCommand(string path)
    {
        FilePath = path;
    }

    public string FilePath { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;

        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        string fullPath = fileSystem
                          .GetFullPath(controller.ConnectionPath, controller.LocalPath, FilePath);

        if (!fileSystem.FileExists(fullPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(controller.ConnectionPath))
        {
            return new CommandResult.Failure(new OutOfConnectionPathError());
        }

        fileSystem.DeleteFile(fullPath);

        return new CommandResult.Success();
    }
}