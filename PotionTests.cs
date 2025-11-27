using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Inventory
{
    public class PotionTests
    {
        [Fact]
        public void Create_ReturnsNewPotionInstance()
        {
            var potion = Potion.Create();

            Assert.NotNull(potion);
            Assert.IsType<Potion>(potion);
        }

        [Fact]
        public void WithName_SetsNameAndReturnsInstance()
        {
            var potion = Potion.Create();
            var expectedName = "Health Potion";

            var result = potion.WithName(expectedName);

            Assert.Equal(expectedName, potion.Name);
            Assert.Same(potion, result);
        }

        [Fact]
        public void WithAmount_SetsAmountAndReturnsInstance()
        {
            var potion = Potion.Create();
            var expectedAmount = 5;

            var result = potion.WithAmount(expectedAmount);

            Assert.Equal(expectedAmount, potion.Amount);
            Assert.Same(potion, result);
        }

        [Fact]
        public void Drink_DecreasesAmountByOne()
        {
            var potion = Potion.Create().WithAmount(3);

            potion.Drink();

            Assert.Equal(2, potion.Amount);
        }


        [Fact]
        public void Describe_ReturnsFormattedString()
        {
            var potion = Potion.Create().WithName("Moon Potion").WithAmount(7);

            var result = potion.Describe();

            Assert.Equal("[Potion] Moon Potion, Amount=7", result);
        }
    }
}