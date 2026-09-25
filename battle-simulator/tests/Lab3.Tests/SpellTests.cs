using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;
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
            .WithAttack(new AttackParameter(7))
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table(new CryptoRandom());
        table.Add(catalogEvilFighter);

        // act
        table.UseSpell(new StrengthSpell(), catalogEvilFighter);
        ICreature tableCreature = table.GetCreatureById(0);
        int secondAttackValue = tableCreature.AttackIndicator.Value;

        // assert
        Assert.Equal(12, secondAttackValue);
    }

    [Fact]
    public void EnduranceSpell_WhenItUsed_IncreasesHealthByFive()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithHealth(new HealthParameter(7))
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table(new CryptoRandom());
        table.Add(catalogCreature);

        // act
        table.UseSpell(new EnduranceSpell(), catalogCreature);
        ICreature tableCreature = table.GetCreatureById(0);
        int secondHealthValue = tableCreature.HealthIndicator.Value;

        // assert
        Assert.Equal(12, secondHealthValue);
    }

    [Fact]
    public void MagicMirror_WhenItUsed_SwapsAttackAndHealth()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        int firstAttack = catalogCreature.AttackIndicator.Value;
        int firstHealth = catalogCreature.HealthIndicator.Value;
        var table = new Table(new CryptoRandom());
        table.Add(catalogCreature);

        // act
        table.UseSpell(new MagicMirror(), catalogCreature);
        ICreature tableCreature = table.GetCreatureById(0);

        // assert
        Assert.True(tableCreature.HealthIndicator.Value == firstAttack);
        Assert.True(tableCreature.AttackIndicator.Value == firstHealth);
    }

    [Fact]
    public void DefendingAmulet_WhenItUsed_GivesMagicShield()
    {
        // arrange
        ICreature catalogCreature = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table(new CryptoRandom());
        table.Add(catalogCreature);

        // act
        table.UseSpell(new DefendingAmulet(), catalogCreature);
        ICreature tableCreature = table.GetCreatureById(0);

        // assert
        Assert.IsType<MagicShield>(tableCreature);
    }
}