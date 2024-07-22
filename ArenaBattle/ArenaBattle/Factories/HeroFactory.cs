using ArenaBattle.Interfaces.Model;
using ArenaBattle.Models.Enums;
using ArenaBattle.Models;
using ArenaBattle.Interfaces.Factories;

namespace ArenaBattle.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(HeroType heroType)
        {
            return heroType switch
            {
                HeroType.Archer => new Archer(),
                HeroType.Cavalry => new Cavalry(),
                HeroType.Swordsman => new Swordsman(),
                _ => throw new ArgumentOutOfRangeException(nameof(heroType), "Invalid hero type")
            };
        }
    }
}
