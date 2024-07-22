using ArenaBattle.Interfaces.Model;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Interfaces.Factories
{
    public interface IHeroFactory
    {
        IHero CreateHero(HeroType heroType);
    }
}
