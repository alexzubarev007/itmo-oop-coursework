namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Speed
{
    public Speed(double value)
    {
        Value = value;
    }

    public static Speed Create(Acceleration acceleration, Time time)
    {
        return new Speed(acceleration.Value * time.Value);
    }

    public double Value { get; }

    public static Speed operator +(Speed left, Speed right) =>
        new Speed(left.Value + right.Value);

    public static Speed operator -(Speed left, Speed right) =>
        new Speed(left.Value + right.Value);

    public static bool operator <(Speed left, Speed right) => left.Value < right.Value;

    public static bool operator >(Speed left, Speed right) => left.Value > right.Value;

    public static bool operator <=(Speed left, Speed right) => left.Value <= right.Value;

    public static bool operator >=(Speed left, Speed right) => left.Value >= right.Value;

    public bool IsNegativeOrZero()
    {
        return Value <= 0;
    }
}