using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleFormatter : IFormatter
{
    public void WriteHeader(Message message)
    {
        Console.WriteLine(message.Header + "\n");
    }

    public void WriteBody(Message message)
    {
        Console.WriteLine(message.Body + "\n");
    }
}