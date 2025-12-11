using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string connectionPath)
    {
        ConnectionPath = connectionPath;
        LocalPath = string.Empty;
    }

    public string ConnectionPath { get; }

    public string LocalPath { get; private set; }

    public OperationResult GoToPath(string path)
    {
        string fullPath = GetFullPath(path);

        if (!Directory.Exists(fullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new OutOfConnectionPathError());
        }

        LocalPath = fullPath.Substring(ConnectionPath.Length).TrimStart('/');

        return new OperationResult.Success();
    }

    public OperationResult GetFileContent(string path, IWriter writer)
    {
        string fullPath = GetFullPath(path);

        if (!File.Exists(fullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        string content = File.ReadAllText(fullPath);
        writer.Write(content);

        return new OperationResult.Success();
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);

        if (!sourceFullPath.StartsWith(ConnectionPath) ||
            !destinationFullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new OutOfConnectionPathError());
        }

        if (!File.Exists(sourceFullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        File.Move(sourceFullPath, destinationFullPath);

        return new OperationResult.Success();
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);

        if (!sourceFullPath.StartsWith(ConnectionPath) ||
            !destinationFullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new OutOfConnectionPathError());
        }

        if (!File.Exists(sourceFullPath) || !File.Exists(destinationFullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        File.Copy(sourceFullPath, destinationFullPath);
        return new OperationResult.Success();
    }

    public OperationResult DeleteFile(string path)
    {
        string fullPath = GetFullPath(path);
        if (!File.Exists(fullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new OutOfConnectionPathError());
        }

        File.Delete(fullPath);

        return new OperationResult.Success();
    }

    public OperationResult RenameFile(string path, string newName)
    {
        string fullPath = GetFullPath(path);
        string? directoryName = Path.GetDirectoryName(fullPath);

        if (!Directory.Exists(directoryName) || File.Exists(fullPath))
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(ConnectionPath))
        {
            return new OperationResult.Failure(new OutOfConnectionPathError());
        }

        string newFullPath = Path.Combine(directoryName, newName);
        File.Move(fullPath, newFullPath);

        return new OperationResult.Success();
    }

    public IFileSystemComponent? GetComponent()
    {
        if (Directory.Exists(ConnectionPath))
        {
            return new DirectoryFileSystemComponent(this, ConnectionPath);
        }

        if (File.Exists(ConnectionPath))
        {
            return new FileFileSystemComponent(this, ConnectionPath);
        }

        return null;
    }

    public IReadOnlyCollection<IFileSystemComponent> GetOneLevelSubComponents(string fullPath)
    {
        var components = new List<IFileSystemComponent>();

        foreach (string path in Directory.EnumerateFileSystemEntries(fullPath))
        {
            if (Directory.Exists(path))
            {
                components.Add(new DirectoryFileSystemComponent(this, path));
            }

            if (File.Exists(path))
            {
                components.Add(new FileFileSystemComponent(this, path));
            }
        }

        return components.AsReadOnly();
    }

    public string GetName(string fullPath)
    {
        return Path.GetFileName(fullPath);
    }

    private string GetFullPath(string path)
    {
        string unitedPath;

        if (IsAbsolutePath(path))
        {
            unitedPath = Path.Combine(ConnectionPath, path.TrimStart('/'));
        }
        else
        {
            unitedPath = Path.Combine(ConnectionPath, LocalPath, path);
        }

        return Path.GetFullPath(unitedPath);
    }

    private bool IsAbsolutePath(string path) => Path.IsPathRooted(path);
}