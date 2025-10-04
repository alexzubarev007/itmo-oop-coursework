namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed record Acceleration
{
    public double Value { get; }

    public Acceleration(double value)
    {
        Value = value;
    }

    public static Acceleration Create(Force force, Mass mass)
    {
        return new Acceleration(force.Value / mass.Value);
    }

    public bool IsNegativeOrZero()
    {
        return Value <= 0;
    }
}