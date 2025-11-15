using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class AmuletMasterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder() => new AmuletMasterBuilder()
        .WithAttack(new AttackParameter(5))
        .WithHealth(new HealthParameter(2))
        .WithModifier(new MagicShieldApplier())
        .WithModifier(new AttackingSkillApplier());
}