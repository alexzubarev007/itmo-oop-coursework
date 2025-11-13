using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TableTests
{
    [Fact]
    public void AddingCreatureToTable_WhenAlreadySevenCreaturesAdded_Fails()
    {
        // arrange
        ICreature battleAnalyst1 = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature battleAnalyst2 = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        ICreature immortalHorror1 = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature immortalHorror2 = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        ICreature mimicChest1 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature mimicChest2 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        ICreature evilFighter1 = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature evilFighter2 = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        var table = new Table();

        // act
        TableResult firstResult = table.Add(battleAnalyst1);
        TableResult secondResult = table.Add(battleAnalyst2);
        TableResult thirdResult = table.Add(immortalHorror1);
        TableResult fourthResult = table.Add(immortalHorror2);
        TableResult fifthResult = table.Add(mimicChest1);
        TableResult sixthResult = table.Add(mimicChest2);
        TableResult seventhResult = table.Add(evilFighter1);
        TableResult eightResult = table.Add(evilFighter2);

        // assert
        Assert.IsType<TableResult.Success>(firstResult);
        Assert.IsType<TableResult.Success>(secondResult);
        Assert.IsType<TableResult.Success>(thirdResult);
        Assert.IsType<TableResult.Success>(fourthResult);
        Assert.IsType<TableResult.Success>(fifthResult);
        Assert.IsType<TableResult.Success>(sixthResult);
        Assert.IsType<TableResult.Success>(seventhResult);
        Assert.IsType<TableResult.Failure>(eightResult);
    }

    [Fact]
    public void CreatureOnTheTable_WhenSomehowChanges_DoNotInfluenceOnCatalogCreature()
    {
        // arrange
        ICreature catalogBattleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var table = new Table();

        // act
        table.Add(catalogBattleAnalyst);
        table.UseSpell(new StrengthSpell(), 0);
        ICreature tableCreature = table.GetCreatureById(0);

        // assert
        Assert.Equal(7, tableCreature.AttackIndicator.Value);
        Assert.Equal(2, catalogBattleAnalyst.AttackIndicator.Value);
    }
}