using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class CopyFileCommand : ICommand
{
    public CopyFileCommand(string sourcePath, string destinationPath)
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

        if (!fileSystem.FileExists(sourceFullPath) ||
            !fileSystem.FileExists(destinationFullPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        fileSystem.CopyFile(SourcePath, DestinationPath);

        return new CommandResult.Success();
    }
}