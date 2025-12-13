using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class MoveFileCommand : ICommand
{
    public MoveFileCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }

    public string DestinationPath { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;
        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        string sourceFullPath = fileSystem
            .GetFullPath(controller.ConnectionPath, controller.LocalPath, SourcePath);
        string destinationFullPath = fileSystem
            .GetFullPath(controller.ConnectionPath, controller.LocalPath, DestinationPath);

        if (!sourceFullPath.StartsWith(controller.ConnectionPath) ||
            !destinationFullPath.StartsWith(controller.ConnectionPath))
        {
            return new CommandResult.Failure(new OutOfConnectionPathError());
        }

        if (!fileSystem.FileExists(sourceFullPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        fileSystem.MoveFile(sourceFullPath, destinationFullPath);

        return new CommandResult.Success();
    }
}