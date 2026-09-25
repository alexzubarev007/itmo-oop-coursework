namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public sealed record MovementError : IError
{
    public string Message()
    {
        return "Train stopped and can't pass distance";
    }
}