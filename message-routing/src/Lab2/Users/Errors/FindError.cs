namespace Itmo.ObjectOrientedProgramming.Lab2.Users.Errors;

public sealed record FindError : IUserError
{
    public string Report() => "No such message";
}