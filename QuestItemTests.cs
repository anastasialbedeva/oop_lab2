using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Inventory
{
    public class QuestItemTests
    {
        [Fact]
        public void Create_ReturnsNewQuestItemInstance()
        {
            var questItem = QuestItem.Create();

            Assert.NotNull(questItem);
            Assert.IsType<QuestItem>(questItem);
        }

        [Fact]
        public void WithName_SetsNameAndReturnsInstance()
        {
            var questItem = QuestItem.Create();
            var expectedName = "Magic Crystal";

            var result = questItem.WithName(expectedName);

            Assert.Equal(expectedName, questItem.Name);
            Assert.Same(questItem, result);
        }

        [Fact]
        public void WithWeaponUpgradeLevel_SetsLevelAndReturnsInstance()
        {
            var questItem = QuestItem.Create();
            var expectedLevel = 5;

            var result = questItem.WithWeaponUpgradeLevel(expectedLevel);

            Assert.Equal(expectedLevel, questItem.WeaponUpgradeLevel);
            Assert.Same(questItem, result);
        }

        [Fact]
        public void WithDefenseUpgradeLevel_SetsLevelAndReturnsInstance()
        {
            var questItem = QuestItem.Create();
            var expectedLevel = 3;

            var result = questItem.WithDefenseUpgradeLevel(expectedLevel);

            Assert.Equal(expectedLevel, questItem.DefenseUpgradeLevel);
            Assert.Same(questItem, result);
        }

        [Fact]
        public void Describe_ReturnsFormattedString()
        {
            var questItem = QuestItem.Create()
                .WithName("Dragon Scale")
                .WithWeaponUpgradeLevel(10)
                .WithDefenseUpgradeLevel(8);

            var result = questItem.Describe();

            Assert.Equal("[QuestItem] Dragon Scale, WeaponUpgradeLevel=10, DefenseUpgradeLevel=8", result);
        }
    }
}