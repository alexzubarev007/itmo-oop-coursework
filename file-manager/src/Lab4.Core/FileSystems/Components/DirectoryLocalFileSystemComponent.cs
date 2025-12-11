using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;

public sealed class DirectoryLocalFileSystemComponent : IDirectoryFileSystemComponent
{
    public DirectoryLocalFileSystemComponent(string fullPath)
    {
        FullPath = fullPath;
        Components = new IReadOnlyCollection<IFileSystemComponent>(() =>
        {
            var components = new List<IFileSystemComponent>();
            foreach (string path in Directory.EnumerateFileSystemEntries(fullPath))
            {
                if (Directory.Exists(path))
                {
                    components.Add(new DirectoryLocalFileSystemComponent(FullPath));
                }

                if (File.Exists(path))
                {
                    components.Add(new FileLocalFileSystemComponent(FullPath));
                }
            }

            return components.AsReadOnly();
        });
    }

    public string FullPath { get; }

    public string Name => Path.GetDirectoryName(FullPath) ?? string.Empty;

    public IReadOnlyCollection<IFileSystemComponent> Components { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}