using System;

namespace Inventory
{
    public interface IDefense : IArmory
    {
        void IncreaseDefense();
        int GetDefense();
    }

    public class Defense : Armory, IDefense
    {
        private int DefenseLevel { get; set; } = 100;

        public Defense(string name) : base(name){}
        public static Defense Create() => new Defense("Defense");


        public Defense WithName(string name) { Name = name; return this; }
        public Defense WithDefense(int defenseLevel) { DefenseLevel = Math.Min(1000, defenseLevel); return this; }
        public Defense WithState(int state) { State = Clamp(state); return this; }

        public override int Wear() { State = Clamp(State - 10); return State; }
        public override int Repair() { State = Clamp(State + 10); return State; }
        public void IncreaseDefense() { DefenseLevel = Math.Min(1000, DefenseLevel + 100); }
        public int GetDefense() => DefenseLevel;
        public override string Describe() => $"[Defense] {Name}, Defense={DefenseLevel}, State={State}%";
        private static int Clamp(int p) => Math.Max(0, Math.Min(100, p));

        public override int ApplyQuestItem(QuestItem questItem)
        {
            DefenseLevel += questItem.DefenseUpgradeLevel;
            return DefenseLevel;
        }
    }
}
