using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class ImmortalHorror : CreatureBase
{
    private bool _wasKilled;

    public ImmortalHorror(AttackParameter attack, HealthParameter health) : base(attack, health)
    {
        _wasKilled = false;
    }

    private ImmortalHorror(AttackParameter attack, HealthParameter health, bool wasKilled)
        : base(attack, health)
    {
        _wasKilled = wasKilled;
    }

    public override ICreature Copy()
        => new ImmortalHorror(AttackIndicator, HealthIndicator, _wasKilled);

    public override void ReceiveDamage(AttackParameter damaging)
    {
        base.ReceiveDamage(damaging);
        if (!HealthIndicator.IsPositive() && !_wasKilled)
        {
            _wasKilled = true;
            HealthIndicator = new HealthParameter(1);
        }
    }
}