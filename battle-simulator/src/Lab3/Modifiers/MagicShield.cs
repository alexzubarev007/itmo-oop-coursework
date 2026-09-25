using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class MagicShield : ICreature
{
    private readonly ICreature _creature;

    private bool _isDamaged;

    public MagicShield(ICreature creature)
    {
        _creature = creature;
        _isDamaged = false;
    }

    private MagicShield(ICreature creature, bool isDamaged)
    {
        _creature = creature;
        _isDamaged = isDamaged;
    }

    public AttackParameter AttackIndicator => _creature.AttackIndicator;

    public HealthParameter HealthIndicator => _creature.HealthIndicator;

    public void Attack(ICreature other)
    {
        _creature.Attack(other);
    }

    public void ReceiveDamage(AttackParameter damaging)
    {
        if (!_isDamaged)
        {
            _isDamaged = true;
            return;
        }

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
        return new MagicShield(_creature.Copy(), _isDamaged);
    }
}