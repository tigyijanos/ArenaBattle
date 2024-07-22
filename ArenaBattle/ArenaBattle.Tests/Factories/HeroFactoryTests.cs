using ArenaBattle.Interfaces.Factories;
using ArenaBattle.Models.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ArenaBattle.Tests.Factories
{
    public class HeroFactoryTests : TestsBase
    {
        private readonly IHeroFactory? _heroFactory;

        public HeroFactoryTests() => _heroFactory = ServiceProvider.GetService<IHeroFactory>();

        [Theory]
        [InlineData(HeroType.Archer, HeroType.Archer)]
        [InlineData(HeroType.Cavalry, HeroType.Cavalry)]
        [InlineData(HeroType.Swordsman, HeroType.Swordsman)]
        public void CreateHero(HeroType heroType, HeroType expectedHeroType)
        {
            // Arrange
            // Act
            var hero = _heroFactory!.CreateHero(heroType);

            // Assert
            Assert.NotNull(hero);
            Assert.Equal(hero.Type, expectedHeroType);
        }
    }
}
