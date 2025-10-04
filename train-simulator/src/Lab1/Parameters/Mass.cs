namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Mass
{
    public Mass(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Mass cannot be negative", nameof(value));
        }

        Value = value;
    }

    public double Value { get; }
}