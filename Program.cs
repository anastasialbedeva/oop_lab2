using System;

namespace Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inv = Inventory.Instance;

            var sword = inv.CreateDefaultWeapon("Excalibur").WithDamage(2500);
            var shield = inv.CreateDefaultDefense("Aegis").WithDefense(1500).WithState(90);
            var potion = inv.CreateDefaultPotion("Health Potion").WithAmount(50);
            var glyph = inv.CreateDefaultQuestItem("Glyph of Power").WithDefenseUpgradeLevel(200).WithWeaponUpgradeLevel(0);

            inv.AddItem(sword);
            inv.AddItem(shield);
            inv.AddItem(potion);
            inv.AddItem(glyph);

            sword.Wear();
            shield.Wear();
            potion.Drink();
            shield.Repair();
            sword.ApplyQuestItem(glyph);

            Console.WriteLine(inv.DescribeAllItems());
        }
    }
}
