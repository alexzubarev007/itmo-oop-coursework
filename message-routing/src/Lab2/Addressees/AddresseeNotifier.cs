using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeNotifier : IAddressee
{
    private readonly INotificationSystem _notificationSystem;

    public AddresseeNotifier(INotificationSystem notificationSystem)
    {
        _notificationSystem = notificationSystem;
    }

    public void Accept(Message message)
    {
        _notificationSystem.Notify();
    }
}