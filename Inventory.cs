using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    public class Inventory
    {
        private static readonly Inventory _instance = new Inventory();
        private List<InventoryItem> _items = new();
        
        public static Inventory Instance => _instance;

        public void AddItem(InventoryItem item)
        {
            _items.Add(item);
        }

        public List<InventoryItem> GetItems()
        {
            return _items;
        }

        public string DescribeAllItems()
        {
            return string.Join("\n", _items.Select(item => item.Describe()));
        }

        public void DeleteAllItems()
        {
            _items.Clear();
        }
        // Abstract Factory методы
        public Weapon CreateDefaultWeapon(string name = "Sword") =>
            Weapon.Create().WithName(name).WithDamage(1000).WithState(100);

        public Defense CreateDefaultDefense(string name = "Shield") =>
            Defense.Create().WithName(name).WithDefense(500).WithState(100);

        public Potion CreateDefaultPotion(string name = "Healing Potion", int amount = 10) =>
            Potion.Create().WithName(name).WithAmount(amount);

        public QuestItem CreateDefaultQuestItem(string name = "Ancient Glyph", int weaponUpgradeLevel = 1, int defenseUpgradeLevel = 1) =>
            QuestItem.Create().WithName(name).WithWeaponUpgradeLevel(weaponUpgradeLevel).WithDefenseUpgradeLevel(defenseUpgradeLevel);
    }
}