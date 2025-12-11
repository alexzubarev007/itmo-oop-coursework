namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

public sealed class ConsoleWriter : IWriter
{
    public void Write(string s)
    {
        Console.WriteLine(s);
    }
}