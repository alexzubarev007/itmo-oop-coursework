using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;

public sealed class FileFileSystemComponent : IFileSystemComponent
{
    public FileFileSystemComponent(IFileSystem fileSystem, string fullPath)
    {
        FileSystem = fileSystem;
        FullPath = fullPath;
    }

    public IFileSystem FileSystem { get; }

    public string Name => FileSystem.GetName(FullPath);

    public string FullPath { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}