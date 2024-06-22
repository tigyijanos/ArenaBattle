using ArenaBattle.Models.Enums;
using ArenaBattle.Services;
using Should;

namespace ArenaBattle.Tests.Services
{
    public class ArenaServiceTests
    {
        private readonly ArenaService _service;

        public ArenaServiceTests()
        {
            _service = new ArenaService();
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
            int arenaId = _service.CreateArena(numberOfHeroes);
            var arena = _service.GetArena(arenaId);

            // Assert
            Assert.NotNull(arena);
            Assert.Equal(numberOfHeroes, arena.Heroes.Count);
        }

        [Theory]
        [InlineData(HeroType.Swordsman, 120)]
        [InlineData(HeroType.Archer, 100)]
        [InlineData(HeroType.Cavalry, 150)]
        public void CreateArena_InitialHealth(HeroType heroType, int initialHealth)
        {
            // Arrange
            int numberOfHeroes = 5;

            // Act
            int arenaId = _service.CreateArena(numberOfHeroes);
            var arena = _service.GetArena(arenaId);
            var heroes = arena.Heroes.Where(x => x.Type == heroType).ToList();

            // Assert
            foreach (var hero in heroes)
            {
                hero.Health.ShouldEqual(initialHealth);
            }
        }

        [Fact]
        public void ExecuteBattle_ShouldExecuteAndUpdateHistory()
        {
            // Arrange
            int arenaId = _service.CreateArena(5);
            var arena = _service.GetArena(arenaId);

            // Act
            _service.ExecuteBattle(arena);

            // Assert
            arena.History.ShouldNotBeEmpty();
            arena.Heroes.Where(x => x.Health > 0).Count().ShouldBeLessThan(2);
        }

        [Fact]
        public void ExecuteBattle_ShouldReduceHealthCorrectly()
        {
            // Arrange
            int arenaId = _service.CreateArena(2);
            var arena = _service.GetArena(arenaId);

            // Manually set health to test death condition
            var hero = arena.Heroes.First();
            hero.Health = 1;

            // Act
            _service.ExecuteBattle(arena);

            // Assert
            Assert.True(hero.Health == 0, "Hero should be dead if health is less than 1/4th of the initial health");
        }
    }
}
