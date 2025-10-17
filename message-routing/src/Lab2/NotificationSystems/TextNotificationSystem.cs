using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotificationSystem : INotificationSystem
{
    private readonly Message _message;

    public TextNotificationSystem(Message message)
    {
        _message = message;
    }

    public void Notify()
    {
        Console.WriteLine(_message.Body);
    }
}