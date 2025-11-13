using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class MimicChest : CreatureBase
{
    public MimicChest() : base(1, 1) { }

    public override void Attack(ICreature other)
    {
        AttackIndicator = AttackParameter.Max(AttackIndicator, other.AttackIndicator);
        HealthIndicator = HealthParameter.Max(HealthIndicator, other.HealthIndicator);

        other.ReceiveDamage(AttackIndicator);
    }

    public override ICreature Copy()
        => new MimicChest(AttackIndicator.Value, HealthIndicator.Value);

    private MimicChest(int attack, int health) : base(attack, health) { }
}