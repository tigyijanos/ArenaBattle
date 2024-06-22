using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    public class Cavalry : Hero
    {
        public override HeroType Type => HeroType.Cavalry;

        protected override int GetInitialHealth()
        {
            return 150;
        }
    }
}
