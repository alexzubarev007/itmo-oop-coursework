using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class NullFileSystem : IFileSystem
{
    public string ConnectionPath { get; } = string.Empty;

    public string LocalPath { get; } = string.Empty;

    public OperationResult GoToPath(string path)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public OperationResult GetFileContent(string path, IWriter writer)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public OperationResult DeleteFile(string path)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public OperationResult RenameFile(string path, string newName)
    {
        return new OperationResult.Failure(new DisconnectingError());
    }

    public IFileSystemComponent? GetComponent() => null;

    public IReadOnlyCollection<IFileSystemComponent> GetOneLevelSubComponents(string fullPath)
    {
        return new List<IFileSystemComponent>();
    }

    public string GetName(string fullPath) => string.Empty;
}