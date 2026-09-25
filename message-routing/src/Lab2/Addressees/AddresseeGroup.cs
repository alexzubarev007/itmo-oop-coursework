using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeGroup : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public AddresseeGroup()
    {
        _addressees = new List<IAddressee>();
    }

    public AddresseeGroup Add(IAddressee addressee)
    {
        _addressees.Add(addressee);
        return this;
    }

    public void Accept(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Accept(message);
        }
    }
}