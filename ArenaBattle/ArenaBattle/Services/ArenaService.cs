using ArenaBattle.Interfaces.Factories;
using ArenaBattle.Interfaces.Model;
using ArenaBattle.Interfaces.Services;
using ArenaBattle.Models;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Services
{
    public class ArenaService(IHeroFactory heroFactory) : IArenaService
    {
        private static int _nextArenaId = 1;
        private static readonly List<IArena> _arenas = [];
        private static readonly Random _random = new();

        public int CreateArena(int numberOfHeroes)
        {
            var heroes = new List<IHero>();
            for (var i = 0; i < numberOfHeroes; i++)
            {
                heroes.Add(CreateRandomHero());
            }

            var arena = new Arena
            {
                Id = _nextArenaId++,
                Heroes = heroes
            };

            _arenas.Add(arena);
            return arena.Id;
        }

        public IArena? GetArena(int id)
        {
            return _arenas.FirstOrDefault(a => a.Id == id);
        }

        public void ExecuteBattle(IArena arena)
        {
            while (arena.Heroes != null && arena.Heroes.Count(h => h.Health > 0) > 1)
            {
                var activeHeroes = arena.Heroes.Where(h => h.Health > 0).ToList();
                if (activeHeroes.Count <= 1) return;

                var attackerIndex = _random.Next(activeHeroes.Count);
                var attacker = activeHeroes[attackerIndex];

                int defenderIndex;
                do
                {
                    defenderIndex = _random.Next(activeHeroes.Count);
                } while (defenderIndex == attackerIndex);

                var defender = activeHeroes[defenderIndex];
                var outcome = ResolveAttack(attacker, defender);
                arena.History.Add(new BattleHistory
                {
                    Round = arena.History.Count + 1,
                    Attacker = attacker,
                    Defender = defender,
                    Outcome = outcome,
                    AttackerHealthAfter = attacker.Health,
                    DefenderHealthAfter = defender.Health
                });

                // Reduce the health of the attacker and defender
                attacker.ReduceHealth();
                defender.ReduceHealth();

                // Increase health of the resting heroes
                IncreaseHealthWhileResting(arena, attacker, defender);
            }
        }

        private static void IncreaseHealthWhileResting(IArena arena, IHero attacker, IHero defender)
        {
            if (arena.Heroes != null)
                foreach (var hero in arena.Heroes)
                {
                    if (hero.Health > 0 && hero != attacker && hero != defender)
                    {
                        hero.IncreaseHealth(10);
                    }
                }
        }

        private IHero CreateRandomHero()
        {
            var heroType = (HeroType)_random.Next(3);
            return heroFactory.CreateHero(heroType);
        }

        private string ResolveAttack(IHero attacker, IHero defender)
        {
            return attacker.Type switch
            {
                HeroType.Archer => ArcherAttack(defender),
                HeroType.Cavalry => CavalryAttack(defender),
                HeroType.Swordsman => SwordsmanAttack(defender),
                _ => throw new ArgumentOutOfRangeException(nameof(attacker))
            };
        }

        private string ArcherAttack(IHero defender)
        {
            if (defender.Type == HeroType.Cavalry)
            {
                if (_random.NextDouble() <= 0.4)
                {
                    defender.Health = 0;
                    return "Archer killed Cavalry";
                }
                return "Cavalry blocked Archer";
            }

            defender.Health = 0;
            return $"Archer killed {defender.Type}";
        }

        private string CavalryAttack(IHero defender)
        {
            defender.Health = 0;
            return $"Cavalry killed {defender.Type}";
        }

        private string SwordsmanAttack(IHero defender)
        {
            if (defender.Type == HeroType.Cavalry)
            {
                return "Nothing happened";
            }

            defender.Health = 0;
            return $"Swordsman killed {defender.Type}";
        }
    }
}
