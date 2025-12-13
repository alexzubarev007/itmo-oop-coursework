using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class GoToCommand : ICommand
{
    public GoToCommand(string path)
    {
        NewPath = path;
    }

    public string NewPath { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;
        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        string fullPath = fileSystem
            .GetFullPath(controller.ConnectionPath, controller.LocalPath, NewPath);

        if (!fileSystem.DirectoryExists(NewPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(controller.ConnectionPath))
        {
            return new CommandResult.Failure(new OutOfConnectionPathError());
        }

        string newLocalPath = fileSystem.GoToPath(controller.ConnectionPath, fullPath);

        controller.LocalPath = newLocalPath;

        return new CommandResult.Success();
    }
}