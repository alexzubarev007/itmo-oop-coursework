using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace MessagingDemo;

public static class Program
{
    public static void Main()
    {
        var user = new User();
        var archive = new InMemoryArchiver();
        var formattedArchive = new FormattingArchiver(
            new MarkdownFormatterDecorator(new ConsoleFormatter()));
        var userAddress = new FilterAddresseeProxy(new AddresseeUser(user), ImportanceLevel.High);
        Topic topic = new Topic("Service alerts")
            .Add(userAddress)
            .Add(new AddresseeArchiver(archive))
            .Add(new AddresseeArchiver(formattedArchive));
        var routine = new Message("Daily report", "All systems operational", ImportanceLevel.Low);
        var incident = new Message("Incident", "Service requires attention", ImportanceLevel.High);

        topic.Send(routine);
        topic.Send(incident);

        Console.WriteLine($"Archived messages: {archive.Messages.Count}");
        Console.WriteLine($"Low-priority message filtered: {user.GetReadStatus(routine) is null}");
        Console.WriteLine($"Incident before reading: {user.GetReadStatus(incident)}");
        user.MarkAsRead(incident);
        Console.WriteLine($"Incident after reading: {user.GetReadStatus(incident)}");
    }
}
