using Itmo.ObjectOrientedProgramming.Lab2.Users.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public abstract record UserResult
{
    private UserResult() { }

    public sealed record Success : UserResult { }

    public sealed record Failure(IUserError UserError) : UserResult { }
}