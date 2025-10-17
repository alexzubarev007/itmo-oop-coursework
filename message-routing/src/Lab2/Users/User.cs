using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    private readonly Dictionary<Message, ReadStatus> _statuses;

    public User()
    {
        _statuses = new Dictionary<Message, ReadStatus>();
    }

    public void Accept(Message message)
    {
        _statuses[message] = ReadStatus.Unread;
    }

    public void MarkAsRead(Message message)
    {
        if (!_statuses.TryGetValue(message, out ReadStatus status))
        {
            throw new InvalidOperationException("No such message");
        }

        if (status == ReadStatus.Read)
        {
            throw new InvalidOperationException("Try to mark as read already read message");
        }

        _statuses[message] = ReadStatus.Read;
    }

    public ReadStatus GetReadStatus(Message message)
    {
        if (!_statuses.TryGetValue(message, out ReadStatus status))
        {
            throw new InvalidOperationException("No such message");
        }

        return status;
    }
}