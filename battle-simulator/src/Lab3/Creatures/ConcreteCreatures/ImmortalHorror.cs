using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class ImmortalHorror : CreatureBase
{
    private bool _wasKilled;

    public ImmortalHorror() : base(4, 4)
    {
        _wasKilled = false;
    }

    public override void ReceiveDamage(AttackParameter damaging)
    {
        base.ReceiveDamage(damaging);
        if (!HealthIndicator.IsPositive() && !_wasKilled)
        {
            _wasKilled = true;
            HealthIndicator = new HealthParameter(1);
        }
    }

    public override ICreature Copy()
        => new ImmortalHorror(AttackIndicator.Value, HealthIndicator.Value);

    private ImmortalHorror(int attack, int health) : base(attack, health) { }
}