using ArenaBattle.Models;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Tests.Models
{
    public class SwordsmanTests : HeroTests<Swordsman>
    {
        protected override int ExpectedInitialHealth => 120;

        protected override HeroType ExpectedType => ArenaBattle.Models.Enums.HeroType.Swordsman;
    }
}
