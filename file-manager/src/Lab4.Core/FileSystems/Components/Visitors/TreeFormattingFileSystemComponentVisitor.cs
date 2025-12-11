using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;

public sealed class TreeFormattingFileSystemComponentVisitor
    : IFileSystemComponentVisitor
{
    private readonly FormattingTreeParameters _formattingTreeParameters;
    private readonly int _maxDepth;
    private int _currentDepth;

    public TreeFormattingFileSystemComponentVisitor(
        FormattingTreeParameters formattingTreeParameters,
        int maxDepth)
    {
        _formattingTreeParameters = formattingTreeParameters;
        _maxDepth = maxDepth;
        TreeStringBuilder = new StringBuilder();
        _currentDepth = 0;
    }

    public StringBuilder TreeStringBuilder { get; }

    public void Visit(FileFileSystemComponent file)
    {
        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        for (int i = 0; i < _currentDepth; i++)
        {
            TreeStringBuilder
                .Append(_formattingTreeParameters.IndentationSymbols);
        }

        TreeStringBuilder
            .Append(_formattingTreeParameters.FileSymbols + ' ');
        TreeStringBuilder.AppendLine(file.Name);
    }

    public void Visit(DirectoryFileSystemComponent directory)
    {
        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        for (int i = 0; i < _currentDepth; i++)
        {
            TreeStringBuilder
                .Append(_formattingTreeParameters.IndentationSymbols);
        }

        TreeStringBuilder
            .Append(_formattingTreeParameters.DirectorySymbols + ' ');
        TreeStringBuilder.AppendLine(directory.Name);

        ++_currentDepth;

        foreach (IFileSystemComponent component in directory.Components)
        {
            component.Accept(this);
        }

        --_currentDepth;
    }
}