using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class CreatureBuilderBase : ICreatureBuilder
{
    private readonly List<IModifierApplier> _modifierAppliers = [];

    public ICreatureBuilder WithModifier(IModifierApplier modifier)
    {
        _modifierAppliers.Add(modifier);
        return this;
    }

    public abstract ICreature Build();

    protected virtual ICreature ApplyModifiers(ICreature creature)
    {
        foreach (IModifierApplier modifierApplier in _modifierAppliers)
        {
            creature = modifierApplier.Apply(creature);
        }

        return creature;
    }
}