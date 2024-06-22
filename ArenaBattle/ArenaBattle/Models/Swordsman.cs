using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    public class Swordsman : Hero
    {
        public override HeroType Type => HeroType.Swordsman;

        protected override int GetInitialHealth()
        {
            return 120;
        }
    }
}
