namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Time
{
    public Time(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Time cannot be negative", nameof(value));
        }

        Value = value;
    }

    public double Value { get; }

    public static Time operator +(Time left, Time right) =>
        new Time(left.Value + right.Value);
}