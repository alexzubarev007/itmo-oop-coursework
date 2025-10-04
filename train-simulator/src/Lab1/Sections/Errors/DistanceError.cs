namespace Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

public sealed record DistanceError : ISectionErrors
{
    public string Message()
    {
        return "Train stopped and can't pass distance";
    }
}