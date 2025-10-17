using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeUser : IAddressee
{
    private readonly User _user;

    public AddresseeUser(User user)
    {
        _user = user;
    }

    public void Accept(Message message)
    {
        _user.Accept(message);
    }
}