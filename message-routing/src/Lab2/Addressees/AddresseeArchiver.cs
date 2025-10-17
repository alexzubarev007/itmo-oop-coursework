using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeArchiver : IAddressee
{
    private readonly IArchiver _archiver;

    public AddresseeArchiver(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void Accept(Message message)
    {
        _archiver.Store(message);
    }
}