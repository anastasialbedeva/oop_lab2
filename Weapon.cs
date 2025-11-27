
using System;

namespace Inventory
{
    public interface IWeapon : IArmory
    {
        void IncreaseDamage();
        int GetDamage();
    }

    public class Weapon(string name, int damageLevel) : Armory(name), IWeapon
    {
        private int DamageLevel { get; set; } = damageLevel;

        public static Weapon Create() => new("Weapon", 1000);


        public Weapon WithName(string name) { Name = name; return this; }
        public Weapon WithDamage(int damage) { DamageLevel = Math.Min(1000, damage); return this; }
        public Weapon WithState(int state) { State = Clamp(state); return this; }
        public override int Wear() { State = Clamp(State - 10); return State; }
        public override int Repair() { State = Clamp(State + 10); return State; }
        public void IncreaseDamage() { DamageLevel = Math.Min(1000, DamageLevel + 100); }
        public int GetDamage() => DamageLevel;
        public override string Describe() => $"[Weapon] {Name}, Damage={DamageLevel}, State={State}%";
        private static int Clamp(int p) => Math.Max(0, Math.Min(100, p));

        public override int ApplyQuestItem(QuestItem questItem)
        {
            DamageLevel += questItem.WeaponUpgradeLevel;
            return DamageLevel;
        }
    }
}
