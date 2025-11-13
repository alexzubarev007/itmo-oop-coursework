using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public abstract class CreatureBase : ICreature
{
    public AttackParameter AttackIndicator { get; protected set; }

    public HealthParameter HealthIndicator { get; protected set; }

    protected CreatureBase(int attackIndicator, int healthIndicator)
    {
        if (attackIndicator < 0)
        {
            throw new ArgumentException("It's impossible to create creature with negative attack indicator");
        }

        if (healthIndicator < 0)
        {
            throw new ArgumentException("It's impossible to create creature with negative health indicator");
        }

        AttackIndicator = new AttackParameter(attackIndicator);
        HealthIndicator = new HealthParameter(healthIndicator);
    }

    public virtual void Attack(ICreature other)
    {
        if (AttackIndicator.IsPositive() && other.HealthIndicator.IsPositive())
        {
            other.ReceiveDamage(AttackIndicator);
        }
    }

    public virtual void ReceiveDamage(AttackParameter damaging)
    {
        if (HealthIndicator.IsPositive())
        {
            HealthIndicator = HealthIndicator.Subtract(damaging.Value);
        }
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