using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactoryLinks;

public abstract class FileSystemFactoryLinkBase : IFileSystemFactoryLink
{
    private IFileSystemFactoryLink? _next;

    public abstract IFileSystemFactory? GetFileSystemByMode(string mode);

    public IFileSystemFactoryLink AddNext(IFileSystemFactoryLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected IFileSystemFactory? CallNext(string mode)
    {
        return _next?.GetFileSystemByMode(mode) ?? null;
    }
}