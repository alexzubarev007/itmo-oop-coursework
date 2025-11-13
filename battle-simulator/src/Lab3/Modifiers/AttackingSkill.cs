using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class AttackingSkill : ICreature
{
    private readonly ICreature _creature;

    public AttackParameter AttackIndicator => _creature.AttackIndicator;

    public HealthParameter HealthIndicator => _creature.HealthIndicator;

    public AttackingSkill(ICreature creature)
    {
        _creature = creature;
    }

    public void Attack(ICreature other)
    {
        _creature.Attack(other);
        if (other.HealthIndicator.IsPositive())
        {
            _creature.Attack(other);
        }
    }

    public void ReceiveDamage(AttackParameter damaging)
    {
        _creature.ReceiveDamage(damaging);
    }

    public void ChangeAttack(int value)
    {
        _creature.ChangeAttack(value);
    }

    public void ChangeHealth(int value)
    {
        _creature.ChangeHealth(value);
    }

    public ICreature Copy()
    {
        return new AttackingSkill(_creature.Copy());
    }
}