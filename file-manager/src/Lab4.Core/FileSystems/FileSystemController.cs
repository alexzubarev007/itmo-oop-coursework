namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FileSystemController
{
    public IFileSystem? FileSystem { get; private set; }

    public string ConnectionPath { get; private set; } = string.Empty;

    public string LocalPath { get; set; } = string.Empty;

    public void Connect(IFileSystem fileSystem, string connectionPath)
    {
        FileSystem = fileSystem;
        ConnectionPath = connectionPath;
        LocalPath = string.Empty;
    }

    public void Disconnect()
    {
        FileSystem = null;
        ConnectionPath = string.Empty;
        LocalPath = string.Empty;
    }
}