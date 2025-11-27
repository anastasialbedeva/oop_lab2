using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IPotion : IInventoryItem
    {
        void Drink();
    }

    public class Potion(string name) : InventoryItem(name), IPotion
    {
        public int Amount { get; set; } = 10;

        public static Potion Create() => new Potion("Potion");
        public Potion WithName(string name) { Name = name; return this; }
        public Potion WithAmount(int amount) { Amount = amount; return this; }

        public void Drink() { if (Amount > 0) Amount--; }

        public override string Describe() => $"[Potion] {Name}, Amount={Amount}";
    }
}
