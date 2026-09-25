using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    private readonly List<IAddressee> _addressees = new();

    public string Name { get; }

    public Topic(string name)
    {
        Name = name;
    }

    public Topic Add(IAddressee addressee)
    {
        _addressees.Add(addressee);
        return this;
    }

    public void Send(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Accept(message);
        }
    }
}