using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;

public interface IFileSystemComponent
{
    IFileSystem FileSystem { get; }

    string FullPath { get; }

    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}