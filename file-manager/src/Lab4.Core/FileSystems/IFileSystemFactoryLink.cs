using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystemFactoryLink
{
    IFileSystemFactory? GetFileSystemByMode(string mode);

    IFileSystemFactoryLink AddNext(IFileSystemFactoryLink link);
}