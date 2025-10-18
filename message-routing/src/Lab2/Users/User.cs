using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users.Errors;

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
        if (!_statuses.ContainsKey(message))
        {
            _statuses[message] = ReadStatus.Unread;
        }
    }

    public UserResult MarkAsRead(Message message)
    {
        if (!_statuses.TryGetValue(message, out ReadStatus status))
        {
            return new UserResult.Failure(new FindError());
        }

        if (status == ReadStatus.Read)
        {
            return new UserResult.Failure(new MarkReadError());
        }

        _statuses[message] = ReadStatus.Read;

        return new UserResult.Success();
    }

    public ReadStatus? GetReadStatus(Message message)
    {
        if (!_statuses.TryGetValue(message, out ReadStatus status))
        {
            return null;
        }

        return status;
    }
}