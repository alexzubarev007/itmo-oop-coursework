namespace Itmo.ObjectOrientedProgramming.Lab2.Users.Errors;

public sealed record MarkReadError : IUserError
{
    public string Report() => "Try to mark as read already read message";
}