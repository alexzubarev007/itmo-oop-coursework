using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class RenameFileCommand : ICommand
{
    public RenameFileCommand(string path, string newName)
    {
        FilePath = path;
        NewName = newName;
    }

    public string FilePath { get; }

    public string NewName { get; }

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

        string? directory = fileSystem.GetDirectoryName(fullPath);

        if (directory is null)
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        string newFullPath = fileSystem.Combine(directory, NewName);

        fileSystem.RenameFile(fullPath, newFullPath);

        return new CommandResult.Success();
    }
}