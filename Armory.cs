namespace Inventory
{
    public interface IArmory : IInventoryItem
    {
        int Wear();
        int Repair();
        int ApplyQuestItem(QuestItem questItem);
    }

    public abstract class Armory : InventoryItem, IArmory
    {
        public int State { get; set; } = 100;
        public abstract int Wear();
        public abstract int Repair();
        public abstract int ApplyQuestItem(QuestItem questItem);
        public Armory(string name) : base(name) { }
    }
}
