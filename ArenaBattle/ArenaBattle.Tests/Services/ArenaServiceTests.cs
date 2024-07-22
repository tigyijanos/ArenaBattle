using ArenaBattle.Interfaces.Services;
using ArenaBattle.Models.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ArenaBattle.Tests.Services
{
    public class ArenaServiceTests : TestsBase
    {
        private readonly IArenaService? _service;

        public ArenaServiceTests()
        {
            _service = ServiceProvider.GetService<IArenaService>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(10)]
        public void CreateArena_ShouldCreateArenaWithHeroes(int numberOfHeroes)
        {
            // Arrange && Act
            var arenaId = _service!.CreateArena(numberOfHeroes);
            var arena = _service.GetArena(arenaId);

            // Assert
            Assert.NotNull(arena);
            Assert.Equal(numberOfHeroes, arena.Heroes!.Count);
        }

        [Theory]
        [InlineData(HeroType.Swordsman, 120)]
        [InlineData(HeroType.Archer, 100)]
        [InlineData(HeroType.Cavalry, 150)]
        public void CreateArena_InitialHealth(HeroType heroType, int initialHealth)
        {
            // Arrange
            var numberOfHeroes = 5;

            // Act
            var arenaId = _service!.CreateArena(numberOfHeroes);
            var arena = _service.GetArena(arenaId);
            var heroes = arena!.Heroes!.Where(x => x.Type == heroType).ToList();

            // Assert
            foreach (var hero in heroes)
            {
                Assert.Equal(hero.Health, initialHealth);
            }
        }

        [Fact]
        public void ExecuteBattle_ShouldExecuteAndUpdateHistory()
        {
            // Arrange
            var arenaId = _service!.CreateArena(5);
            var arena = _service.GetArena(arenaId);

            // Act
            _service.ExecuteBattle(arena!);

            // Assert
            Assert.NotEmpty(arena!.History);
            Assert.True(arena.Heroes!.Count(x => x.Health > 0) < 2);
        }

        [Fact]
        public void ExecuteBattle_ShouldReduceHealthCorrectly()
        {
            // Arrange
            var arenaId = _service!.CreateArena(2);
            var arena = _service.GetArena(arenaId);

            // Manually set health to test death condition
            var hero = arena!.Heroes!.First();
            hero.Health = 1;

            // Act
            _service.ExecuteBattle(arena);

            // Assert
            Assert.True(hero.Health == 0, "Hero should be dead if health is less than 1/4th of the initial health");
        }
    }
}
