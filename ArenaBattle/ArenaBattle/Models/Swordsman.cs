using ArenaBattle.Interfaces.Model;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    public class Swordsman : Hero, IHero
    {
        public override HeroType Type => HeroType.Swordsman;

        protected override int GetInitialHealth()
        {
            return 120;
        }
    }
}
