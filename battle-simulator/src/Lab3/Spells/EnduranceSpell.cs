using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EnduranceSpell : ISpell
{
    public ICreature Use(ICreature creature)
    {
        creature.ChangeHealth(creature.HealthIndicator.IncreaseBy(5).Value);
        return creature;
    }
}