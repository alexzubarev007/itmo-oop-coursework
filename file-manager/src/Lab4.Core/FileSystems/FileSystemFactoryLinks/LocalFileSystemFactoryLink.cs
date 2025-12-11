using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactoryLinks;

public sealed class LocalFileSystemFactoryLink : FileSystemFactoryLinkBase
{
    public override IFileSystemFactory? GetFileSystemByMode(string mode)
    {
        if (mode == "local")
        {
            return new LocalFileSystemFactory();
        }

        return CallNext(mode);
    }
}