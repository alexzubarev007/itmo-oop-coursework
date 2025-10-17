using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages;

    public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

    public InMemoryArchiver()
    {
        _messages = new List<Message>();
    }

    public void Store(Message message)
    {
        _messages.Add(message);
    }
}