namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;

public interface ICommandBuilder
{
    ICommand Build();

    bool IsEveryFieldInitialized();
}
