using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public abstract class CreatureBase : ICreature
{
    protected CreatureBase(AttackParameter attackIndicator, HealthParameter healthIndicator)
    {
        healthIndicator.EnsurePositive();

        AttackIndicator = attackIndicator;
        HealthIndicator = healthIndicator;
    }

    public AttackParameter AttackIndicator { get; protected set; }

    public HealthParameter HealthIndicator { get; protected set; }

    public virtual void Attack(ICreature other)
    {
        other.HealthIndicator.EnsurePositive();

        other.ReceiveDamage(AttackIndicator);
    }

    public virtual void ReceiveDamage(AttackParameter damaging)
    {
        HealthIndicator.EnsurePositive();

        HealthIndicator = HealthIndicator.Subtract(damaging.Value);
    }

    public void ChangeAttack(int value)
    {
        AttackIndicator = new AttackParameter(value);
    }

    public void ChangeHealth(int value)
    {
        HealthIndicator = new HealthParameter(value);
    }

    public abstract ICreature Copy();
}