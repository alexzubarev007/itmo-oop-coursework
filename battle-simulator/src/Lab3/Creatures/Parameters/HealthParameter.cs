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

    public HealthParameter DecreaseBy(int value)
        => new HealthParameter(Value - value);

    public HealthParameter IncreaseBy(int value)
        => new HealthParameter(Value + value);

    public bool IsPositive() => Value > 0;

    public static HealthParameter Max(HealthParameter first, HealthParameter second)
    {
        return first.Value > second.Value ? first : second;
    }
}