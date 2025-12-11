using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    string ConnectionPath { get; }

    string LocalPath { get; }

    OperationResult GoToPath(string path);

    OperationResult GetFileContent(string path, IWriter writer);

    OperationResult MoveFile(string sourcePath, string destinationPath);

    OperationResult CopyFile(string sourcePath, string destinationPath);

    OperationResult DeleteFile(string path);

    OperationResult RenameFile(string path, string newName);

    IFileSystemComponent? GetComponent();

    IReadOnlyCollection<IFileSystemComponent> GetOneLevelSubComponents(string fullPath);

    string GetName(string fullPath);
}