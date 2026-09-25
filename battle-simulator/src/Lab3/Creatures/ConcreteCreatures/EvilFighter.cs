using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class EvilFighter : CreatureBase
{
    public EvilFighter(AttackParameter attack, HealthParameter health) : base(attack, health) { }

    public override ICreature Copy()
        => new EvilFighter(AttackIndicator, HealthIndicator);

    public override void ReceiveDamage(AttackParameter damaging)
    {
        base.ReceiveDamage(damaging);
        if (HealthIndicator.IsPositive())
        {
            AttackIndicator = AttackIndicator.Multiply(2);
        }
    }
}