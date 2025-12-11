namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

public interface IFileSystemFactory
{
    IFileSystem Create(string connectionPath);
}