namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent file);

    void Visit(DirectoryFileSystemComponent directory);
}