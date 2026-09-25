using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;
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
        var table = new Table(new CryptoRandom());

        // act
        AddCreatureResult firstResult = table.Add(battleAnalyst1);
        AddCreatureResult secondResult = table.Add(battleAnalyst2);
        AddCreatureResult thirdResult = table.Add(immortalHorror1);
        AddCreatureResult fourthResult = table.Add(immortalHorror2);
        AddCreatureResult fifthResult = table.Add(mimicChest1);
        AddCreatureResult sixthResult = table.Add(mimicChest2);
        AddCreatureResult seventhResult = table.Add(evilFighter1);
        AddCreatureResult eightResult = table.Add(evilFighter2);

        // assert
        Assert.IsType<AddCreatureResult.Success>(firstResult);
        Assert.IsType<AddCreatureResult.Success>(secondResult);
        Assert.IsType<AddCreatureResult.Success>(thirdResult);
        Assert.IsType<AddCreatureResult.Success>(fourthResult);
        Assert.IsType<AddCreatureResult.Success>(fifthResult);
        Assert.IsType<AddCreatureResult.Success>(sixthResult);
        Assert.IsType<AddCreatureResult.Success>(seventhResult);
        Assert.IsType<AddCreatureResult.Failure>(eightResult);
    }
}