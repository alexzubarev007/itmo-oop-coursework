using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature Use(ICreature creature)
    {
        int healthValue = creature.HealthIndicator.Value;
        creature.ChangeHealth(creature.AttackIndicator.Value);
        creature.ChangeAttack(healthValue);
        return creature;
    }
}