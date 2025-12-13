namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    bool DirectoryExists(string path);

    bool FileExists(string path);

    string GetFullPath(string connectionPath, string localPath, string currentPath);

    string GoToPath(string connectionPath, string path);

    string GetFileContent(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string newNamePath);

    string Combine(string path1, string path2);

    string? GetDirectoryName(string path);

    IReadOnlyCollection<string> GetSubComponents(string path);

    string GetName(string fullPath);
}