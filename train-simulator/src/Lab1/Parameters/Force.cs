namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Force
{
    public Force(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public Force GetAbs()
    {
        if (Value >= 0)
        {
            return new Force(Value);
        }
        else
        {
            return new Force(-Value);
        }
    }

    public static bool operator >(Force left, Force right) => left.Value > right.Value;

    public static bool operator <(Force left, Force right) => left.Value < right.Value;
}