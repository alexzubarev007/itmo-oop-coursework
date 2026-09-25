using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeNotifier : IAddressee
{
    private readonly INotificationSystem _notificationSystem;
    private readonly List<string> _forbiddenWords;

    public AddresseeNotifier(INotificationSystem notificationSystem, IEnumerable<string> forbiddenWords)
    {
        _notificationSystem = notificationSystem;
        _forbiddenWords = forbiddenWords.ToList();
    }

    public void Accept(Message message)
    {
        if (_forbiddenWords.Any(word =>
                message.Header.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                message.Body.Contains(word, StringComparison.OrdinalIgnoreCase)))
        {
            _notificationSystem.Notify();
        }
    }
}