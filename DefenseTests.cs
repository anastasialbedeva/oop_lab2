using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace Inventory.Tests
{
    public class DefenseTests
    {
        [Fact]
        public void Create_Constructor_ReturnsDefenseInstance()
        {
            var defense = Defense.Create();
            Assert.NotNull(defense);
            Assert.IsType<Defense>(defense);
        }

        [Fact]
        public void WithName_SetsNameAndReturnsInstance()
        {
            var defense = Defense.Create();
            var expectedName = "Test Shield";

            var result = defense.WithName(expectedName);

            Assert.Equal(expectedName, defense.Name);
            Assert.Same(defense, result);
        }
        
        [Fact]
        public void WithDefense_SetsDefenseLevelAndReturnsInstance()
        {
            var defense = Defense.Create();
            var expectedDefense = 100;

            var result = defense.WithDefense(expectedDefense);

            Assert.Equal(expectedDefense, defense.GetDefense());
            Assert.Same(defense, result);
        }

        [Fact]
        public void WithState_SetsStateAndReturnsInstance()
        {
            var defense = Defense.Create();
            var expectedState = 100;

            var result = defense.WithState(expectedState);

            Assert.Equal(expectedState, defense.State);
            Assert.Same(defense, result);
        }

        [Fact]
        public void Wear_DecreasesStateBy10()
        {
            var defense = Defense.Create().WithState(100);

            var result = defense.Wear();

            Assert.Equal(90, result);
        }

        [Fact]
        public void Repair_IncreasesStateBy10()
        {
            var defense = Defense.Create().WithState(50);

            var result = defense.Repair();

            Assert.Equal(60, result);
        }

        [Fact]
        public void IncreaseDefense_IncreasesDefenseLevelBy100()
        {
            var defense = Defense.Create().WithDefense(100);

            defense.IncreaseDefense();

            Assert.Equal(200, defense.GetDefense());
        }

        [Fact]
        public void GetDefense_ReturnsCurrentDefenseLevel()
        {
            var defense = Defense.Create().WithDefense(100);

            var result = defense.GetDefense();

            Assert.Equal(100, result);
        }

        [Fact]
        public void Describe_ReturnsFormattedString()
        {
            var defense = Defense.Create().WithName("Dragon Shield").WithDefense(400).WithState(80);

            var result = defense.Describe();

            Assert.Equal("[Defense] Dragon Shield, Defense=400, State=80%", result);
        }

        [Fact]
        public void ApplyQuestItem_IncreasesDefenseLevel()
        {
            var defense = Defense.Create().WithDefense(200);
            var questItem = new QuestItem("Test Item") { DefenseUpgradeLevel = 50 };

            var result = defense.ApplyQuestItem(questItem);

            Assert.Equal(250, result);
        }
    }
}


