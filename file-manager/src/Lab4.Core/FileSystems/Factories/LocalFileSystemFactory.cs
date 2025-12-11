namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

public sealed class LocalFileSystemFactory : IFileSystemFactory
{
    public IFileSystem Create(string connectionPath)
    {
        return new LocalFileSystem(connectionPath);
    }
}