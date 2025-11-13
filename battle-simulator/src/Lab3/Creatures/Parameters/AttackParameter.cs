namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

public record AttackParameter
{
    public int Value { get; }

    public AttackParameter(int value)
    {
        Value = value;
    }

    public AttackParameter Subtract(int subtrahend)
        => new AttackParameter(Value - subtrahend);

    public AttackParameter Add(int addend)
        => new AttackParameter(Value + addend);

    public AttackParameter Multiply(int multiplier)
        => new AttackParameter(Value * multiplier);

    public bool IsPositive()
    {
        return Value > 0;
    }

    public static AttackParameter Max(AttackParameter first, AttackParameter second)
    {
        return first.Value >= second.Value ? first : second;
    }
}