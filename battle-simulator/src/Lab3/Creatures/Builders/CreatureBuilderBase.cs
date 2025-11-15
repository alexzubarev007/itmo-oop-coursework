using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class CreatureBuilderBase : ICreatureBuilder
{
    private readonly List<IModifierApplier> _modifierAppliers = [];

    protected AttackParameter? AttackIndicator { get; private set; }

    protected HealthParameter? HealthIndicator { get; private set; }

    public ICreatureBuilder WithAttack(AttackParameter attack)
    {
        AttackIndicator = attack;
        return this;
    }

    public ICreatureBuilder WithHealth(HealthParameter health)
    {
        HealthIndicator = health;
        return this;
    }

    public ICreatureBuilder WithModifier(IModifierApplier modifier)
    {
        _modifierAppliers.Add(modifier);
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = Create();

        creature = ApplyModifiers(creature);

        return creature;
    }

    protected abstract ICreature Create();

    private ICreature ApplyModifiers(ICreature creature)
    {
        foreach (IModifierApplier modifierApplier in _modifierAppliers)
        {
            creature = modifierApplier.Apply(creature);
        }

        return creature;
    }
}