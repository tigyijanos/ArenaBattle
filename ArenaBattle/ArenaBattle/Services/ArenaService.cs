using ArenaBattle.Models;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Services
{
    public class ArenaService
    {
        private static int _nextArenaId = 1;
        private static List<Arena> _arenas = new();
        private static Random _random = new();

        public int CreateArena(int numberOfHeroes)
        {
            var heroes = new List<Hero>();
            for (int i = 0; i < numberOfHeroes; i++)
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

        public Arena GetArena(int id)
        {
            return _arenas.FirstOrDefault(a => a.Id == id);
        }

        public void ExecuteBattle(Arena arena)
        {
            while (arena.Heroes.Count(h => h.Health > 0) > 1)
            {
                var activeHeroes = arena.Heroes.Where(h => h.Health > 0).ToList();
                if (activeHeroes.Count <= 1) return;

                var attackerIndex = _random.Next(activeHeroes.Count);
                Hero attacker = activeHeroes[attackerIndex];

                int defenderIndex;
                do
                {
                    defenderIndex = _random.Next(activeHeroes.Count);
                } while (defenderIndex == attackerIndex);

                Hero defender = activeHeroes[defenderIndex];
                string outcome = ResolveAttack(attacker, defender);
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

                // Incrase health of the resting heroes
                IncreaseHealthWhileResting(arena, attacker, defender);
            }
        }

        private void IncreaseHealthWhileResting(Arena arena, Hero attacker, Hero defender)
        {
            foreach (var hero in arena.Heroes)
            {
                if (hero.Health > 0 && hero != attacker && hero != defender)
                {
                    hero.IncreaseHealth(10);
                }
            }
        }

        private Hero CreateRandomHero()
        {
            var heroType = (HeroType)_random.Next(3);
            return heroType switch
            {
                HeroType.Archer => new Archer(),
                HeroType.Cavalry => new Cavalry(),
                HeroType.Swordsman => new Swordsman(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private string ResolveAttack(Hero attacker, Hero defender)
        {
            return attacker.Type switch
            {
                HeroType.Archer => ArcherAttack(attacker, defender),
                HeroType.Cavalry => CavalryAttack(attacker, defender),
                HeroType.Swordsman => SwordsmanAttack(attacker, defender),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private string ArcherAttack(Hero attacker, Hero defender)
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

        private string CavalryAttack(Hero attacker, Hero defender)
        {
            defender.Health = 0;
            return $"Cavalry killed {defender.Type}";
        }

        private string SwordsmanAttack(Hero attacker, Hero defender)
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
