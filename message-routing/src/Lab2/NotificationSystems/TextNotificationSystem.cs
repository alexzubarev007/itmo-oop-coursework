namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotificationSystem : INotificationSystem
{
    private readonly string _notification;

    public TextNotificationSystem(string notification)
    {
       _notification = notification;
    }

    public void Notify()
    {
        Console.WriteLine(_notification);
    }
}