using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    public class Archer : Hero
    {
        public override HeroType Type => HeroType.Archer;

        protected override int GetInitialHealth()
        {
            return 100;
        }
    }
}
