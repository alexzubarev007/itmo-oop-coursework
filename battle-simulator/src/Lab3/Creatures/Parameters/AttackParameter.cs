namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

public record AttackParameter
{
    public AttackParameter(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Attack should be positive", nameof(value));
        }

        Value = value;
    }

    public int Value { get; }

    public AttackParameter DecreaseBy(int value)
        => new AttackParameter(Value - value);

    public AttackParameter IncreaseBy(int value)
        => new AttackParameter(Value + value);

    public AttackParameter Multiply(int value)
        => new AttackParameter(Value * value);

    public bool IsPositive()
    {
        return Value > 0;
    }

    public static AttackParameter Max(AttackParameter first, AttackParameter second)
    {
        return first.Value >= second.Value ? first : second;
    }
}