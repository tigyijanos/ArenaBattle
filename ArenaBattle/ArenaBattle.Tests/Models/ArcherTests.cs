using ArenaBattle.Models;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Tests.Models
{
    public class ArcherTests : HeroTests<Archer>
    {
        protected override int ExpectedInitialHealth => 100;

        protected override HeroType ExpectedType => ArenaBattle.Models.Enums.HeroType.Archer;
    }
}
