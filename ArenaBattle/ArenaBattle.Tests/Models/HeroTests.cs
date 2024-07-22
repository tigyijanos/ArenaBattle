using ArenaBattle.Interfaces.Model;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Tests.Models
{
    public abstract class HeroTests<THero> : TestsBase where THero : IHero, new()
    {
        protected abstract int ExpectedInitialHealth { get; }

        protected abstract HeroType ExpectedType { get; }

        [Fact]
        public void InitialHealth()
        {
            // Arrange
            // Act
            var hero = new THero();

            // Assert
            Assert.Equal(hero.Health, ExpectedInitialHealth);
        }

        [Theory]
        [InlineData(50, 100)]
        [InlineData(0, 10)]
        public void ReduceHealth(int expected, int initial)
        {
            // Arrange
            var hero = new THero
            {
                Health = initial
            };

            // Act
            hero.ReduceHealth();

            // Assert
            Assert.Equal(hero.Health, expected);
        }

        [Fact]
        public void HeroType()
        {
            // Arrange
            // Act
            var hero = new THero();

            // Assert
            Assert.Equal(hero.Type, ExpectedType);
        }
    }
}
