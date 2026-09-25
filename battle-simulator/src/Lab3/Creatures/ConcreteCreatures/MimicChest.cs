using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class MimicChest : CreatureBase
{
    public MimicChest(AttackParameter attack, HealthParameter health) : base(attack, health) { }

    public override ICreature Copy()
        => new MimicChest(AttackIndicator, HealthIndicator);

    public override void Attack(ICreature other)
    {
        AttackIndicator = AttackParameter.Max(AttackIndicator, other.AttackIndicator);
        HealthIndicator = HealthParameter.Max(HealthIndicator, other.HealthIndicator);

        other.ReceiveDamage(AttackIndicator);
    }
}