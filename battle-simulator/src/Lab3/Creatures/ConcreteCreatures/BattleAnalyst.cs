using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class BattleAnalyst : CreatureBase
{
    public BattleAnalyst(AttackParameter attack, HealthParameter health) : base(attack, health) { }

    public override void Attack(ICreature other)
    {
        AttackIndicator = AttackIndicator.Add(2);
        other.ReceiveDamage(AttackIndicator);
    }

    public override ICreature Copy()
        => new BattleAnalyst(AttackIndicator, HealthIndicator);
}