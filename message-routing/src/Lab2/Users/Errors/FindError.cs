namespace Itmo.ObjectOrientedProgramming.Lab2.Users.Errors;

public sealed record FindError : IUserError
{
    public string Report()
    {
        return "No such message";
    }
}