using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class CopyFileCommand : ICommand
{
    public CopyFileCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }

    public string DestinationPath { get; }

    public OperationResult Execute(FileSystemController controller)
    {
        return controller.FileSystem.CopyFile(SourcePath, DestinationPath);
    }
}