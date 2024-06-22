using ArenaBattle.Models;
using ArenaBattle.Models.Enums;
using Should;

namespace ArenaBattle.Tests.Models
{
    public abstract class HeroTests<THero> where THero : Hero, new()
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
            hero.Health.ShouldEqual(ExpectedInitialHealth);
        }

        [Theory]
        [InlineData(50, 100)]
        [InlineData(0, 10)]
        public void ReduceHealth(int expected, int initial)
        {
            // Arrange
            var hero = new THero();
            hero.Health = initial;

            // Act
            hero.ReduceHealth();

            // Assert
            hero.Health.ShouldEqual(expected);
        }

        [Fact]
        public void HeroType()
        {
            // Arrange
            // Act
            var hero = new THero();

            // Assert
            hero.Type.ShouldEqual(ExpectedType);
        }
    }
}
