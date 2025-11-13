namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class BattleAnalyst : CreatureBase
{
    public BattleAnalyst() : base(2, 4) { }

    public override void Attack(ICreature other)
    {
        AttackIndicator = AttackIndicator.Add(2);
        other.ReceiveDamage(AttackIndicator);
    }

    public override ICreature Copy()
        => new BattleAnalyst(AttackIndicator.Value, HealthIndicator.Value);

    private BattleAnalyst(int attack, int health) : base(attack, health) { }
}