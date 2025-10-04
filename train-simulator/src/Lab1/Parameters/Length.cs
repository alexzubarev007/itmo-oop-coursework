namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Length
{
    public Length(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Length cannot be negative", nameof(value));
        }

        Value = value;
    }

    public Length Create(Speed speed, Time time)
    {
        return new Length(speed.Value * time.Value);
    }

    public Length Duplicate()
    {
        return new Length(Value);
    }

    public double Value { get; }

    public static Length operator +(Length left, Length right) =>
        new Length(left.Value + right.Value);

    public static Length operator -(Length left, Length right) =>
        new Length(left.Value - right.Value);

    public static bool operator <(Length left, Length right) => left.Value < right.Value;

    public static bool operator >(Length left, Length right) => left.Value > right.Value;

    public static bool operator <=(Length left, Length right) => left.Value <= right.Value;

    public static bool operator >=(Length left, Length right) => left.Value >= right.Value;

    public bool IsPositive()
    {
        return Value > 0;
    }
}