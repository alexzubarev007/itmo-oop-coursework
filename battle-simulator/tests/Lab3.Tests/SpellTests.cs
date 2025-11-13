using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SpellTests
{
    [Fact]
    public void StrengthSpell_WhenItUsed_IncreasesAttackByFive()
    {
        // arrange
        ICreature catalogEvilFighter = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table();
        table.Add(catalogEvilFighter);

        // act
        table.UseSpell(new StrengthSpell(), 0);
        ICreature tableCreature = table.GetCreatureById(0);
        int difference = tableCreature.AttackIndicator.Value
                         - catalogEvilFighter.AttackIndicator.Value;

        // assert
        Assert.Equal(5, difference);
    }

    [Fact]
    public void EnduranceSpell_WhenItUsed_IncreasesHealthByFive()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table();
        table.Add(catalogCreature);

        // act
        table.UseSpell(new EnduranceSpell(), 0);
        ICreature tableCreature = table.GetCreatureById(0);
        int difference = tableCreature.HealthIndicator.Value
                         - catalogCreature.HealthIndicator.Value;

        // assert
        Assert.Equal(5, difference);
    }

    [Fact]
    public void MagicMirror_WhenItUsed_SwapsAttackAndHealth()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table();
        table.Add(catalogCreature);

        // act
        table.UseSpell(new MagicMirror(), 0);
        ICreature tableCreature = table.GetCreatureById(0);

        // assert
        Assert.True(tableCreature.HealthIndicator.Value == catalogCreature.AttackIndicator.Value);
        Assert.True(tableCreature.AttackIndicator.Value == catalogCreature.HealthIndicator.Value);
    }

    [Fact]
    public void DefendingAmulet_WhenItUsed_GivesMagicShield()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table();
        table.Add(catalogCreature);

        // act
        table.UseSpell(new DefendingAmulet(), 0);
        ICreature tableCreature = table.GetCreatureById(0);

        // assert
        Assert.IsType<MagicShield>(tableCreature);
    }
}