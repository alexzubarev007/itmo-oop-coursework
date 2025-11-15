namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

public record HealthParameter
{
    public HealthParameter(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public void EnsurePositive()
    {
        if (Value < 0)
        {
            throw new ArgumentException("Health shouldn't be negative", nameof(Value));
        }
    }

    public HealthParameter Subtract(int subtrahend)
        => new HealthParameter(Value - subtrahend);

    public HealthParameter Add(int addend)
        => new HealthParameter(Value + addend);

    public bool IsPositive() => Value > 0;

    public static HealthParameter Max(HealthParameter first, HealthParameter second)
    {
        return first.Value > second.Value ? first : second;
    }
}