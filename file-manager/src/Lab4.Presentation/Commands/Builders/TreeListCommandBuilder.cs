using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class TreeListCommandBuilder : ICommandBuilder
{
    private int? _depth;

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public bool IsEveryFieldInitialized()
    {
        return _depth is not null;
    }

    public ICommand Build()
    {
        if (_depth is null)
        {
            throw new ArgumentException("Impossible to create tree list command");
        }

        return new TreeListCommand(_depth.Value);
    }
}
