using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class EvilFighter : CreatureBase
{
    public EvilFighter() : base(1, 6) { }

    public override void ReceiveDamage(AttackParameter damaging)
    {
        base.ReceiveDamage(damaging);
        if (HealthIndicator.IsPositive())
        {
            AttackIndicator = AttackIndicator.Multiply(2);
        }
    }

    public override ICreature Copy()
        => new EvilFighter(AttackIndicator.Value, HealthIndicator.Value);

    private EvilFighter(int attack, int health) : base(attack, health) { }
}