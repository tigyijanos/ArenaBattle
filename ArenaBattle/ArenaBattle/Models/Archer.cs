using ArenaBattle.Interfaces.Model;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    public class Archer : Hero, IHero
    {
        public override HeroType Type => HeroType.Archer;

        protected override int GetInitialHealth()
        {
            return 100;
        }
    }
}
