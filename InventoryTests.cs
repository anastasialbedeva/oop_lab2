using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Inventory
{
    public class InventoryTests
    {
        [Fact]
        public void Instance_ReturnsSingletonInstance()
        {
            var instance1 = Inventory.Instance;
            var instance2 = Inventory.Instance;

            Assert.NotNull(instance1);
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void AddItem_AddsItemToInventory()
        {
            var inventory = Inventory.Instance;
            var item = new Weapon("Rifle", 900);

            inventory.AddItem(item);

            Assert.Contains(item, inventory.GetItems());
        }

        [Fact]
        public void GetItems_ReturnsAllItems()
        {
            
            var inventory = Inventory.Instance;
            inventory.DeleteAllItems();
            var weapon = new Weapon("Sword", 100);
            var potion = new Potion("Health Potion");

            inventory.AddItem(weapon);
            inventory.AddItem(potion);
            List<InventoryItem> items = inventory.GetItems();

            Assert.Equal(2, items.Count);
            Assert.Contains(weapon, items);
            Assert.Contains(potion, items);
        }

        [Fact]
        public void DescribeAllItems_ReturnsFormattedString()
        {
            var inventory = Inventory.Instance;
            var weapon = new Weapon("Sword", 1000) { State = 80 };
            var potion = new Potion("Health Potion") { Amount = 5 };

            inventory.AddItem(weapon);
            inventory.AddItem(potion);
            var result = inventory.DescribeAllItems();

            Assert.Contains("[Weapon] Sword, Damage=1000, State=80%", result);
            Assert.Contains("[Potion] Health Potion, Amount=5", result);
        }

        [Fact]
        public void CreateDefaultWeapon_ReturnsWeaponWithDefaultValues()
        {
            var inventory = Inventory.Instance;

            var weapon = inventory.CreateDefaultWeapon("Excalibur");

            Assert.Equal("Excalibur", weapon.Name);
            Assert.Equal(1000, weapon.GetDamage());
            Assert.Equal(100, weapon.State);
        }

        [Fact]
        public void CreateDefaultDefense_ReturnsDefenseWithDefaultValues()
        {
            var inventory = Inventory.Instance;

            var defense = inventory.CreateDefaultDefense("Dragon Shield");

            Assert.Equal("Dragon Shield", defense.Name);
            Assert.Equal(500, defense.GetDefense());
            Assert.Equal(100, defense.State);
        }

        [Fact]
        public void CreateDefaultPotion_ReturnsPotionWithDefaultValues()
        {
            var inventory = Inventory.Instance;

            var potion = inventory.CreateDefaultPotion("Moon Potion", 15);

            Assert.Equal("Moon Potion", potion.Name);
            Assert.Equal(15, potion.Amount);
        }

        [Fact]
        public void CreateDefaultQuestItem_ReturnsQuestItemWithDefaultValues()
        {
            var inventory = Inventory.Instance;

            var questItem = inventory.CreateDefaultQuestItem("Magic Rune", 5, 3);

            Assert.Equal("Magic Rune", questItem.Name);
            Assert.Equal(5, questItem.WeaponUpgradeLevel);
            Assert.Equal(3, questItem.DefenseUpgradeLevel);
        }
    }
}