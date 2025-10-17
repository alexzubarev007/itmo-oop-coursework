using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class FilterAddresseeProxy : IAddressee
{
    private readonly ImportanceLevel _minImportance;
    private readonly IAddressee _addressee;

    public FilterAddresseeProxy(IAddressee addressee, ImportanceLevel minImportance)
    {
        _addressee = addressee;
        _minImportance = minImportance;
    }

    public void Accept(Message message)
    {
        if (_minImportance <= message.Importance)
        {
            _addressee.Accept(message);
        }
    }
}