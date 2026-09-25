using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CreaturesTests
{
    [Fact]
    public void BattleAnalyst_WhenItIsDefault_CreatesWithCorrectParameters()
    {
        // arrange
        ICreatureBuilder battleAnalystBuilder = new BattleAnalystBuilderFactory()
            .CreateBuilder();

        // act
        ICreature battleAnalyst = battleAnalystBuilder.Build();

        // assert
        Assert.Equal(2, battleAnalyst.AttackIndicator.Value);
        Assert.Equal(4, battleAnalyst.HealthIndicator.Value);
    }

    [Fact]
    public void MimicChest_WhenItIsDefault_CreatesWithCorrectParameters()
    {
        // arrange
        ICreatureBuilder mimicChestBuilder = new MimicChestBuilderFactory()
            .CreateBuilder();

        // act
        ICreature mimicChest = mimicChestBuilder.Build();

        // assert
        Assert.Equal(1, mimicChest.AttackIndicator.Value);
        Assert.Equal(1, mimicChest.HealthIndicator.Value);
    }

    [Fact]
    public void Creature_WhenNonDefaultParametersInBuilder_TrulyHaveThem()
    {
        // arrange
        ICreatureBuilder battleAnalystBuilder = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithAttack(new AttackParameter(100))
            .WithHealth(new HealthParameter(150));

        // act
        ICreature battleAnalyst = battleAnalystBuilder.Build();

        // assert
        Assert.Equal(100, battleAnalyst.AttackIndicator.Value);
        Assert.Equal(150, battleAnalyst.HealthIndicator.Value);
    }

    [Fact]
    public void Creature_WhenNonDefaultModifiersInBuilder_TrulyHaveThem()
    {
        // arrange
        ICreatureBuilder mimicChestBuilder = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier());

        // act
        ICreature battleAnalyst = mimicChestBuilder.Build();

        // assert
        Assert.IsType<AttackingSkill>(battleAnalyst);
    }
}