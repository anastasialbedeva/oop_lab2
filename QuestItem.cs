
namespace Inventory
{

    public interface IQuestItem : IInventoryItem
    {
        QuestItem WithWeaponUpgradeLevel(int level);
        QuestItem WithDefenseUpgradeLevel(int level);
    }
    public class QuestItem(string name) : InventoryItem(name), IQuestItem
    {
        public int WeaponUpgradeLevel { get; set; } = 0;
        public int DefenseUpgradeLevel { get; set; } = 0;

        public static QuestItem Create() => new QuestItem("QuestItem");

        public QuestItem WithName(string name) { Name = name; return this; }

        public QuestItem WithWeaponUpgradeLevel(int level)
        {
            WeaponUpgradeLevel = level;
            return this;
        }

        public QuestItem WithDefenseUpgradeLevel(int level)
        {
            DefenseUpgradeLevel = level;
            return this;
        }


        public override string Describe()
        {
            return $"[QuestItem] {Name}, WeaponUpgradeLevel={WeaponUpgradeLevel}, DefenseUpgradeLevel={DefenseUpgradeLevel}";
        }
    }
}
