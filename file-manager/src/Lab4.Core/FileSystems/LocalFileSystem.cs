namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class LocalFileSystem : IFileSystem
{
    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public string GoToPath(string connectionPath, string path)
    {
        string localPath = path.Substring(connectionPath.Length).TrimStart('/');

        return localPath;
    }

    public string GetFileContent(string path)
    {
        return File.ReadAllText(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void RenameFile(string path, string newNamePath)
    {
        MoveFile(path, newNamePath);
    }

    public string Combine(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public IReadOnlyCollection<string> GetSubComponents(string path)
    {
        return Directory
            .EnumerateFileSystemEntries(path)
            .ToList()
            .AsReadOnly();
    }

    public string GetName(string fullPath)
    {
        return Path.GetFileName(fullPath);
    }

    public string GetFullPath(string connectionPath,  string localPath, string currentPath)
    {
        string unitedPath;

        if (IsAbsolutePath(currentPath))
        {
            unitedPath = Path.Combine(connectionPath, currentPath.TrimStart('/'));
        }
        else
        {
            unitedPath = Path.Combine(connectionPath, localPath, currentPath);
        }

        return Path.GetFullPath(unitedPath);
    }

    private bool IsAbsolutePath(string path) => Path.IsPathRooted(path);
}