using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        [Fact]
        public void Army_HasAEmptyListOfSoldiers()
        {
            // Given

            // When
            var army = new Army("Orcs");
            // Then
            army.Soldiers.Should().NotBeNull();
        }

        [Fact]
        public void Army_EnlistSoldier_ShouldReturnSoldiers()
        {
            // Given
            var army = new Army("Orcs");
            var soldier = new Soldier("Jos");
            // When
            army.Enlist(soldier);
            // Then
            army.Soldiers.Should().Contain(soldier);
        }
        [Fact]
        public void Army_EnlistSoldier_WhenListIsEmpty_FirstSoldierIsFrontMan()
        {
            // Given
            var army = new Army("Orcs");
            var soldier = new Soldier("Jos");
            // When
            army.Enlist(soldier);
            // Then
            army.Soldiers.Should().Contain(soldier);
            army.FrontMan.Should().Be(soldier);
        }

        [Fact]
        public void Army_EnlistSoldier_WhenListIsNotEmpty_FirstSoldierIsFrontMan()
        {
            // Given
            var army = new Army("Orcs");
            var soldier1 = new Soldier("Jos");
            var soldier2 = new Soldier("Daniel");
            // When
            army.Enlist(soldier1);
            army.Enlist(soldier2);
            // Then
            army.FrontMan.Should().Be(soldier1);
        }

        [Fact]
        public void Army_AnArmyHasAName()
        {
            // Given
            var armyName = "Orcs";
            // When
            var army = new Army(armyName);
            // Then
            army.Name.Should().Be(armyName);
        }

        [Fact]
        public void Attack_EqualStrength_AttackerWins()
        {
            // Given
            var orcArmy = new Army("Orcs");
            orcArmy.Enlist(new Soldier("Srilcmosh"));
            var dwarvesArmy = new Army("Dwarves");
            dwarvesArmy.Enlist(new Soldier("Bifur"));
            // When
            var outcome = dwarvesArmy.Attack(orcArmy);
            // Then
            outcome.Should().Be(dwarvesArmy);
        }

        [Fact]
        public void Attack_EqualStrength_AttackerWins_DefenderFrontManRemovedFromList()
        {
            // Given
            var orcArmy = new Army("Orcs");
            orcArmy.Enlist(new Soldier("Srilcmosh"));
            var dwarvesArmy = new Army("Dwarves");
            dwarvesArmy.Enlist(new Soldier("Bifur"));
            // When
            dwarvesArmy.Attack(orcArmy);
            // Then
            orcArmy.Soldiers.Count.Should().Be(0);
        }

        [Fact]
        public void Attack_EqualStrength_AttackerWins_DefenderFrontManRemoved()
        {
            // Given
            var orcArmy = new Army("Orcs");
            orcArmy.Enlist(new Soldier("Srilcmosh"));
            var dwarvesArmy = new Army("Dwarves");
            dwarvesArmy.Enlist(new Soldier("Bifur"));
            // When
            dwarvesArmy.Attack(orcArmy);
            // Then
            orcArmy.FrontMan.Should().BeNull();
        }


        [Fact]
        public void Attack_AttackerFrontmen_FightWithDefenderFrontMan_DefenderFrontMenWins()
        {
            // Given
            var defendingArmy = new Army("Orcs");
            defendingArmy.Enlist(new Soldier("Srilcmosh", "Axe"));
            var attackerArmy = new Army("Dwarves");
            attackerArmy.Enlist(new Soldier("Bifur"));
            // When
            var result = attackerArmy.Attack(defendingArmy);
            // Then
            result.Should().Be(defendingArmy);

            attackerArmy.FrontMan.Should().BeNull();
            attackerArmy.Soldiers.Should().BeEmpty();
        }

        [Fact]
        public void Attack_AttackerFrontmen_FightWithMultipleFrontMan_AttackerFrontMenChanged()
        {
            // Given
            var defendingArmy = new Army("Orcs");
            defendingArmy.Enlist(new Soldier("Srilcmosh", "Axe"));
            var attackerArmy = new Army("Dwarves");
            var firstFrontMan = new Soldier("Bifur");
            attackerArmy.Enlist(firstFrontMan);
            var winningFrontMan = new Soldier("Bifur2", "Axe");
            attackerArmy.Enlist(winningFrontMan);
            // When
            attackerArmy.FrontMan.Should().Be(firstFrontMan);
            var result = attackerArmy.Attack(defendingArmy);
            // Then
            result.Should().Be(attackerArmy);

            attackerArmy.FrontMan.Should().Be(winningFrontMan);
            attackerArmy.Soldiers.Count.Should().Be(1);
        }

        [Fact]
        public void Attack_AttackerFrontmen_FightWithMultipleFrontMan_FrontMenChanged()
        {
            // Given
            var defendingArmy = new Army("Orcs");
            defendingArmy.Enlist(new Soldier("Srilcmosh", "Sword"));
            var defendingFrontman = new Soldier("Srilcmosh2", "Axe");
            defendingArmy.Enlist(defendingFrontman);
            var attackerArmy = new Army("Dwarves");
            var firstFrontMan = new Soldier("Bifur");
            attackerArmy.Enlist(firstFrontMan);
            var winningFrontMan = new Soldier("Bifur2", "Axe");
            attackerArmy.Enlist(winningFrontMan);
            // When
            var result = attackerArmy.Attack(defendingArmy);
            // Then
            result.Should().Be(attackerArmy);

            attackerArmy.FrontMan.Should().Be(winningFrontMan);
            attackerArmy.Soldiers.Count.Should().Be(1);

            defendingArmy.FrontMan.Should().BeNull();
            defendingArmy.Soldiers.Should().BeEmpty();
        }
    }
}
