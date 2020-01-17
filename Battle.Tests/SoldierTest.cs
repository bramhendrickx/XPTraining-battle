using System;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierTest
    {

        [Fact]
        public void Construction_ASoldierMustHaveAName()
        {
            var soldier = new Soldier("name");

            soldier.Name.Should().Be("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Construction_ASoldierMustHaveAName_CannotBeBlank(string name)
        {
            Action act = () => new Soldier(name);
             
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Soldier_ASoldierHasAWeapon_DefaultIsBareFist()
        {
            // Given
            var name = "Jos";

            // When
            var soldier = new Soldier(name);
            var weapontype = soldier.GetWeaponType();
            // Then
            weapontype.Should().BeEquivalentTo("BareFist");
        }

        [Theory]
        [InlineData("Axe")]
        [InlineData("Sword")]
        [InlineData("Spear")]
        [InlineData("BareFist")]
        public void Soldier_ASoldierHasAWeaponType_(string weaponType)
        {
            // Given
            var name = "Jos";

            // When
            var soldier = new Soldier(name, weaponType);
            var weapontype = soldier.GetWeaponType();
            // Then
            weapontype.Should().BeEquivalentTo(weaponType);
        }

        [Fact]
        public void Soldier_TwoDefaultSoldiers_Fight_AttackerWins()
        {
            // Given
            var attacker = new Soldier("Jos");
            var defender = new Soldier("Daniel");

            // When
            var outcome = attacker.Attack(defender);
            // Then
            outcome.Should().Be(attacker);
        }

        [Theory]
        [InlineData("Axe", "Axe")]
        [InlineData("Spear", "Spear")]
        [InlineData("Sword", "Sword")]
        [InlineData("BareFist", "BareFist")]
        public void Attack_AttackerHasSameWeaponAsDefender_AttackerWins(string attackerWeapon, string defenderWeapon)
        {
            // Given
            var attacker = new Soldier("attacker", attackerWeapon);
            var defender = new Soldier("defender", defenderWeapon);
            // When
            var outcome = attacker.Attack(defender);
            // Then
            outcome.Should().Be(attacker);
        }



        [Theory]
        [InlineData("Axe", "Sword", "attacker")]
        [InlineData("Axe", "Spear", "attacker")]
        [InlineData("Axe", "BareFist", "attacker")]
        [InlineData("Sword", "Spear", "attacker")]
        [InlineData("Sword", "BareFist", "attacker")]
        [InlineData("Sword", "Axe", "defender")]
        [InlineData("Spear", "Sword", "attacker")]
        [InlineData("Spear", "BareFist", "attacker")]
        [InlineData("Spear", "Axe", "defender")]
        [InlineData("BareFist", "Spear", "defender")]
        [InlineData("BareFist", "Sword", "defender")]
        [InlineData("BareFist", "Axe", "defender")]
        public void Attack_SoldierWithStrongestDamagepointsWins(string attackerWeapon, string defenderWeapon, string winner)
        {
            // Given
            var attacker = new Soldier("attacker", attackerWeapon);
            var defender = new Soldier("defender", defenderWeapon);
            // When
            var outcome = attacker.Attack(defender);
            // Then
            outcome.Should().Be(winner == "attacker" ? attacker : defender);
        }



    }
}