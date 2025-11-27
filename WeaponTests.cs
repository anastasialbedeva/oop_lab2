using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.Tests
{
    public class WeaponTests
    {
        [Fact]
        public void Create_ReturnsNewWeaponInstance()
        {
            var weapon = Weapon.Create();

            Assert.NotNull(weapon);
            Assert.IsType<Weapon>(weapon);
        }

        [Fact]
        public void WithName_SetsNameAndReturnsInstance()
        {
            var weapon = Weapon.Create();
            var expectedName = "Dragon Slayer";

            var result = weapon.WithName(expectedName);

            Assert.Equal(expectedName, weapon.Name);
            Assert.Same(weapon, result);
        }

        [Fact]
        public void WithDamage_SetsDamageLevelAndReturnsInstance()
        {
            var weapon = Weapon.Create();
            var expectedDamage = 500;

            var result = weapon.WithDamage(expectedDamage);

            Assert.Equal(expectedDamage, weapon.GetDamage());
            Assert.Same(weapon, result);
        }

        [Fact]
        public void WithState_SetsStateAndReturnsInstance()
        {
            var weapon = Weapon.Create();
            var expectedState = 70;

            var result = weapon.WithState(expectedState);

            Assert.Equal(expectedState, weapon.State);
            Assert.Same(weapon, result);
        }

        [Fact]
        public void Wear_DecreasesStateBy10()
        {
            var weapon = Weapon.Create().WithState(80);

            var result = weapon.Wear();

            Assert.Equal(70, result);
        }

        [Fact]
        public void Repair_IncreasesStateBy10()
        {
            var weapon = Weapon.Create().WithState(50);

            var result = weapon.Repair();

            Assert.Equal(60, result);
        }

        [Fact]
        public void IncreaseDamage_IncreasesDamageLevelBy100()
        {
            var weapon = Weapon.Create().WithDamage(200);

            weapon.IncreaseDamage();

            Assert.Equal(300, weapon.GetDamage());
        }

        [Fact]
        public void GetDamage_ReturnsCurrentDamageLevel()
        {
            var weapon = Weapon.Create().WithDamage(1000);

            var result = weapon.GetDamage();

            Assert.Equal(1000, result);
        }

        [Fact]
        public void Describe_ReturnsFormattedString()
        {
            var weapon = Weapon.Create().WithName("Pistol").WithDamage(400).WithState(80);

            var result = weapon.Describe();

            Assert.Equal("[Weapon] Pistol, Damage=400, State=80%", result);
        }

        [Fact]
        public void ApplyQuestItem_IncreasesDamageLevel()
        {
            var weapon = Weapon.Create().WithDamage(200);
            var questItem = new QuestItem("Test Item") { WeaponUpgradeLevel = 100 };

            var result = weapon.ApplyQuestItem(questItem);

            Assert.Equal(300, result);
        }
    }
}