using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;

public sealed class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(IFileSystem fileSystem, string fullPath)
    {
        FileSystem = fileSystem;
        FullPath = fullPath;
    }

    public IFileSystem FileSystem { get; }

    public string Name => FileSystem.GetName(FullPath);

    public string FullPath { get; }

    public IReadOnlyCollection<IFileSystemComponent> GetSubComponents()
    {
        var components = new List<IFileSystemComponent>();

        foreach (string path in FileSystem.GetSubComponents(FullPath))
        {
            if (FileSystem.DirectoryExists(path))
            {
                components.Add(new DirectoryFileSystemComponent(FileSystem, path));
            }

            if (FileSystem.FileExists(path))
            {
                components.Add(new FileFileSystemComponent(FileSystem, path));
            }
        }

        return components.AsReadOnly();
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}