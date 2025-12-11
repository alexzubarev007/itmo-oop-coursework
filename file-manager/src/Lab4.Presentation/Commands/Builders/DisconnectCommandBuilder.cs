using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public sealed class DisconnectCommandBuilder : ICommandBuilder
{
    public bool IsEveryFieldInitialized()
    {
        return true;
    }

    public ICommand Build()
    {
        return new DisconnectCommand();
    }
}